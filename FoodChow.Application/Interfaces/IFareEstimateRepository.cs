namespace FoodChow.Application.Interfaces
{
    public interface IFareEstimateRepository
    {
        Task<FareCalculationResult?> CalculateFareAsync(
            double pickupLatitude, double pickupLongitude,
            double dropLatitude, double dropLongitude,
            string vehicleTypeId);
    }

    public class FareCalculationResult
    {
        public double total_amount { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double total_payable_amount { get; set; }
        public double distance { get; set; }
        public double estimated_duration { get; set; }
        public string? vehicle_name { get; set; }
        public double vehicle_weight { get; set; }
    }
}