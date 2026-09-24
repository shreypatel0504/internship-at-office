using FoodChow.Domain.Entities;
namespace FoodChow.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task AddDriver(DriverEntity model);
        Task UpdateDriver(DriverEntity model);
        Task<IEnumerable<dynamic>> GetAllDrivers(long shopId);
        Task<dynamic> GetDriverById(long id);
        Task<dynamic> DriverLogin(string email, string password);
        Task ChangeDriverStatus(long id, int status);
        Task ChangeOnlineStatus(long id, int status);
        Task UpdateLocation(long id, string latitude, string longitude);
        Task UpdateToken(long id, string token);
        Task<dynamic> GetDriverOrders(string orderId);
        Task<dynamic> GetDriverProfile(long id);
        Task AddDocument(DriverDocumentEntity model);
        Task UpdateDocument(DriverDocumentEntity model);
        Task<dynamic> GetDocuments(long driverId);
        Task DeleteDriverDocument(long id);
        Task AddVehicle(DriverVehicleEntity model);
        Task UpdateVehicle(DriverVehicleEntity model);
        Task AddBank(DriverBankEntity model);
        Task UpdateBank(DriverBankEntity model);
        Task AddTiming(DriverTimingEntity model);
        Task UpdateTiming(DriverTimingEntity model);
        Task<dynamic> GetTiming(long driverId);
        Task ChangePassword(long driverId, string oldPassword, string newPassword);
        Task<dynamic> DriverExists(string email);
        Task<dynamic> DriverExistsForShop(string email, long shopId);
        Task<dynamic> GetDriverReport(long driverId);
        Task<dynamic> GetPendingDrivers();
        Task UpdatePendingStatus(long id, int status);
        Task AssignOrder(DriverOrderAssignEntity model);
        
    }
}