namespace FoodChow.Application.Interfaces
{
    public interface IWalletBalanceRepository
    {
        Task<double?> GetWalletBalanceByApiKeyAsync(string apiKey);
    }
}