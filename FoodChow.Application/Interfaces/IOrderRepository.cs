using FoodChow.Application.DTOs;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public class OrderMethodTokenResult
    {
        public string? token_enable { get; set; }
        public int token_start_from { get; set; }
        public long email_notify { get; set; }
        public long email_notify_customer { get; set; }
        public long other_email_verify { get; set; }
        public string? other_email { get; set; }
    }

    public class ShopDetailResult
    {
        public string? subdomain { get; set; }
        public string? shop_name { get; set; }
        public string? mobileno { get; set; }
        public string? device_id { get; set; }
        public string? device_token { get; set; }
        public int device_type { get; set; }
    }

    public class WhiteLabelPartnerResult
    {
        public string? brand_name { get; set; }
        public string? partner_id { get; set; }
        public string? brand_logo { get; set; }
        public string? email_from { get; set; }
        public string? lang_code_short { get; set; }
    }

    public class StripeDetailResult
    {
        public string? shop_id { get; set; }
        public string? connect_id { get; set; }
        public string? secret_key { get; set; }
        public string? publish_key { get; set; }
    }

    public class AddFoodOrderParams
    {
        public string shop_id { get; set; } = string.Empty;
        public string? discount { get; set; }
        public double discounted_amount { get; set; }
        public string amount { get; set; } = string.Empty;
        public string charges { get; set; } = "0";
        public string? payment_charges { get; set; }
        public string? decimal_point { get; set; }
        public string total_amount { get; set; } = string.Empty;
        public string payment_method { get; set; } = string.Empty;
        public string delivery_method { get; set; } = string.Empty;
        public DateTime trans_date { get; set; }
        public string trans_method { get; set; } = "WebSite";
        public string? table_no { get; set; }
        public long? user_id { get; set; }
        public long? guest_id { get; set; }
        public string? notes { get; set; }
        public int order_status { get; set; }
        public string? device_type { get; set; }
        public string? device_id { get; set; }
        public string? device_token { get; set; }
        public DateTime created_date { get; set; }
        public string? couponcode { get; set; }
        public string? delivery_datetime { get; set; }
        public string? order_menu_type { get; set; }
        public string? order_status_time { get; set; }
        public long delivery_partner_id { get; set; }
        public string? v_type { get; set; }
        public string? v_number { get; set; }
        public string? tip { get; set; }
        public long token_no { get; set; }
        public string? extra_charge_label { get; set; }
    }

    public class AddOrderedItemParams
    {
        public string order_id { get; set; } = string.Empty;
        public string? item_id { get; set; }
        public string? item_name { get; set; }
        public string? item_size { get; set; }
        public string quantity { get; set; } = "0";
        public string single_price { get; set; } = "0";
        public string? with_customize_price { get; set; }
        public double amount { get; set; }
        public string? item_note { get; set; }
        public string? preference_name { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public string? deal_id { get; set; }
        public string? group_no { get; set; }
        public long? deal_trans_id { get; set; }
        public string? menu_id { get; set; }
        public string? menu_name { get; set; }
        public long? size_id { get; set; }
    }

    public interface IOrderRepository
    {
        Task<dynamic> AcceptOrder(string orderId);
        Task<dynamic> DeleteOrder(string orderId);
        Task SaveCart(OrderEntity model);
        Task<dynamic> GetPendingOrders(long shopId, DateTime timezone, DateTime timedifferent, int startLimit, int endLimit);
        Task<dynamic> GetDashboardNewOrders(long shopId, DateTime timezone, int offset, int limits);
        Task<dynamic> GetMissedOrders(long shopId, DateTime timezone, int startLimit, int endLimit);
        Task<dynamic> GetDeliveredOrders(long shopId, DateTime timezone, int start, int limits);
        Task<dynamic> GetFullOrderDetails(string orderId);
        Task<IEnumerable<OrderItemEntity>> GetOrderItems(string orderId);
        Task UpdateOrderItemQty(long transId, double quantity);
        Task DeleteOrderItem(long transId);
        Task<dynamic> GetOrdersByStatus(long shopId, long status);
        Task UpdatePaymentMethod(string orderId, string paymentMethod);
        Task MarkOrderPaid(string orderId);
        Task<dynamic> GetTodayOrderCount(long shopId);
        Task<dynamic> SearchOrders(long shopId, string search);
        Task<dynamic> GetLatestOrders(long shopId);
        Task<long> AddShopAddressAsync(string address, DateTime createdDate, DateTime updatedDate);
        Task<long> AddShopGuestAsync(string? name, string? lastName, string? email, string? mobile, long? addressId, DateTime registerDate, DateTime createdDate, DateTime updatedDate, string? couponCode, string? companyName, string? countryCode);
        Task<long> GetDeliveryPartnerIdAsync(long shopId);
        Task<OrderMethodTokenResult?> GetOrderMethodTokenForMenuAsync(long shopId, long orderMethodId, long menuId);
        Task<OrderMethodTokenResult?> GetOrderMethodTokenAsync(long shopId, long orderMethodId);
        Task UpdateLastOrderTokenCustomMethodAsync(long shopId, long orderMethodId, long tokenNo, long menuId);
        Task UpdateLastOrderTokenOrderMethodAsync(long shopId, long orderMethodId, long tokenNo);
        Task<string> AddFoodOrderAsync(AddFoodOrderParams p);
        Task<bool> IsCommissionPlanAsync(string shopId);
        Task<bool> HasFoodPlanAsync(string shopId);
        Task DeductPointsFromRechargePlanAsync(double coins, string shopId);
        Task InsertPointsDeductionDetailsAsync(string shopId, string orderId, double orderAmount, double pointsUsed, DateTime createdDate);
        Task<long> AddFoodOrderedDealAsync(string orderId, string? dealId, string? dealName, string? dealDesc, string? dealPrice, string? withCustomisedPrice, string? totalTaxPrice, string? qty, string? totalDealPrice, DateTime createdDate);
        Task AddFoodOrderedDealTaxAsync(string orderId, string? dealId, string? taxName, string? taxAmount, string? taxPercentage);
        Task<long> AddFoodOrderedDealItemAsync(AddOrderedItemParams p);
        Task<long> AddFoodOrderedItemAsync(AddOrderedItemParams p, string? combineList);
        Task AddFoodOrderCustomisedItemAsync(string orderId, string? itemId, string? itemSizeName, string? category, long orderItemId, string itemValues);
        Task AddFoodOrderItemsTaxAsync(string orderId, string? itemId, string? taxName, string? taxAmount, string? taxPercentage, long? sizeId);
        Task InsertFoodUserOrderAddressAsync(string orderId, string? userId, string? shopAddressId, string shopId);
        Task AddCashbackTransactionAsync(long userId, string orderId, string amount, string cashbackType, DateTime createdDate);
        Task<ShopDetailResult?> GetShopDetailAsync(long shopId);
        Task AddFoodOrdersTaxWithPercentageAsync(string orderId, string? taxName, string? taxAmount, string? taxPercentage, int taxType, DateTime createdDate);
        Task<bool> HasPosDeviceLoggedInAsync(long shopId);
        Task<WhiteLabelPartnerResult?> GetWhiteLabelPartnerDetailsAsync(long shopId);
        Task<int> GetDecimalPointAsync(long shopId);
        Task<StripeDetailResult?> GetStripeDetailAsync(long shopId);
    }
}