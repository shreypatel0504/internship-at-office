using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class WalletBalanceService
    {
        private readonly IWalletBalanceRepository _repo;

        public WalletBalanceService(IWalletBalanceRepository repo)
        {
            _repo = repo;
        }

        public async Task<WalletBalanceResponseDto> GetWalletBalanceAsync(string? apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return new WalletBalanceResponseDto
                {
                    Status = 401,
                    Success = false,
                    Message = "API key and secret key is required",
                    Data = null
                };
            }

            var balance = await _repo.GetWalletBalanceByApiKeyAsync(apiKey);

            if (balance is null)
            {
                return new WalletBalanceResponseDto
                {
                    Status = 401,
                    Success = false,
                    Message = "API key and secret key is required",
                    Data = null
                };
            }

            return new WalletBalanceResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Wallet retrieved successfully",
                Data = new WalletBalanceDataDto
                {
                    Balance = balance.Value
                }
            };
        }
    }
}