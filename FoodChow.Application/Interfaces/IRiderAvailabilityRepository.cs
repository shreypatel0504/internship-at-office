namespace FoodChow.Application.Interfaces
{
    public interface IRiderAvailabilityRepository
    {
        Task<bool> IsRiderAvailableAsync(
            double latitude, double longitude,
            string vehicleTypeId, int rangeMeters);
    }
}