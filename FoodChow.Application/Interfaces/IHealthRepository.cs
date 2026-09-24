namespace FoodChow.Application.Interfaces
{
    public class VendorApiKeyResult
    {
        public string? company_name { get; set; }
        public string? email { get; set; }
        public string? mobile_number { get; set; }
        public bool is_active { get; set; }
        public string? permissions { get; set; }
    }

    public interface IHealthRepository
    {
        Task<VendorApiKeyResult?> GetVendorByApiKeyAsync(string apiKey);
    }
}