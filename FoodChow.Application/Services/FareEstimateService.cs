using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class FareEstimateService
    {
        private readonly IFareEstimateRepository _repo;

        public FareEstimateService(IFareEstimateRepository repo)
        {
            _repo = repo;
        }

        public async Task<FareEstimateResponseDto> EstimateFareAsync(FareEstimateRequestDto request)
        {
            if (request?.Locations == null || request.Locations.Count < 2)
            {
                return new FareEstimateResponseDto
                {
                    Status = 400,
                    Success = false,
                    Message = "At least pickup and drop locations are required.",
                    Data = null
                };
            }

            var pickup = request.Locations[0];
            var drop = request.Locations[^1];

            var result = await _repo.CalculateFareAsync(
                pickup.Latitude, pickup.Longitude,
                drop.Latitude, drop.Longitude,
                request.VehicleTypeId);

            if (result == null)
            {
                return new FareEstimateResponseDto
                {
                    Status = 404,
                    Success = false,
                    Message = "Fare could not be estimated for the given locations.",
                    Data = null
                };
            }

            return new FareEstimateResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Fare estimated successfully",
                Data = new FareEstimateDataDto
                {
                    Pricing = new FarePricingDto
                    {
                        TotalAmount = result.total_amount,
                        Cgst = result.cgst,
                        Sgst = result.sgst,
                        TotalPayableAmount = result.total_payable_amount
                    },
                    Route = new FareRouteDto
                    {
                        Distance = result.distance,
                        EstimatedDuration = result.estimated_duration
                    },
                    VehicleInfo = new FareVehicleInfoDto
                    {
                        Id = request.VehicleTypeId,
                        Name = result.vehicle_name ?? string.Empty,
                        Weight = result.vehicle_weight
                    }
                }
            };
        }
    }
}