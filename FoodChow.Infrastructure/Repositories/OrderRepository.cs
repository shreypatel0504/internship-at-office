using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MySqlDalc _dalc;

        public OrderRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<dynamic> AcceptOrder(string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "get_order_details_by_orderid_web",
                new { order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> DeleteOrder(string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_CheckUniqueOrderId",
                new { order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveCart(OrderEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_FoodOrders",
                new
                {
                    order_id = "",
                    shop_id = model.shop_id,
                    amount = model.amount,
                    charges = model.charges,
                    payment_charges = model.payment_charges,
                    decimal_point = model.decimal_point,
                    total_amount = model.total_amount,
                    payment_method = model.payment_method,
                    delivery_method = model.delivery_method,
                    trans_date = DateTime.Now,
                    trans_method = model.trans_method,
                    table_no = model.table_no,
                    user_id = model.user_id,
                    guest_id = model.guest_id,
                    notes = model.notes,
                    order_status = model.order_status,
                    ipaddress = model.ipaddress,
                    device_type = model.device_type,
                    device_id = model.device_id,
                    created_date = DateTime.Now,
                    device_token = model.device_token,
                    approved_declined_time = model.approved_declined_time,
                    dispatched_time = model.dispatched_time,
                    delivered_time = model.delivered_time,
                    updated_date = DateTime.Now,
                    discounted_amount = model.discounted_amount,
                    discount = model.discount,
                    couponcode = model.couponcode,
                    delivery_datetime = model.delivery_datetime,
                    order_menu_type = model.order_menu_type,
                    order_status_time = model.order_status_time,
                    delivery_partner_id = model.delivery_partner_id,
                    v_type = model.v_type,
                    v_number = model.v_number,
                    token_no = model.token_no,
                    extra_charge_label = model.extra_charge_label
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetPendingOrders(long shopId, DateTime timezone, DateTime timedifferent, int startLimit, int endLimit)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodOrderDetailsPendingOrderlimit",
                new { shopid = shopId, timezone, timedifferent, start_limit = startLimit, end_limit = endLimit },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetDashboardNewOrders(long shopId, DateTime timezone, int offset, int limits)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodOrderDetailsDashboardNeworderlimit",
                new { shopid = shopId, timezone, offset, limits },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetMissedOrders(long shopId, DateTime timezone, int startLimit, int endLimit)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodOrderDetailsMissedlimit",
                new { shopid = shopId, timezone, start_limit = startLimit, end_limit = endLimit },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetDeliveredOrders(long shopId, DateTime timezone, int start, int limits)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodOrderDetailslimit",
                new { shopid = shopId, timezone, start, limits },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetFullOrderDetails(string orderId)
        {
            return await _dalc.CreateConnection().QueryMultipleAsync(
                "USP_GetFullOrderDetails",
                new { p_order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OrderItemEntity>> GetOrderItems(string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync<OrderItemEntity>(
                "USP_GetOrderItems",
                new { p_order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOrderItemQty(long transId, double quantity)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateOrderItemQty",
                new { p_trans_id = transId, p_quantity = quantity },
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteOrderItem(long transId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteOrderItem",
                new { p_trans_id = transId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetOrdersByStatus(long shopId, long status)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetOrdersByStatus",
                new { p_shop_id = shopId, p_status = status },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdatePaymentMethod(string orderId, string paymentMethod)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdatePaymentMethod",
                new { p_order_id = orderId, p_payment_method = paymentMethod },
                commandType: CommandType.StoredProcedure);
        }

        public async Task MarkOrderPaid(string orderId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_MarkOrderPaid",
                new { p_order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetTodayOrderCount(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
                "USP_GetTodayOrderCount",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> SearchOrders(long shopId, string search)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_SearchOrders",
                new { p_shop_id = shopId, p_search = search },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetLatestOrders(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetLatestOrders",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddShopAddressAsync(string address, DateTime createdDate, DateTime updatedDate)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "Add_ShopAddress",
                new { address, country = "", state = "", city = "", area = "", pincode = "", latitude = "", longitude = "", created_date = createdDate, updated_date = updatedDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddShopGuestAsync(string? name, string? lastName, string? email, string? mobile, long? addressId, DateTime registerDate, DateTime createdDate, DateTime updatedDate, string? couponCode, string? companyName, string? countryCode)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "Add_ShopGuest",
                new { name, last_name = lastName, room_no = "", email_id = email, mobile_no = mobile, food_shop_address_id = addressId, is_verified = 1, register_date = registerDate, created_date = createdDate, updated_date = updatedDate, couponcode = couponCode, company_name = companyName, user_country_code = countryCode },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> GetDeliveryPartnerIdAsync(long shopId)
        {
            var result = await _dalc.CreateConnection().QueryFirstOrDefaultAsync<long?>(
                "USP_GetDeliveryPartnerIdFroShop",
                new { ShopId = shopId },
                commandType: CommandType.StoredProcedure);
            return result ?? 0;
        }

        public async Task<OrderMethodTokenResult?> GetOrderMethodTokenForMenuAsync(long shopId, long orderMethodId, long menuId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<OrderMethodTokenResult>(
                "USP_GetOrderMethodTokenForMenu",
                new { shop_id = shopId, order_method_id = orderMethodId, menu_id = menuId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<OrderMethodTokenResult?> GetOrderMethodTokenAsync(long shopId, long orderMethodId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<OrderMethodTokenResult>(
                "USP_GetOrderMethodToken",
                new { shop_id = shopId, order_method_id = orderMethodId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateLastOrderTokenCustomMethodAsync(long shopId, long orderMethodId, long tokenNo, long menuId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateLastOrderTokenCustomMethod",
                new { shop_id = shopId, order_method_id = orderMethodId, token_no = tokenNo, menu_id = menuId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateLastOrderTokenOrderMethodAsync(long shopId, long orderMethodId, long tokenNo)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateLastOrderTokenOrderMethod",
                new { shop_id = shopId, order_method_id = orderMethodId, token_no = tokenNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> AddFoodOrderAsync(AddFoodOrderParams p)
        {
            var orderId = await _dalc.CreateConnection().ExecuteScalarAsync<string>(
                "Add_FoodOrders",
                new
                {
                    order_id = "",
                    p.shop_id,
                    p.discount,
                    p.discounted_amount,
                    p.amount,
                    p.charges,
                    p.payment_charges,
                    p.decimal_point,
                    p.total_amount,
                    p.payment_method,
                    p.delivery_method,
                    p.trans_date,
                    p.trans_method,
                    p.table_no,
                    p.user_id,
                    p.guest_id,
                    p.notes,
                    p.order_status,
                    ipaddress = "",
                    p.device_type,
                    p.device_id,
                    p.device_token,
                    p.created_date,
                    approved_declined_time = (DateTime?)null,
                    dispatched_time = (DateTime?)null,
                    delivered_time = (DateTime?)null,
                    updated_date = (DateTime?)null,
                    p.couponcode,
                    p.delivery_datetime,
                    p.order_menu_type,
                    p.order_status_time,
                    p.delivery_partner_id,
                    p.v_type,
                    p.v_number,
                    p.tip,
                    p.token_no,
                    p.extra_charge_label
                },
                commandType: CommandType.StoredProcedure);
            return orderId ?? string.Empty;
        }

        public async Task<bool> IsCommissionPlanAsync(string shopId)
        {
            var result = await _dalc.CreateConnection().QueryFirstOrDefaultAsync<int?>(
                "SP_FD_POS_ValidateCredits",
                new { p_ShopId = shopId, p_OrderAmount = 0 },
                commandType: CommandType.StoredProcedure);
            return result == 1;
        }

        public async Task<bool> HasFoodPlanAsync(string shopId)
        {
            var rows = await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodPlanDetails",
                new { shpid = shopId },
                commandType: CommandType.StoredProcedure);
            return rows.AsList().Count > 0;
        }

        public async Task DeductPointsFromRechargePlanAsync(double coins, string shopId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "sp_deduct_points_from_recharge_plan",
                new { p_coins = coins, p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task InsertPointsDeductionDetailsAsync(string shopId, string orderId, double orderAmount, double pointsUsed, DateTime createdDate)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "sp_insert_points_detuction_details",
                new { shop_id = shopId, order_id = orderId, order_amount = orderAmount, order_status = "1", points_used = pointsUsed, created_date = createdDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddFoodOrderedDealAsync(string orderId, string? dealId, string? dealName, string? dealDesc, string? dealPrice, string? withCustomisedPrice, string? totalTaxPrice, string? qty, string? totalDealPrice, DateTime createdDate)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "Add_FoodOrderedDeal",
                new { order_id = orderId, deal_id = dealId, deal_name = dealName, deal_desc = dealDesc, deal_price = dealPrice, with_customised_price = withCustomisedPrice, total_tax_price = totalTaxPrice, qty, total_deal_price = totalDealPrice, created_date = createdDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddFoodOrderedDealTaxAsync(string orderId, string? dealId, string? taxName, string? taxAmount, string? taxPercentage)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_FoodOrderedDealTax",
                new { order_id = orderId, deal_id = dealId, tax_name = taxName, tax_amount = taxAmount, tax_percentage = taxPercentage },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddFoodOrderedDealItemAsync(AddOrderedItemParams p)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "Add_FoodOrderedItem",
                new { p.order_id, p.item_id, p.item_name, p.item_size, p.quantity, p.single_price, p.with_customize_price, p.amount, custom_details = "", p.item_note, p.preference_name, p.created_date, p.updated_date, p.deal_id, p.group_no, p.deal_trans_id, menu_id = (string?)null, menu_name = (string?)null, p.size_id, combineList = (string?)null },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddFoodOrderedItemAsync(AddOrderedItemParams p, string? combineList)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "Add_FoodOrderedItem",
                new { p.order_id, p.item_id, p.item_name, p.item_size, p.quantity, p.single_price, p.with_customize_price, p.amount, custom_details = "", p.item_note, p.preference_name, p.created_date, p.updated_date, p.deal_id, p.group_no, deal_trans_id = (long?)null, p.menu_id, p.menu_name, p.size_id, combineList },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddFoodOrderCustomisedItemAsync(string orderId, string? itemId, string? itemSizeName, string? category, long orderItemId, string itemValues)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_FoodOrder_CustomisedItem",
                new { order_id = orderId, item_id = itemId, item_size_name = itemSizeName, category, order_item_id = orderItemId, item_values = itemValues },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddFoodOrderItemsTaxAsync(string orderId, string? itemId, string? taxName, string? taxAmount, string? taxPercentage, long? sizeId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_FoodOrderItemsTax",
                new { order_id = orderId, item_id = itemId, tax_name = taxName, tax_amount = taxAmount, tax_percentage = taxPercentage, size_id = sizeId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task InsertFoodUserOrderAddressAsync(string orderId, string? userId, string? shopAddressId, string shopId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_InsertFoodUserOrderAddress",
                new { orderId, userId, shpAddId = shopAddressId, shpId = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddCashbackTransactionAsync(long userId, string orderId, string amount, string cashbackType, DateTime createdDate)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "add_cashback_transaction",
                new { user_id = userId, order_id = orderId, amount, cashback_type = cashbackType, created_date = createdDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ShopDetailResult?> GetShopDetailAsync(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<ShopDetailResult>(
                "GetShopDetail",
                new { ShopId = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddFoodOrdersTaxWithPercentageAsync(string orderId, string? taxName, string? taxAmount, string? taxPercentage, int taxType, DateTime createdDate)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_FoodOrdersTaxWithPercentage",
                new { order_id = orderId, tax_name = taxName, tax_amount = taxAmount, tax_percentage = taxPercentage, taxType, created_date = createdDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> HasPosDeviceLoggedInAsync(long shopId)
        {
            var rows = await _dalc.CreateConnection().QueryAsync(
                "USP_Get_all_pos_device_login_list",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
            return rows.AsList().Count > 0;
        }

        public async Task<WhiteLabelPartnerResult?> GetWhiteLabelPartnerDetailsAsync(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WhiteLabelPartnerResult>(
                "USP_GetWhiteLabelPartnerDetails",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetDecimalPointAsync(long shopId)
        {
            var result = await _dalc.CreateConnection().QueryFirstOrDefaultAsync<int?>(
                "GetDecimalPoint",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
            return result ?? 2;
        }

        public async Task<StripeDetailResult?> GetStripeDetailAsync(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<StripeDetailResult>(
                "GetStripeDetail",
                new { ShopId = shopId },
                commandType: CommandType.StoredProcedure);
        }
    }
}