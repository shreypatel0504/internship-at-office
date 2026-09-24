using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LalamoveController(ILalaMoveRepository repo) : ControllerBase
    {
        // =========================================
        // COMMON HELPER - GET SHOP DETAILS
        // =========================================

        private async Task<(bool Success, IActionResult? Error, dynamic? Details)> GetShopDetails(long shopId)
        {
            var details = await repo.GetUserDetailsAsync(shopId);

            if (details == null)
            {
                return (
                    false,
                    BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Shop configuration missing in database"
                    }),
                    null
                );
            }

            return (true, null, details);
        }

        // =========================================
        // COMMON HELPER - SEND REQUEST
        // =========================================

        private async Task<IActionResult> SendLalamoveRequest(
            string method,
            string path,
            dynamic details,
            object? body = null)
        {
            try
            {
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                var jsonBody = body == null ? "" : JsonConvert.SerializeObject(body);
                var apiSecret = details.ApiSecret.ToString();
                var apiKey = details.ApiKey.ToString();
                var baseUrl = details.BaseUrl.ToString();
                var marketCode = details.MarketCode != null ? details.MarketCode.ToString() : "";

                if (string.IsNullOrEmpty(baseUrl))
                    return Ok(new ApiResponse<object> { Success = false, Message = $"BaseUrl is not configured. ApiKey={apiKey}, MarketCode={marketCode}" });

                var signature = GenerateSignature(timestamp, method, path, jsonBody, apiSecret);

                using var client = new HttpClient();
                using var request = new HttpRequestMessage(new HttpMethod(method), $"{baseUrl}{path}");

                request.Headers.TryAddWithoutValidation("Authorization", (string)$"hmac {apiKey}:{timestamp}:{signature}");
                request.Headers.TryAddWithoutValidation("Market", marketCode);

                if (!string.IsNullOrEmpty(jsonBody))
                    request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = response.IsSuccessStatusCode,
                    Message = response.IsSuccessStatusCode ? "Success" : content,
                    Data = response.IsSuccessStatusCode ? (object)content : null
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        // =========================================
        // 1 - GET QUOTATION DETAILS
        // =========================================

        [HttpGet("GetQuotationDetails")]
        public async Task<IActionResult> GetQuotationDetails(
            [FromQuery] long shop_id,
            [FromQuery] string quotationId)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Success",
                Data = new
                {
                    quotationId = quotationId,
                    serviceType = "MOTORCYCLE",
                    language = "en_IN",
                    priceBreakdown = new
                    {
                        currency = "INR",
                        total = "120",
                        basePrice = "100",
                        extraMileage = "20"
                    },
                    expiresAt = DateTime.UtcNow.AddMinutes(30)
                }
            });
        }

        // =========================================
        // 2 - CREATE QUOTATION
        // =========================================

        [HttpPost("GetQuotation")]
        public async Task<IActionResult> GetQuotation([FromBody] GetQuotationDto dto)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Success",
                Data = new
                {
                    quotationId = "MOCK-QT-12345",
                    serviceType = "MOTORCYCLE",
                    language = "en_IN",
                    priceBreakdown = new
                    {
                        currency = "INR",
                        total = "150",
                        basePrice = "120",
                        extraMileage = "30"
                    },
                    stops = new[]
                    {
                        new { stopId = "MOCK-STOP-001", address = dto.PickupAddress, lat = dto.PickupLat, lng = dto.PickupLng },
                        new { stopId = "MOCK-STOP-002", address = dto.DropAddress,   lat = dto.DropLat,   lng = dto.DropLng   }
                    },
                    expiresAt = DateTime.UtcNow.AddMinutes(30)
                }
            });
        }

        // =========================================
        // 3 - PLACE ORDER
        // =========================================

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderDto dto)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Success",
                Data = new
                {
                    orderId = "MOCK-ORD-67890",
                    quotationId = dto.QuotationIds,
                    status = "ASSIGNING_DRIVER",
                    shareLink = "https://mock.lalamove.com/track/MOCK-ORD-67890",
                    sender = new
                    {
                        stopId = dto.StopId1,
                        name = dto.ShopName,
                        phone = dto.ShopPhone
                    },
                    recipients = new[]
                    {
                        new
                        {
                            stopId = dto.StopId2,
                            name   = dto.UserName,
                            phone  = dto.UserPhone
                        }
                    },
                    createdAt = DateTime.UtcNow
                }
            });
        }

        // =========================================
        // 4 - GET CITY INFO
        // =========================================

        [HttpGet("GetCityInfoInLalaMove")]
        public async Task<IActionResult> GetCityInfoInLalaMove([FromQuery] long shop_id)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Success",
                Data = new
                {
                    cities = new[]
                    {
                        new { cityId = "MOCK-CITY-IN-001", name = "Surat",  country = "IN", currency = "INR" },
                        new { cityId = "MOCK-CITY-IN-002", name = "Mumbai", country = "IN", currency = "INR" },
                        new { cityId = "MOCK-CITY-IN-003", name = "Delhi",  country = "IN", currency = "INR" }
                    }
                }
            });
        }

        // =========================================
        // 5 - GET ORDER DETAILS
        // =========================================

        [HttpGet("GetOrderDetails")]
        public async Task<IActionResult> GetOrderDetails(
            [FromQuery] string orderId,
            [FromQuery] long shop_id)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Success",
                Data = new
                {
                    orderId = orderId,
                    status = "ON_GOING",
                    shareLink = $"https://mock.lalamove.com/track/{orderId}",
                    driver = new
                    {
                        driverId = "MOCK-DRV-001",
                        name = "Ramesh Kumar",
                        phone = "+919876543210",
                        rating = "4.8"
                    },
                    priceBreakdown = new
                    {
                        currency = "INR",
                        total = "150"
                    },
                    createdAt = DateTime.UtcNow.AddMinutes(-10),
                    updatedAt = DateTime.UtcNow
                }
            });
        }

        // =========================================
        // 6 - GET DRIVER DETAILS
        // =========================================

        [HttpGet("GetDriverDetails")]
        public async Task<IActionResult> GetDriverDetails(
            [FromQuery] string orderId,
            [FromQuery] string driverId,
            [FromQuery] long shop_id)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Success",
                Data = new
                {
                    driverId = driverId,
                    name = "Ramesh Kumar",
                    phone = "+919876543210",
                    rating = "4.8",
                    plateNumber = "GJ05AB1234",
                    vehicleType = "MOTORCYCLE",
                    currentLocation = new
                    {
                        lat = "21.1702",
                        lng = "72.8311"
                    }
                }
            });
        }

        // =========================================
        // 7 - CHANGE DRIVER
        // =========================================

        [HttpDelete("ChangeDriver")]
        public async Task<IActionResult> ChangeDriver(
            [FromQuery] string orderId,
            [FromQuery] string driverId,
            [FromQuery] long shop_id)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Driver change request submitted successfully",
                Data = new
                {
                    orderId = orderId,
                    driverId = driverId,
                    reason = "DRIVER_LATE",
                    status = "ASSIGNING_DRIVER"
                }
            });
        }

        // =========================================
        // 8 - CANCEL ORDER
        // =========================================

        [HttpDelete("CancelOrder")]
        public async Task<IActionResult> CancelOrder(
            [FromQuery] string orderId,
            [FromQuery] long shop_id)
        {
            // MOCK RESPONSE
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Order cancelled successfully",
                Data = new
                {
                    orderId = orderId,
                    status = "CANCELLED",
                    updatedAt = DateTime.UtcNow
                }
            });
        }

        [HttpPost("Webhook")]
        public async Task<IActionResult> ReceiveWebhook([FromBody] WebhookDto dto)
        {
            try
            {
                if (dto.EventType == "ORDER_STATUS_CHANGED")
                {
                    await repo.UpdateOrderStatusAsync(
                        dto.Data!.Order!.OrderId!,
                        dto.Data!.Order!.Status!,
                        dto.Data!.UpdatedAt!
                    );
                }
                else if (dto.EventType == "DRIVER_ASSIGNED")
                {
                    await repo.UpdateDriverDetailsAsync(
                        dto.Data!.Order!.OrderId!,
                        dto.Data!.Driver!.DriverId!,
                        dto.Data!.Driver!.Name!,
                        dto.Data!.Driver!.Phone!,
                        dto.Data!.UpdatedAt!
                    );
                }

                return Ok(new ApiResponse<object> { Success = true, Message = "Webhook received successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        // =========================================
        // 10 - SAVE ORDER DETAILS
        // =========================================

        [HttpPost("SaveOrderDetails")]
        public async Task<IActionResult> SaveOrderDetails([FromBody] SaveLalaMoveOrderDto dto)
        {
            try
            {
                await repo.SaveOrderDetailsAsync(dto);
                return Ok(new ApiResponse<object> { Success = true, Message = "Order details saved successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        // =========================================
        // 11 - ADD ORDER DETAILS
        // =========================================

        [HttpPost("AddOrderDetails")]
        public async Task<IActionResult> AddOrderDetails([FromBody] PlaceOrderDto dto)
        {
            try
            {
                await repo.AddOrderDetailsAsync(dto);
                return Ok(new ApiResponse<object> { Success = true, Message = "Order details added successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        // =========================================
        // 12 - GET LALAMOVE ORDER DETAILS
        // =========================================

        [HttpGet("GetLalaMoveOrderDetails")]
        public async Task<IActionResult> GetLalaMoveOrderDetails([FromQuery] string foodchowOrderId)
        {
            try
            {
                var data = await repo.GetOrderDetailsAsync(foodchowOrderId);

                if (data == null)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Data Not Found!" });

                return Ok(new ApiResponse<object> { Success = true, Data = data });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        // =========================================
        // SIGNATURE GENERATOR
        // =========================================

        private static string GenerateSignature(
            string timestamp,
            string method,
            string path,
            string body,
            string apiSecret)
        {
            var raw = string.IsNullOrEmpty(body)
                ? $"{timestamp}\r\n{method}\r\n{path}\r\n\r\n"
                : $"{timestamp}\r\n{method}\r\n{path}\r\n\r\n{body}";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret));

            return BitConverter
                .ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(raw)))
                .Replace("-", "")
                .ToLower();
        }
    }
}