using System.Text.Json.Serialization;

public class LalamoveQuotationDto
{
    [JsonPropertyName("shop_id")]
    public long ShopId { get; set; }

    public string PickupLat { get; set; } = string.Empty;
    public string PickupLng { get; set; } = string.Empty;
    public string PickupAddress { get; set; } = string.Empty;

    public string DropLat { get; set; } = string.Empty;
    public string DropLng { get; set; } = string.Empty;
    public string DropAddress { get; set; } = string.Empty;
}