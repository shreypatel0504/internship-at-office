namespace FoodChow.Application.DTOs
{
    public class WalletBalanceResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public WalletBalanceDataDto? Data { get; set; }
    }

    public class WalletBalanceDataDto
    {
        public double Balance { get; set; }
    }
}