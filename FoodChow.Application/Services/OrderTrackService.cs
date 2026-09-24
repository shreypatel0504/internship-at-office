using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class OrderTrackService
    {
        private readonly IOrderTrackRepository _repo;

        public OrderTrackService(IOrderTrackRepository repo)
        {
            _repo = repo;
        }

        public async Task<TrackOrderResponseDto> TrackOrderAsync(string orderId)
        {
            var raw = await _repo.GetOrderTrackingAsync(orderId);

            if (raw?.Main is null)
            {
                return new TrackOrderResponseDto
                {
                    Status = 404,
                    Success = false,
                    Message = "Order not found.",
                    Data = null
                };
            }

            var main = raw.Main;

            var stops = raw.Stops.Select(s => new TrackStopDto
            {
                Latitude = s.latitude,
                Longitude = s.longitude,
                Address = s.address,
                NearByLandmark = s.near_by_landmark,
                Pincode = s.pincode,
                OtherLocationText = s.other_location_text,
                UnitNumber = s.unit_number,
                SenderName = s.sender_name,
                SenderNumber = s.sender_number,
                City = s.city,
                PickupLocationType = null,
                StopOrder = s.stop_order
            }).OrderBy(s => s.StopOrder).ToList();

            var pickup = stops.FirstOrDefault() as TrackLocationDto ?? new TrackLocationDto();
            var drop = stops.LastOrDefault() as TrackLocationDto ?? new TrackLocationDto();

            var vehicleName = main.vehicle_name ?? "";
            var nameParts = vehicleName.Split(' ', 2);
            var vehicleType = nameParts.Length > 0 ? nameParts[0] : "";
            var vehicleSubType = nameParts.Length > 1 ? nameParts[1] : "";

            var statusHistory = raw.History.Select(h => new TrackStatusHistoryDto
            {
                StatusFrom = h.status_from,
                StatusTo = h.status_to ?? "",
                CreatedAt = h.created_date,
                ChangedBy = h.changed_by ?? "",
                ChangeReason = h.change_reason ?? "",
                LocationIndex = null,
                CurrentLocationType = null,
                AdditionalData = null,
                Pilot = null,
                VehicleInfo = null
            }).OrderBy(h => h.CreatedAt).ToList();

            return new TrackOrderResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Order tracking retrieved successfully",
                Data = new TrackOrderDataDto
                {
                    TrackingUrl = $"https://tracking.drop-it.co/{main.id}",
                    ExternalOrderId = main.external_order_id ?? orderId,
                    Status = main.status ?? "",
                    PickupLocation = pickup,
                    OrderStops = stops,
                    DropLocation = drop,
                    Pricing = new TrackPricingDto
                    {
                        TotalAmount = main.total_amount,
                        TotalPayableAmount = main.total_payable_amount
                    },
                    DeliveryInfo = new TrackDeliveryInfoDto
                    {
                        GoodsTypes = raw.Goods.Select(g => g.goods_type ?? "").ToList(),
                        Distance = main.distance,
                        Duration = main.estimated_duration
                    },
                    OrderVehicle = new TrackVehicleDto
                    {
                        VehicleType = vehicleType,
                        VehicleSubType = vehicleSubType
                    },
                    IsScheduled = main.is_scheduled,
                    ScheduleDate = main.schedule_date,
                    StatusHistory = statusHistory
                }
            };
        }
    }
}