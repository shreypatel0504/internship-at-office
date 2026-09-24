namespace FoodChow.Application.DTOs
{
    public class CancelOrderRequestDto
    {
        public string CancelReason { get; set; } = string.Empty;
    }

    public class CancelOrderResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public CancelOrderDataDto? Data { get; set; }
    }

    public class CancelOrderDataDto
    {
        public string ExternalOrderId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string CancelReason { get; set; } = string.Empty;
        public DateTime CancelledAt { get; set; }
    }
}