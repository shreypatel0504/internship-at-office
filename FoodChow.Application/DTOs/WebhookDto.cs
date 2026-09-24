namespace FoodChow.Application.DTOs
{
    public class WebhookDto
    {
        public string? EventType { get; set; }
        public WebhookDataDto? Data { get; set; }
    }

    public class WebhookDataDto
    {
        public WebhookOrderDto? Order { get; set; }
        public WebhookDriverDto? Driver { get; set; }
        public string? UpdatedAt { get; set; }
    }

    public class WebhookOrderDto
    {
        public string? OrderId { get; set; }
        public string? Status { get; set; }
    }

    public class WebhookDriverDto
    {
        public string? DriverId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}