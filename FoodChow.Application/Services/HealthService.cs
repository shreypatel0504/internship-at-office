using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class HealthService
    {
        private readonly IHealthRepository _repo;

        public HealthService(IHealthRepository repo)
        {
            _repo = repo;
        }

        public async Task<HealthCheckResponseDto> CheckHealthAsync(string? apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return new HealthCheckResponseDto
                {
                    Status = 401,
                    Success = false,
                    Message = "API Key is missing.",
                    Data = null
                };
            }

            var vendor = await _repo.GetVendorByApiKeyAsync(apiKey);

            if (vendor is null || !vendor.is_active)
            {
                return new HealthCheckResponseDto
                {
                    Status = 401,
                    Success = false,
                    Message = "Invalid or inactive API Key.",
                    Data = null
                };
            }

            var permissions = string.IsNullOrWhiteSpace(vendor.permissions)
                ? new List<string>()
                : vendor.permissions.Split(',').Select(p => p.Trim()).ToList();

            return new HealthCheckResponseDto
            {
                Status = 200,
                Success = true,
                Message = "FoodChow Business API is healthy",
                Data = new HealthCheckDataDto
                {
                    Email = vendor.email,
                    Name = vendor.company_name,
                    MobileNumber = vendor.mobile_number,
                    Timestamp = DateTime.UtcNow,
                    Vendor = new VendorInfoDto
                    {
                        CompanyName = vendor.company_name,
                        IsActive = vendor.is_active
                    },
                    ApiKey = new ApiKeyInfoDto
                    {
                        Permissions = permissions
                    }
                }
            };
        }
    }
}