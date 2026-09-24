using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorterController(IPorterConfigurationRepository repo) : ControllerBase
    {
        // ===============================
        // HELPER METHOD
        // ===============================
        private string BuildUrl(string baseUrl, string path)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("Porter BaseUrl is missing in configuration");

            return $"{baseUrl.TrimEnd('/')}/{path.TrimStart('/')}";
        }

        private void AddApiKey(HttpClient client, string apiKey)
        {
            client.DefaultRequestHeaders.Remove("X-API-KEY");
            client.DefaultRequestHeaders.Add("X-API-KEY", apiKey ?? "");
        }

        // ===============================
        // 1. GET QUOTE
        // ===============================
        [HttpPost("get-quote")]
        public async Task<IActionResult> GetQuoteData([FromBody] PorterQuoteDto dto)
        {

            try
            {
                var details = (await repo.Get(dto.ShopId)).FirstOrDefault();

                if (details == null)
                    return Ok(new ApiBaseResponse<object> { Success = false, Message = "Porter configuration not found" });

                // 🔥 MOCK CHECK MUST BE HERE (BEFORE HTTP CALL)
                if (!string.IsNullOrEmpty(details.BaseUrl) &&
                    details.BaseUrl.Contains("mock"))
                {
                    return Ok(new ApiBaseResponse<object>
                    {
                        Success = true,
                        Message = "Mock quote generated",
                        Data = new
                        {
                            price = 100,
                            eta = "30 mins"
                        }
                    });
                }
                Console.WriteLine("Porter BaseUrl: " + details.BaseUrl);

                var payload = new
                {
                    pickup_details = new { lat = dto.PickupLat, lng = dto.PickupLng },
                    drop_details = new { lat = dto.DropLat, lng = dto.DropLng },
                    customer = new
                    {
                        name = dto.CustomerName,
                        mobile = new
                        {
                            country_code = dto.CountryCode,
                            number = dto.PhoneNumber
                        }
                    }
                };

                var json = System.Text.Json.JsonSerializer.Serialize(payload);

                using var client = new HttpClient();
                AddApiKey(client, details.ApiKey);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    BuildUrl(details.BaseUrl, "v1/get_quote"),
                    content);

                return Ok(new ApiBaseResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = await response.Content.ReadAsStringAsync()
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiBaseResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ===============================
        // 2. CREATE ORDER
        // ===============================
        [HttpPost("porter-order")]
        public async Task<IActionResult> PorterOrder([FromBody] PorterOrderDto dto)
        {
            try
            {
                var details = (await repo.Get(dto.ShopId)).FirstOrDefault();

                if (details == null)
                    return Ok(new ApiBaseResponse<object> { Success = false, Message = "Porter configuration not found" });

                using var client = new HttpClient();
                AddApiKey(client, details.ApiKey);

                var json = System.Text.Json.JsonSerializer.Serialize(dto);

                var response = await client.PostAsync(
                    BuildUrl(details.BaseUrl, "v1/orders/create"),
                    new StringContent(json, Encoding.UTF8, "application/json"));

                return Ok(new ApiBaseResponse<object>
                {
                    Success = true,
                    Message = "Order Created",
                    Data = await response.Content.ReadAsStringAsync()
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiBaseResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ===============================
        // 3. TRACK ORDER
        // ===============================
        [HttpGet("track-order")]
        public async Task<IActionResult> TrackOrder(string orderId, long shopId)
        {
            try
            {
                var details = (await repo.Get(shopId)).FirstOrDefault();

                if (details == null)
                    return Ok(new ApiBaseResponse<object> { Success = false, Message = "Porter configuration not found" });

                using var client = new HttpClient();
                AddApiKey(client, details.ApiKey);

                var response = await client.GetAsync(
                    BuildUrl(details.BaseUrl, $"v1.1/orders/{orderId}"));

                return Ok(new ApiBaseResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = await response.Content.ReadAsStringAsync()
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiBaseResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ===============================
        // 4. CANCEL ORDER
        // ===============================
        [HttpPost("cancel-order")]
        public async Task<IActionResult> CancelOrder(string orderId, long shopId)
        {
            try
            {
                var details = (await repo.Get(shopId)).FirstOrDefault();

                if (details == null)
                    return Ok(new ApiBaseResponse<object> { Success = false, Message = "Porter configuration not found" });

                using var client = new HttpClient();
                AddApiKey(client, details.ApiKey);

                var response = await client.PostAsync(
                    BuildUrl(details.BaseUrl, $"v1/orders/{orderId}/cancel"),
                    null);

                return Ok(new ApiBaseResponse<object>
                {
                    Success = true,
                    Message = "Cancelled",
                    Data = await response.Content.ReadAsStringAsync()
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiBaseResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ===============================
        // WEBHOOK
        // ===============================
        [HttpPost("webhook")]
        public IActionResult Webhook(object payload)
        {
            return Ok(new ApiBaseResponse<object>
            {
                Success = true,
                Message = "Webhook received",
                Data = payload
            });
        }
    }
}