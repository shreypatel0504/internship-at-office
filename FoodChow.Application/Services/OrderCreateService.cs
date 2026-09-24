using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class OrderCreateService
    {
        private readonly IOrderCreateRepository _repo;

        public OrderCreateService(IOrderCreateRepository repo)
        {
            _repo = repo;
        }

        public async Task<CreateOrderResponseDto> CreateOrderAsync(CreateOrderRequestDto request)
        {
            if (request?.Locations == null || request.Locations.Count < 2)
            {
                return new CreateOrderResponseDto
                {
                    Status = 400,
                    Success = false,
                    Message = "At least pickup and drop locations are required.",
                    Data = null
                };
            }

            var pickup = request.Locations[0];
            var drop = request.Locations[^1];
            var createdAt = DateTime.UtcNow;

            var orderParams = new CreateOrderParams
            {
                ExternalOrderId = request.ExternalOrderId,
                VehicleTypeId = request.VehicleTypeId,
                OrderPayType = request.OrderPayType,
                IsScheduled = request.IsScheduled,
                ScheduleDate = request.ScheduleDate,
                LoadAssistNeeded = request.LoadAssistNeeded,
                CashCollectAtPickUp = request.CashCollectAtPickUp,
                IsOtpRequestedForVerification = request.IsOtpRequestedForVerification,
                PickupLatitude = pickup.Latitude,
                PickupLongitude = pickup.Longitude,
                DropLatitude = drop.Latitude,
                DropLongitude = drop.Longitude,
                CreatedAt = createdAt
            };

            var result = await _repo.CreateOrderAsync(orderParams);

            if (result == null)
            {
                return new CreateOrderResponseDto
                {
                    Status = 400,
                    Success = false,
                    Message = "Order could not be created. Please check the vehicle type.",
                    Data = null
                };
            }

            int stopOrder = 1;
            foreach (var loc in request.Locations)
            {
                await _repo.AddOrderStopAsync(request.ExternalOrderId, loc, stopOrder);
                stopOrder++;
            }

            if (request.GoodsTypes is not null)
            {
                foreach (var goodsType in request.GoodsTypes)
                {
                    await _repo.AddOrderGoodsTypeAsync(request.ExternalOrderId, goodsType);
                }
            }

            await _repo.AddOrderStatusHistoryAsync(request.ExternalOrderId, "Pending", "System", "Order created via Dropit Business API", createdAt);

            var vehicleName = result.vehicle_name ?? "";
            var nameParts = vehicleName.Split(' ', 2);
            var vehicleType = nameParts.Length > 0 ? nameParts[0] : "";
            var vehicleSubType = nameParts.Length > 1 ? nameParts[1] : "";

            var orderStops = new List<OrderStopDto>();
            int idx = 1;
            foreach (var loc in request.Locations)
            {
                orderStops.Add(new OrderStopDto
                {
                    Latitude = loc.Latitude,
                    Longitude = loc.Longitude,
                    Address = loc.Address,
                    NearByLandmark = loc.NearByLandmark,
                    Pincode = loc.Pincode,
                    OtherLocationText = loc.OtherLocationText,
                    UnitNumber = loc.UnitNumber,
                    SenderName = loc.SenderName,
                    SenderNumber = loc.SenderNumber,
                    City = loc.City,
                    StopOrder = idx
                });
                idx++;
            }

            return new CreateOrderResponseDto
            {
                Status = 201,
                Success = true,
                Message = "Order created successfully",
                Data = new CreateOrderDataDto
                {
                    ExternalOrderId = request.ExternalOrderId,
                    Status = "Pending",
                    CreatedAt = createdAt,
                    PickupLocation = pickup,
                    OrderStops = orderStops,
                    DropLocation = drop,
                    Pricing = new OrderPricingDto
                    {
                        TotalAmount = result.total_amount,
                        TotalPayableAmount = result.total_payable_amount
                    },
                    DeliveryInfo = new OrderDeliveryInfoDto
                    {
                        GoodsTypes = request.GoodsTypes ?? new List<string>(),
                        Distance = result.distance,
                        EstimatedDuration = result.estimated_duration
                    },
                    OrderVehicle = new OrderVehicleDto
                    {
                        VehicleType = vehicleType,
                        VehicleSubType = vehicleSubType
                    },
                    IsScheduled = request.IsScheduled,
                    ScheduleDate = request.ScheduleDate,
                    StatusHistory = new List<OrderStatusHistoryDto>
                    {
                        new OrderStatusHistoryDto
                        {
                            ExternalOrderId = request.ExternalOrderId,
                            StatusFrom = null,
                            StatusTo = "Pending",
                            CreatedAt = createdAt,
                            ChangedBy = "System",
                            ChangeReason = "Order created via Dropit Business API"
                        }
                    }
                }
            };
        }
    }
}