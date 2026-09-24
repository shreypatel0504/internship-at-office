using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Globalization;

namespace FoodChow.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IShopTimeZoneService _timeZoneService;
        private readonly IShopCurrencyService _currencyService;
        private readonly IOrderNotificationService _notificationService;
        private readonly IOrderEmailService _emailService;

        public OrderService(IOrderRepository repo, IShopTimeZoneService timeZoneService, IShopCurrencyService currencyService, IOrderNotificationService notificationService, IOrderEmailService emailService)
        {
            _repo = repo;
            _timeZoneService = timeZoneService;
            _currencyService = currencyService;
            _notificationService = notificationService;
            _emailService = emailService;
        }

        public async Task<dynamic> AcceptOrder(string orderId) => await _repo.AcceptOrder(orderId);
        public async Task<dynamic> DeleteOrder(string orderId) => await _repo.DeleteOrder(orderId);
        public async Task SaveCart(OrderEntity model) => await _repo.SaveCart(model);
        public async Task<dynamic> GetPendingOrders(long shopId, DateTime timezone, DateTime timedifferent, int startLimit, int endLimit) => await _repo.GetPendingOrders(shopId, timezone, timedifferent, startLimit, endLimit);
        public async Task<dynamic> GetDashboardNewOrders(long shopId, DateTime timezone, int offset, int limits) => await _repo.GetDashboardNewOrders(shopId, timezone, offset, limits);
        public async Task<dynamic> GetMissedOrders(long shopId, DateTime timezone, int startLimit, int endLimit) => await _repo.GetMissedOrders(shopId, timezone, startLimit, endLimit);
        public async Task<dynamic> GetDeliveredOrders(long shopId, DateTime timezone, int start, int limits) => await _repo.GetDeliveredOrders(shopId, timezone, start, limits);
        public async Task<dynamic> GetFullOrderDetails(string orderId) => await _repo.GetFullOrderDetails(orderId);
        public async Task<IEnumerable<OrderItemEntity>> GetOrderItems(string orderId) => await _repo.GetOrderItems(orderId);
        public async Task UpdateOrderItemQty(long transId, double quantity) => await _repo.UpdateOrderItemQty(transId, quantity);
        public async Task DeleteOrderItem(long transId) => await _repo.DeleteOrderItem(transId);
        public async Task<dynamic> GetOrdersByStatus(long shopId, long status) => await _repo.GetOrdersByStatus(shopId, status);
        public async Task UpdatePaymentMethod(string orderId, string paymentMethod) => await _repo.UpdatePaymentMethod(orderId, paymentMethod);
        public async Task MarkOrderPaid(string orderId) => await _repo.MarkOrderPaid(orderId);
        public async Task<dynamic> GetTodayOrderCount(long shopId) => await _repo.GetTodayOrderCount(shopId);
        public async Task<dynamic> SearchOrders(long shopId, string search) => await _repo.SearchOrders(shopId, search);
        public async Task<dynamic> GetLatestOrders(long shopId) => await _repo.GetLatestOrders(shopId);

        public async Task<ApiResponse<object>> SaveOrderAsync(SaveOrderDto orderData, string baseUrl)
        {
            if (orderData is null)
                return ApiResponse<object>.Fail("Failed to save the Cart. Please try again later!");

            bool hasItems = orderData.items is { Length: > 0 };
            bool hasDeals = orderData.deals is { Length: > 0 };
            if (!hasItems && !hasDeals)
                return ApiResponse<object>.Fail("Error in Sending Data!");

            try
            {
                long shopId = Convert.ToInt64(orderData.shop_id);
                DateTime timezone = await _timeZoneService.GetShopLocalTimeAsync(shopId);

                string? deliveryDateTime = orderData.delivery_datetime;
                if (orderData.order_status_time == "Now")
                    deliveryDateTime = timezone.ToString("dd MMM yyyy h:mm tt");

                double finalAmount = CalculateFinalAmount(orderData);

                long? addressId = orderData.delivery_method == "Home Delivery" ? null : 1;
                long userId = 0;
                long guestId = 0;

                if (orderData.delivery_method == "Home Delivery" && orderData.user_type == "G")
                    addressId = await _repo.AddShopAddressAsync(orderData.user_address ?? "", timezone, timezone);

                if (orderData.user_type == "U")
                    userId = Convert.ToInt64(orderData.user_id);
                else if (orderData.user_type == "G")
                    guestId = await _repo.AddShopGuestAsync(orderData.user_name, orderData.user_last_name, orderData.user_email, orderData.user_mobile, addressId, timezone, timezone, timezone, orderData.couponcode, orderData.company_name, orderData.user_country_code);

                if (string.IsNullOrEmpty(orderData.delivery_charges))
                    orderData.delivery_charges = "0";

                long deliveryPartnerId = await _repo.GetDeliveryPartnerIdAsync(shopId);
                long orderMethodIdToken = Convert.ToInt64(orderData.delivery_method_id);
                var (tokenNo, emailNotifyEnable, emailNotifyCustomer, otherEmail) = await ResolveOrderTokenAsync(orderData, shopId, orderMethodIdToken);

                var orderParams = new AddFoodOrderParams
                {
                    shop_id = orderData.shop_id,
                    discount = orderData.discounted_amount,
                    discounted_amount = finalAmount,
                    amount = orderData.subtotal_amount,
                    charges = orderData.delivery_charges ?? "0",
                    payment_charges = orderData.payment_charges,
                    decimal_point = orderData.decimal_point,
                    total_amount = orderData.total_amount,
                    payment_method = orderData.payment_method,
                    delivery_method = orderData.delivery_method,
                    trans_date = timezone,
                    trans_method = orderData.device_type switch { "2" => "IoS", "1" => "android", "4" => "pos", _ => "WebSite" },
                    table_no = orderData.table_no,
                    user_id = userId != 0 ? userId : null,
                    guest_id = userId != 0 ? null : guestId,
                    notes = orderData.notes,
                    order_status = ResolveOrderStatus(orderData.payment_method, orderData.device_type),
                    device_type = orderData.device_type,
                    device_id = orderData.device_id,
                    device_token = orderData.device_token,
                    created_date = timezone,
                    couponcode = orderData.couponcode,
                    delivery_datetime = deliveryDateTime,
                    order_menu_type = orderData.order_menu_type,
                    order_status_time = orderData.order_status_time,
                    delivery_partner_id = deliveryPartnerId,
                    v_type = orderData.v_type,
                    v_number = orderData.v_number,
                    tip = orderData.tip,
                    token_no = tokenNo,
                    extra_charge_label = orderData.extra_charge_label
                };

                string orderId = await _repo.AddFoodOrderAsync(orderParams);

                if (await _repo.IsCommissionPlanAsync(orderData.shop_id) && await _repo.HasFoodPlanAsync(orderData.shop_id))
                {
                    double totalAmt = Convert.ToDouble(orderData.total_amount);
                    await _repo.DeductPointsFromRechargePlanAsync(totalAmt, orderData.shop_id);
                    await _repo.InsertPointsDeductionDetailsAsync(orderData.shop_id, orderId, totalAmt, totalAmt, timezone);
                }

                if (orderData.custom_menu_id != 0)
                    await _repo.UpdateLastOrderTokenCustomMethodAsync(shopId, orderMethodIdToken, tokenNo, orderData.custom_menu_id);
                else
                    await _repo.UpdateLastOrderTokenOrderMethodAsync(shopId, orderMethodIdToken, tokenNo);

                if (orderData.deals is not null)
                    await SaveDealsAsync(orderData.deals, orderId, timezone);

                if (orderData.items is not null)
                    await SaveItemsAsync(orderData.items, orderId, timezone);

                if (orderData.user_type == "U")
                {
                    string shopAddressId = orderData.delivery_method == "Home Delivery" ? orderData.food_shop_address_id ?? "" : "1";
                    await _repo.InsertFoodUserOrderAddressAsync(orderId, orderData.user_id, shopAddressId, orderData.shop_id);
                }

                if (orderData.payment_method != "Online")
                {
                    if (!string.IsNullOrEmpty(orderData.shop_user_cashback))
                        await _repo.AddCashbackTransactionAsync(userId, orderId, orderData.shop_user_cashback, "1", timezone);
                    if (!string.IsNullOrEmpty(orderData.user_cashback))
                        await _repo.AddCashbackTransactionAsync(userId, orderId, orderData.user_cashback, "0", timezone);
                }

                var shopDetail = await _repo.GetShopDetailAsync(shopId);

                if (orderData.taxes is not null)
                    foreach (var tax in orderData.taxes)
                        await _repo.AddFoodOrdersTaxWithPercentageAsync(orderId, tax.tax_name, tax.tax_amount, tax.tax_percentage, Convert.ToInt32(tax.taxType), DateTime.Now);

                if (orderData.payment_method is "Cash" or "Card" or "Pay At Counter")
                    return await HandleCashOrCardPaymentAsync(orderData, orderId, finalAmount, shopId, baseUrl, shopDetail, emailNotifyEnable, emailNotifyCustomer, otherEmail);

                if (orderData.payment_method == "Online")
                    return await HandleOnlinePaymentAsync(orderData, orderId, shopId);

                return ApiResponse<object>.Fail("Failed to save the Cart. Please try again later!");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry"))
                    return ApiResponse<object>.Fail("Duplicate order ID detected: " + ex.Message);
                return ApiResponse<object>.Fail("Exception occurred: " + ex.Message);
            }
        }

        private static double CalculateFinalAmount(SaveOrderDto orderData)
        {
            decimal total = decimal.Parse(orderData.total_amount, CultureInfo.InvariantCulture);
            if (!string.IsNullOrWhiteSpace(orderData.discounted_amount) && orderData.discounted_amount != "0")
            {
                decimal discount = decimal.Parse(orderData.discounted_amount, CultureInfo.InvariantCulture);
                return (double)(discount > 0 ? total - discount : total);
            }
            return (double)total;
        }

        private static int ResolveOrderStatus(string paymentMethod, string? deviceType)
        {
            if (paymentMethod == "Online") return deviceType == "4" ? 6 : 12;
            return deviceType == "4" ? 6 : 4;
        }

        private static long? ParseSizeId(string? sizeId)
        {
            if (sizeId == "") return null;
            return Convert.ToInt64(sizeId);
        }

        private async Task<(long tokenNo, long emailNotifyEnable, long emailNotifyCustomer, string? otherEmail)> ResolveOrderTokenAsync(SaveOrderDto orderData, long shopId, long orderMethodIdToken)
        {
            OrderMethodTokenResult? tokenResult = orderData.custom_menu_id != 0
                ? await _repo.GetOrderMethodTokenForMenuAsync(shopId, orderMethodIdToken, orderData.custom_menu_id)
                : await _repo.GetOrderMethodTokenAsync(shopId, orderMethodIdToken);

            if (tokenResult is null) return (0, 0, 0, null);

            string? otherEmail = tokenResult.other_email_verify == 1 ? tokenResult.other_email : null;
            long tokenNo = 0;
            if (tokenResult.token_enable == "1")
                tokenNo = tokenResult.token_start_from == 0 ? 1 : tokenResult.token_start_from + 1;

            return (tokenNo, tokenResult.email_notify, tokenResult.email_notify_customer, otherEmail);
        }

        private async Task SaveDealsAsync(OrderDealDto[] deals, string orderId, DateTime timezone)
        {
            foreach (var deal in deals)
            {
                long dealTransId = await _repo.AddFoodOrderedDealAsync(orderId, deal.order_dealid, deal.order_dealname, deal.order_dealdesc, deal.order_deal_price, deal.with_customize_price, deal.total_tax_price, deal.order_deal_qty, deal.order_total_deal_price, timezone);

                if (deal.deal_taxes is not null)
                    foreach (var tax in deal.deal_taxes)
                        await _repo.AddFoodOrderedDealTaxAsync(orderId, deal.order_dealid, tax.taxname, tax.taxamount, tax.tax_percentage);

                foreach (var item in deal.items)
                {
                    decimal qty = decimal.Parse(item.order_item_qty, CultureInfo.InvariantCulture);
                    decimal unitPrice = !string.IsNullOrEmpty(item.order_item_cust_price) && item.order_item_cust_price != "0"
                        ? decimal.Parse(item.order_item_cust_price, CultureInfo.InvariantCulture)
                        : decimal.Parse(item.order_item_price, CultureInfo.InvariantCulture);

                    var p = new AddOrderedItemParams { order_id = orderId, item_id = item.order_itemid, item_name = item.order_itemname, item_size = item.order_size, quantity = item.order_item_qty, single_price = item.order_item_price, with_customize_price = item.order_item_cust_price, amount = (double)(qty * unitPrice), item_note = item.item_notes, preference_name = item.preference_names, created_date = timezone, updated_date = timezone, deal_id = item.deal_id, group_no = item.group_no, deal_trans_id = dealTransId, size_id = ParseSizeId(item.size_id) };

                    long transItemId = await _repo.AddFoodOrderedDealItemAsync(p);
                    await SaveCustomisedItemsAsync(item, orderId, transItemId);
                }
            }
        }

        private async Task SaveItemsAsync(OrderItemDto[] items, string orderId, DateTime timezone)
        {
            foreach (var item in items)
            {
                decimal qty = decimal.Parse(item.order_item_qty, CultureInfo.InvariantCulture);
                decimal unitPrice = !string.IsNullOrEmpty(item.order_item_cust_price) && item.order_item_cust_price != "0"
                    ? decimal.Parse(item.order_item_cust_price, CultureInfo.InvariantCulture)
                    : decimal.Parse(item.order_item_price, CultureInfo.InvariantCulture);

                var p = new AddOrderedItemParams { order_id = orderId, item_id = item.order_itemid, item_name = item.order_itemname, item_size = item.order_size, quantity = item.order_item_qty, single_price = item.order_item_price, with_customize_price = item.order_item_cust_price, amount = (double)(qty * unitPrice), item_note = item.item_notes, preference_name = item.preference_names, created_date = timezone, updated_date = timezone, deal_id = item.deal_id, group_no = item.group_no, menu_id = item.menu_id, menu_name = item.menu_name, size_id = ParseSizeId(item.size_id) };

                long transItemId = await _repo.AddFoodOrderedItemAsync(p, item.combineList?.ToString());
                await SaveCustomisedItemsAsync(item, orderId, transItemId);

                if (item.item_tax is { Length: > 0 })
                    foreach (var tax in item.item_tax)
                        await _repo.AddFoodOrderItemsTaxAsync(orderId, item.order_itemid, tax.taxname, tax.taxamount, tax.tax_percentage, ParseSizeId(item.size_id));
            }
        }

        private async Task SaveCustomisedItemsAsync(OrderItemDto item, string orderId, long transItemId)
        {
            if (item.custom_ids is not { Length: > 0 }) return;
            foreach (var custom in item.custom_ids)
            {
                if (string.IsNullOrEmpty(custom.item_cust_values)) continue;
                await _repo.AddFoodOrderCustomisedItemAsync(orderId, item.order_itemid, item.order_size, custom.item_cust_category, transItemId, custom.item_cust_values.TrimEnd(','));
            }
        }

        private async Task<ApiResponse<object>> HandleCashOrCardPaymentAsync(SaveOrderDto orderData, string orderId, double finalAmount, long shopId, string baseUrl, ShopDetailResult? shopDetail, long emailNotifyEnable, long emailNotifyCustomer, string? otherEmail)
        {
            string logoUrl = $"{baseUrl}/LogoImages/";
            string shopName = shopDetail?.shop_name ?? "";
            string pushMessage = $"Hurry Up! You have receive an order with Order Id:{orderId} in your restaurant {shopName}. Manage your orders from FoodChow Restaurant Manager app.Take action to keep your customer happy.";

            if (!string.IsNullOrEmpty(shopDetail?.device_id) && !string.IsNullOrEmpty(shopDetail?.device_token))
                await _notificationService.SendShopDevicePushAsync(shopDetail!.device_token!, shopDetail.device_type, pushMessage, shopId, orderId);

            if (await _repo.HasPosDeviceLoggedInAsync(shopId))
                await _notificationService.SendPosDevicePushAsync(pushMessage, shopId, orderId);

            await _notificationService.SendWhatsAppNewOrderNotificationAsync(orderId);

            string sendMailFrom = "support@foodchow.com";
            string whiteLabelBrandName = "Tenacious Techies";
            string defaultMailLanguage = "en";

            var whiteLabel = await _repo.GetWhiteLabelPartnerDetailsAsync(shopId);
            if (whiteLabel is not null)
            {
                whiteLabelBrandName = whiteLabel.brand_name ?? whiteLabelBrandName;
                sendMailFrom = whiteLabel.email_from ?? sendMailFrom;
                defaultMailLanguage = whiteLabel.lang_code_short ?? defaultMailLanguage;
                logoUrl = $"{baseUrl}/brandimg/{whiteLabel.partner_id}/{whiteLabel.brand_logo}";
            }

            int decimalPoint = await _repo.GetDecimalPointAsync(shopId);
            await _emailService.SendOrderEmailAsync(orderId, finalAmount.ToString(CultureInfo.InvariantCulture), orderData.currency, logoUrl, baseUrl, otherEmail, emailNotifyEnable, emailNotifyCustomer, sendMailFrom, whiteLabelBrandName, defaultMailLanguage, decimalPoint);

            var data = new { OrderId = orderId, TotalAmount = orderData.total_amount, Currency = orderData.currency };
            return ApiResponse<object>.Ok(data, "Your order is being placed!");
        }

        private async Task<ApiResponse<object>> HandleOnlinePaymentAsync(SaveOrderDto orderData, string orderId, long shopId)
        {
            _ = await _currencyService.GetShopCurrencyByIdAsync(shopId.ToString());
            var stripe = await _repo.GetStripeDetailAsync(shopId);
            if (stripe is not null)
            {
                var data = new { shop_id = stripe.shop_id, connect_id = stripe.connect_id, secret_key = stripe.secret_key, publish_key = stripe.publish_key, order_id = orderId };
                return ApiResponse<object>.Ok(data, "Order details are saved. Proceed to pay!");
            }
            return ApiResponse<object>.Fail("Online Payment is not configured for this Restaurant!");
        }
    }
}