using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using System.Net.Http.Json;

namespace FoodChow.Application.Services
{
    public class PorterService
    {
        private readonly IPorterConfigurationRepository repo;

        public PorterService(IPorterConfigurationRepository repo)
        {
            this.repo = repo;
        }


        public async Task<PorterResponse> GetQuote(PorterRequest dto)
        {
            // 1. GET CONFIG FROM DB


            var config = await repo.Get(dto.ShopId);
            var data = config.FirstOrDefault();

            if (data == null || string.IsNullOrWhiteSpace(data.BaseUrl))
                return new PorterResponse
                {
                    Success = false,
                    Message = "Porter base_url not configured"
                };

            // 2. CREATE HTTP CLIENT
            using var client = new HttpClient
            {
                BaseAddress = new Uri(data.BaseUrl)
            };

            // 3. REQUEST PAYLOAD (Porter API format)
            var payload = new
            {
                pickup = new
                {
                    lat = dto.PickupLat,
                    lng = dto.PickupLng
                },
                drop = new
                {
                    lat = dto.DropLat,
                    lng = dto.DropLng
                },
                customer = new
                {
                    name = dto.CustomerName,
                    phone = dto.CountryCode + dto.PhoneNumber
                }
            };

            // 4. CALL PORTER API
            var response = await client.PostAsJsonAsync("/v1/quote", payload);

            var result = await response.Content.ReadAsStringAsync();

            return new PorterResponse
            {
                Success = response.IsSuccessStatusCode,
                Message = response.IsSuccessStatusCode ? "Quote fetched" : result,
                Data = result
            };
        }
    }
}