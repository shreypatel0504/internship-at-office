using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoodChow.Application.Services
{
    public class LalaMoveService
    {
        private readonly ILalaMoveRepository repo;

        public LalaMoveService(ILalaMoveRepository repo)
        {
            this.repo = repo;
        }

        // ========================= PRIVATE HELPER =========================

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

            using var hmac = new HMACSHA256(
                Encoding.UTF8.GetBytes(apiSecret)
            );

            return BitConverter
                .ToString(
                    hmac.ComputeHash(
                        Encoding.UTF8.GetBytes(raw)
                    )
                )
                .Replace("-", "")
                .ToLower();
        }

        private static async Task<(bool IsSuccess, string Content)> SendRequestAsync(
     string baseUrl,
     string path,
     HttpMethod httpMethod,
     string apiKey,
     string marketCode,
     string signature,
     string timestamp,
     string? jsonBody = null)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(
                httpMethod,
                $"{baseUrl}{path}"
            );

            // =========================
            // AUTH HEADER (FIXED)
            // =========================
            request.Headers.Add(
                "Authorization",
                $"hmac {apiKey}:{timestamp}:{signature}"
            );

            // =========================
            // MARKET HEADER (FIXED)
            // =========================
            request.Headers.Add(
                "Market",
                marketCode
            );

            // =========================
            // BODY
            // =========================
            if (!string.IsNullOrWhiteSpace(jsonBody))
            {
                request.Content = new StringContent(
                    jsonBody,
                    Encoding.UTF8,
                    "application/json"
                );
            }

            using var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            return (
                response.IsSuccessStatusCode,
                content
            );
        }

        // ========================= 1. GET QUOTATION DETAILS =========================

        public async Task<ApiResponse<object>> GetQuotationDetailsAsync(
            long shopId,
            string quotationId)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(shopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = $"/v3/quotations/{quotationId}";

                var signature = GenerateSignature(
                    timestamp,
                    "GET",
                    path,
                    "",
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Get,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 2. GET QUOTATION =========================

        public async Task<ApiResponse<object>> GetQuotationAsync(
            GetQuotationDto dto)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(dto.ShopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = "/v3/quotations";

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    data = new
                    {
                        serviceType = "MOTORCYCLE",
                        language = "en_MY",

                        stops = new[]
                        {
                            new
                            {
                                coordinates = new
                                {
                                    lat = dto.PickupLat,
                                    lng = dto.PickupLng
                                },
                                address = dto.PickupAddress
                            },

                            new
                            {
                                coordinates = new
                                {
                                    lat = dto.DropLat,
                                    lng = dto.DropLng
                                },
                                address = dto.DropAddress
                            }
                        },

                        isRouteOptimized = true,

                        item = new
                        {
                            categories = new[]
                            {
                                "FOOD_DELIVERY"
                            }
                        }
                    }
                });

                var signature = GenerateSignature(
                    timestamp,
                    "POST",
                    path,
                    jsonBody,
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Post,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp,
                    jsonBody
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }


        // ========================= 3. PLACE ORDER =========================

        public async Task<ApiResponse<object>> PlaceOrderAsync(
            PlaceOrderDto dto)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(dto.ShopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = "/v3/orders";

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    data = new
                    {
                        quotationId = dto.QuotationIds,

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
                        name = dto.UserName,
                        phone = dto.UserPhone
                    }
                },

                        isPODEnabled = true
                    }
                });

                var signature = GenerateSignature(
                    timestamp,
                    "POST",
                    path,
                    jsonBody,
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Post,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp,
                    jsonBody
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 4. GET CITY INFO =========================

        public async Task<ApiResponse<object>> GetCityInfoAsync(
            long shopId)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(shopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = "/v3/cities";

                var signature = GenerateSignature(
                    timestamp,
                    "GET",
                    path,
                    "",
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Get,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 5. GET ORDER DETAILS =========================

        public async Task<ApiResponse<object>> GetOrderDetailsAsync(
            string orderId,
            long shopId)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(shopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = $"/v3/orders/{orderId}";

                var signature = GenerateSignature(
                    timestamp,
                    "GET",
                    path,
                    "",
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Get,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 6. GET DRIVER DETAILS =========================

        public async Task<ApiResponse<object>> GetDriverDetailsAsync(
            string orderId,
            string driverId,
            long shopId)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(shopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = $"/v3/orders/{orderId}/drivers/{driverId}";

                var signature = GenerateSignature(
                    timestamp,
                    "GET",
                    path,
                    "",
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Get,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 7. CHANGE DRIVER =========================

        public async Task<ApiResponse<object>> ChangeDriverAsync(
            string orderId,
            string driverId,
            long shopId)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(shopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = $"/v3/orders/{orderId}/drivers/{driverId}";

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    data = new
                    {
                        reason = "DRIVER_LATE"
                    }
                });

                var signature = GenerateSignature(
                    timestamp,
                    "DELETE",
                    path,
                    jsonBody,
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Delete,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp,
                    jsonBody
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 8. CANCEL ORDER =========================

        public async Task<ApiResponse<object>> CancelOrderAsync(
            string orderId,
            long shopId)
        {
            try
            {
                var d = await repo.GetUserDetailsAsync(shopId);

                if (d == null)
                    return ApiResponse<object>.Fail("Shop not found.");

                var timestamp = DateTimeOffset.Now
                    .ToUnixTimeMilliseconds()
                    .ToString();

                var path = $"/v3/orders/{orderId}";

                var jsonBody = JsonConvert.SerializeObject(new { });

                var signature = GenerateSignature(
                    timestamp,
                    "DELETE",
                    path,
                    jsonBody,
                    d.ApiSecret!
                );

                var (ok, content) = await SendRequestAsync(
                    d.BaseUrl!,
                    path,
                    HttpMethod.Delete,
                    d.ApiKey!,
                    d.MarketCode!,
                    signature,
                    timestamp,
                    jsonBody
                );

                return ok
                    ? ApiResponse<object>.Ok(content)
                    : ApiResponse<object>.Fail(content);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 9. SAVE ORDER DETAILS =========================

        public async Task<ApiResponse<object>> SaveOrderDetailsAsync(
            SaveLalaMoveOrderDto dto)
        {
            try
            {
                await repo.SaveOrderDetailsAsync(dto);

                return ApiResponse<object>.Ok(
                    "",
                    "Success"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 10. ADD ORDER DETAILS =========================

        public async Task<ApiResponse<object>> AddOrderDetailsAsync(
            PlaceOrderDto dto)
        {
            try
            {
                await repo.AddOrderDetailsAsync(dto);

                return ApiResponse<object>.Ok(
                    "",
                    "Success"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 11. GET LALAMOVE ORDER DETAILS =========================

        public async Task<ApiResponse<object>> GetLalaMoveOrderDetailsAsync(
            string foodchowOrderId)
        {
            try
            {
                var data = await repo.GetOrderDetailsAsync(
                    foodchowOrderId
                );

                if (data == null)
                {
                    return ApiResponse<object>.Fail(
                        "Data Not Found!"
                    );
                }

                return ApiResponse<object>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ========================= 12. RECEIVE WEBHOOK =========================

        public async Task<ApiResponse<object>> ReceiveWebhookAsync(
            string requestBody)
        {
            try
            {
                var jsonData = JObject.Parse(requestBody);

                string? eventType = jsonData["eventType"]?.ToString();

                // ================= ORDER STATUS =================

                if (eventType == "ORDER_STATUS_CHANGED")
                {
                    await repo.UpdateOrderStatusAsync(
                        jsonData["data"]!["order"]!["orderId"]!.ToString(),
                        jsonData["data"]!["order"]!["status"]!.ToString(),
                        jsonData["data"]!["updatedAt"]!.ToString()
                    );
                }

                // ================= DRIVER ASSIGNED =================

                else if (eventType == "DRIVER_ASSIGNED")
                {
                    await repo.UpdateDriverDetailsAsync(
                        jsonData["data"]!["order"]!["orderId"]!.ToString(),
                        jsonData["data"]!["driver"]!["driverId"]!.ToString(),
                        jsonData["data"]!["driver"]!["name"]!.ToString(),
                        jsonData["data"]!["driver"]!["phone"]!.ToString(),
                        jsonData["data"]!["updatedAt"]!.ToString()
                    );
                }

                return ApiResponse<object>.Ok(
                    "",
                    "Webhook received successfully"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }
    }
}

