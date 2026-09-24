using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class RiderAvailabilityService
    {
        private readonly IRiderAvailabilityRepository _repo;

        public RiderAvailabilityService(IRiderAvailabilityRepository repo)
        {
            _repo = repo;
        }

        public async Task<RiderAvailabilityResponseDto> CheckAvailabilityAsync(RiderAvailabilityRequestDto request)
        {
            if (request?.Locations == null || request.Locations.Count == 0)
            {
                return new RiderAvailabilityResponseDto
                {
                    Status = 400,
                    Success = false,
                    Message = "At least the pickup location is required.",
                    Data = null
                };
            }

            var pickup = request.Locations[0];

            bool isAvailable = await _repo.IsRiderAvailableAsync(
                pickup.Latitude, pickup.Longitude,
                request.VehicleTypeId, request.RangeMeters);

            return new RiderAvailabilityResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Rider availability checked successfully",
                Data = new RiderAvailabilityDataDto
                {
                    Available = isAvailable
                }
            };
        }
    }
}