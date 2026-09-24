using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class MetaService
    {
        private readonly IMetaRepository _repo;

        public MetaService(IMetaRepository repo)
        {
            _repo = repo;
        }

        public async Task<AreaServiceabilityResponseDto> CheckAreaServiceabilityBatchAsync(AreaServiceabilityBatchRequestDto request)
        {
            if (request?.Locations is null || request.Locations.Count == 0)
            {
                return new AreaServiceabilityResponseDto
                {
                    Status = 400,
                    Success = false,
                    Message = "At least one location is required.",
                    Data = null
                };
            }

            var results = new List<LocationServiceabilityDto>();

            foreach (var loc in request.Locations)
            {
                bool isServiceable = await _repo.IsLocationServiceableAsync(loc.Latitude, loc.Longitude);
                results.Add(new LocationServiceabilityDto
                {
                    Latitude = loc.Latitude,
                    Longitude = loc.Longitude,
                    IsServiceable = isServiceable
                });
            }

            return new AreaServiceabilityResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Area serviceability checked successfully",
                Data = results
            };
        }

        public async Task<MetaTypesResponseDto> GetMetaTypesAsync()
        {
            var raw = await _repo.GetMetaTypesAsync();

            string GetSetting(string key) =>
                raw.Settings.FirstOrDefault(s => s.setting_key == key)?.setting_value ?? "";

            var goodsTypes = GetSetting("goodsTypes")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).ToList();

            var cancellationReasons = GetSetting("cancellationReasons")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).ToList();

            return new MetaTypesResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Vehicle types retrieved successfully",
                Data = new MetaTypesDataDto
                {
                    Vehicle = raw.Vehicles.Select(v => new VehicleTypeDto
                    {
                        Id = v.id ?? "",
                        Weight = v.weight,
                        Name = v.name ?? ""
                    }).ToList(),
                    GoodsTypes = goodsTypes,
                    CancellationReasons = cancellationReasons,
                    CustomerCareNumber = GetSetting("customerCareNumber"),
                    PreferedOperatingHours = GetSetting("preferedOperatingHours")
                }
            };
        }
    }
}