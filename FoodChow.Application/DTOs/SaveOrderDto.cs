// =====================================================================================
// SaveOrderDto.cs
// Reverse-engineered from the legacy "SaveCartWD_web" method by inspecting every
// orderData.xxx property that the original code reads or writes.
//
// IMPORTANT DESIGN DECISION:
// Property names are kept in snake_case (instead of the usual PascalCase C# style)
// on purpose. The original API contract (the JSON your mobile app / website already
// sends) uses these exact snake_case field names. Renaming them to PascalCase here
// would break every existing client unless you also add [JsonPropertyName] mappings.
// Keeping snake_case avoids that risk entirely.
// =====================================================================================

namespace FoodChow.Application.DTOs
{
    public class SaveOrderDto
    {
        // ---- Order totals / payment ----
        public string total_amount { get; set; } = string.Empty;
        public string subtotal_amount { get; set; } = string.Empty;
        public string? discounted_amount { get; set; }
        public string payment_method { get; set; } = string.Empty;     // "Cash" | "Card" | "Pay At Counter" | "Online"
        public string? payment_method_id { get; set; }
        public string? payment_charges { get; set; }
        public string? decimal_point { get; set; }
        public string currency { get; set; } = string.Empty;
        public string? delivery_charges { get; set; }
        public string? tip { get; set; }
        public string? extra_charge_label { get; set; }
        public string? couponcode { get; set; }

        // ---- Shop / delivery ----
        public string shop_id { get; set; } = string.Empty;
        public string delivery_method { get; set; } = string.Empty;   // e.g. "Home Delivery"
        public string? delivery_method_id { get; set; }
        public string? delivery_datetime { get; set; }
        public string? order_status_time { get; set; }                // "Now" or a scheduled time
        public string? order_menu_type { get; set; }
        public long custom_menu_id { get; set; }
        public string? table_no { get; set; }
        public string? notes { get; set; }
        public string? v_type { get; set; }
        public string? v_number { get; set; }

        // ---- Device / origin ----
        public string? device_type { get; set; }                      // "1" Android, "2" iOS, "4" POS, else Website
        public string? device_id { get; set; }
        public string? device_token { get; set; }

        // ---- User / Guest ----
        public string user_type { get; set; } = string.Empty;          // "U" registered user | "G" guest
        public string? user_id { get; set; }
        public string? user_name { get; set; }
        public string? user_last_name { get; set; }
        public string? user_email { get; set; }
        public string user_mobile { get; set; } = string.Empty;
        public string? user_address { get; set; }
        public string? user_country_code { get; set; }
        public string? company_name { get; set; }
        public string? food_shop_address_id { get; set; }
        public string? shop_user_cashback { get; set; }
        public string? user_cashback { get; set; }

        // ---- Collections ----
        public OrderItemDto[]? items { get; set; }
        public OrderDealDto[]? deals { get; set; }
        public OrderTaxDto[]? taxes { get; set; }
    }

    public class OrderItemDto
    {
        public string? order_itemid { get; set; }
        public string? order_itemname { get; set; }
        public string? order_size { get; set; }
        public string order_item_qty { get; set; } = "0";
        public string order_item_price { get; set; } = "0";
        public string? order_item_cust_price { get; set; }
        public string? item_notes { get; set; }
        public string? preference_names { get; set; }
        public string? deal_id { get; set; }
        public string? group_no { get; set; }
        public string? size_id { get; set; }                          // empty string "" means "no size"
        public string? menu_id { get; set; }
        public string? menu_name { get; set; }

        // Original code calls item.combineList.ToString() — keeping it as object
        // preserves whatever shape the client actually sends (array/object/string).
        public object? combineList { get; set; }

        public CustomIdDto[]? custom_ids { get; set; }
        public OrderItemTaxDto[]? item_tax { get; set; }
    }

    public class OrderDealDto
    {
        public string? order_dealid { get; set; }
        public string? order_dealname { get; set; }
        public string? order_dealdesc { get; set; }
        public string? order_deal_price { get; set; }
        public string? with_customize_price { get; set; }
        public string? total_tax_price { get; set; }
        public string? order_deal_qty { get; set; }
        public string? order_total_deal_price { get; set; }

        public OrderItemTaxDto[]? deal_taxes { get; set; }
        public OrderItemDto[] items { get; set; } = System.Array.Empty<OrderItemDto>();
    }

    // Shared shape used by both item-level taxes (item_tax) and deal-level taxes (deal_taxes)
    public class OrderItemTaxDto
    {
        public string? taxname { get; set; }
        public string? taxamount { get; set; }
        public string? tax_percentage { get; set; }
    }

    public class CustomIdDto
    {
        public string? custom_cat_id { get; set; }
        public string? item_cust_category { get; set; }
        // Comma separated values, e.g. "Extra Cheese,No Onion," — trimmed of the
        // trailing comma before being saved (see original TrimEnd(',') call).
        public string item_cust_values { get; set; } = string.Empty;
    }

    // Top-level order taxes (orderData.taxes), separate from per-item/per-deal taxes.
    public class OrderTaxDto
    {
        public string? tax_name { get; set; }
        public string? tax_amount { get; set; }
        public string? tax_percentage { get; set; }
        public string? taxType { get; set; }
    }
}
