using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
namespace FoodChow.Application.Services
{
    public class DriverService
    {
        private readonly IDriverRepository _repo;
        public DriverService(IDriverRepository repo)
        {
            _repo = repo;
        }
        public async Task AddDriver(DriverEntity model) => await
        _repo.AddDriver(model);
        public async Task UpdateDriver(DriverEntity model) => await
        _repo.UpdateDriver(model);
        public async Task<IEnumerable<dynamic>> GetAllDrivers(long shopId) =>
        await _repo.GetAllDrivers(shopId);
        public async Task<dynamic> GetDriverById(long id) => await
        _repo.GetDriverById(id);
        public async Task<dynamic> DriverLogin(string email, string password)
        => await _repo.DriverLogin(email, password);
        public async Task ChangeDriverStatus(long id, int status) => await
        _repo.ChangeDriverStatus(id, status);
        public async Task ChangeOnlineStatus(long id, int status) => await
        _repo.ChangeOnlineStatus(id, status);
        public async Task UpdateLocation(long id, string latitude, string
        longitude) => await _repo.UpdateLocation(id, latitude, longitude);
        public async Task UpdateToken(long id, string token) => await
        _repo.UpdateToken(id, token);
        public async Task AssignOrder(DriverOrderAssignEntity model)
        => await _repo.AssignOrder(model);
        public async Task<dynamic> GetDriverOrders(string orderId)
        => await _repo.GetDriverOrders(orderId);
        public async Task<dynamic> GetDriverProfile(long id) => await
        _repo.GetDriverProfile(id);
        public async Task AddDocument(DriverDocumentEntity model) => await
        _repo.AddDocument(model);
        public async Task UpdateDocument(DriverDocumentEntity model) => await
        _repo.UpdateDocument(model);
        public async Task<dynamic> GetDocuments(long driverId) => await
        _repo.GetDocuments(driverId);
        public async Task DeleteDriverDocument(long id) => await
        _repo.DeleteDriverDocument(id);
        public async Task AddVehicle(DriverVehicleEntity model) => await
        _repo.AddVehicle(model);
        public async Task UpdateVehicle(DriverVehicleEntity model) => await
        _repo.UpdateVehicle(model);
        public async Task AddBank(DriverBankEntity model) => await
        _repo.AddBank(model);
        public async Task UpdateBank(DriverBankEntity model) => await
        _repo.UpdateBank(model);
        public async Task AddTiming(DriverTimingEntity model) => await
        _repo.AddTiming(model);
        public async Task UpdateTiming(DriverTimingEntity model) => await
        _repo.UpdateTiming(model);
        public async Task<dynamic> GetTiming(long driverId) => await
        _repo.GetTiming(driverId);
        public async Task ChangePassword(long driverId, string oldPassword,
        string newPassword)
        => await _repo.ChangePassword(driverId, oldPassword, newPassword);
        public async Task<dynamic> DriverExists(string email)
        => await _repo.DriverExists(email);
        public async Task<dynamic> DriverExistsForShop(string email, long
        shopId)
        => await _repo.DriverExistsForShop(email, shopId);
        public async Task<dynamic> GetDriverReport(long driverId)
        => await _repo.GetDriverReport(driverId);
        public async Task<dynamic> GetPendingDrivers()
            => await _repo.GetPendingDrivers();
        public async Task UpdatePendingStatus(long id, int status)
        => await _repo.UpdatePendingStatus(id, status);
    }
}
