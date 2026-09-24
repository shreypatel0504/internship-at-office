using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;
using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly MySqlDalc _dalc;
        public DriverRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }
        public async Task AddDriver(DriverEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddFoodDriverDetailWD",
                new
                {
                    shop_id = model.shop_id,
                    first_name = model.first_name,
                    last_name = model.last_name,
                    emailid = model.emailid,
                    mobile_number = model.mobile_number,
                    date_of_birth = model.date_of_birth,
                    gender = model.gender,
                    city = model.city,
                    state = model.state,
                    country = model.country,
                    status = model.status,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task UpdateDriver(DriverEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateFoodDriverDetailWD",
                new
                {
                    driver_id = model.id,
                    first_name = model.first_name,
                    last_name = model.last_name,
                    emailid = model.emailid,
                    mobile_number = model.mobile_number,
                    date_of_birth = model.date_of_birth,
                    gender = model.gender,
                    city = model.city,
                    state = model.state,
                    country = model.country,
                    created_date = model.created_date,
                    updated_date = DateTime.Now
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<dynamic>> GetAllDrivers(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
            "USP_GetAllDriverListWD",
            new { shop_id = shopId },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetDriverById(long id)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
            "USP_GetAllDetailsForDriverWD",
            new { driver_id = id },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> DriverLogin(string email, string password)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
            "USP_DriverLoginWD",
            new
            {
                emailid = email,
                password = password
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task ChangeDriverStatus(long id, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_ActiveDeActiveFoodDriverWD",
            new { driver_id = id, status = status },
            commandType: CommandType.StoredProcedure);
        }
        public async Task ChangeOnlineStatus(long id, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_ChangeDriverOnlineStatus",
            new { driver_id = id, online_status = status },
            commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateLocation(long id, string latitude, string
        longitude)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateDriverLocation",
            new
            {
                driver_id = id,
                latitude = latitude,
                longitude = longitude
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateToken(long id, string token)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateDriverTokenForNotification",
            new
            {
                driver_id = id,
                token = token
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task AssignOrder(DriverOrderAssignEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddDriverOrderAssignWD",
                new
                {
                    shopid = model.shopid,
                    order_id = model.order_id,
                    driver_id = model.driver_id,
                    status = model.status,
                    order_bind_date = model.order_bind_date,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<dynamic> GetDriverOrders(string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetOrderBindingDetailsDriverWD",
                new{order_id = orderId},
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<dynamic> GetDriverProfile(long id)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
            "USP_GetDriverProfile",
            new { driver_id = id },
            commandType: CommandType.StoredProcedure);
        }
        public async Task AddDocument(DriverDocumentEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_AddFoodDriverDocumentWD",
            new
            {
                driver_id = model.driver_id,
                document_name = model.document_name,
                document_file = model.document_file
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateDocument(DriverDocumentEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateFoodDriverDocumentWD",
            new
            {
                id = model.id,
                document_name = model.document_name,
                document_file = model.document_file
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetDocuments(long driverId)
        {
            return await _dalc.CreateConnection().QueryAsync(
            "USP_GetDriverDocumentDetailsWD",
            new { driver_id = driverId },
            commandType: CommandType.StoredProcedure);
        }
        public async Task DeleteDriverDocument(long id)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_DeleteDriverDocumentWD",
            new { id = id },
            commandType: CommandType.StoredProcedure);
        }
        public async Task AddVehicle(DriverVehicleEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_AddFoodDriverVehicalDetailsWD",
            new
            {
                driver_id = model.driver_id,
                vehicle_type = model.vehicle_type,
                vehicle_no = model.vehicle_no,
                vehicle_name = model.vehicle_name
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateVehicle(DriverVehicleEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateFoodDriverVehicalWD",
            new
            {
                id = model.id,
                vehicle_type = model.vehicle_type,
                vehicle_no = model.vehicle_no,
                vehicle_name = model.vehicle_name
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task AddBank(DriverBankEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_AddFoodDriverBankDetailsWD",
            new
            {
                driver_id = model.driver_id,
                account_name = model.account_name,
                account_number = model.account_number,
                ifsc_code = model.ifsc_code,
                bank_name = model.bank_name
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateBank(DriverBankEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateFoodDriverBankDetailsWD",
            new
            {
                id = model.id,
                account_name = model.account_name,
                account_number = model.account_number,
                ifsc_code = model.ifsc_code,
                bank_name = model.bank_name
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task AddTiming(DriverTimingEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_AddFoodDriverTimingWD",
            new
            {
                driver_id = model.driver_id,
                day_name = model.day_name,
                start_time = model.start_time,
                end_time = model.end_time
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateTiming(DriverTimingEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateFoodDriverTimingWD",
            new
            {
                id = model.id,
                day_name = model.day_name,
                start_time = model.start_time,
                end_time = model.end_time
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetTiming(long driverId)
        {
            return await _dalc.CreateConnection().QueryAsync(
"USP_GetFoodDriverTimingWD",
new { driver_id = driverId },
commandType: CommandType.StoredProcedure);
        }
        public async Task ChangePassword(long driverId, string oldPassword,
        string newPassword)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_DriverChangePasswordWD",
            new
            {
                driver_id = driverId,
                old_password = oldPassword,
                new_password = newPassword
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> DriverExists(string email)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
            "USP_CheckDriverExistsOrNot",
            new { email = email },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> DriverExistsForShop(string email, long
        shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
            "USP_CheckDriverExistsOrNotForShop",
            new
            {
                email = email,
                shop_id = shopId
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetDriverReport(long driverId)
        {
            return await _dalc.CreateConnection().QueryAsync(
            "USP_GetDriverOrderReportWD",
            new { driver_id = driverId },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetPendingDrivers()
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetPendingFoodChowDriversWD",
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task UpdatePendingStatus(long id, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdatePendinFoodChowDriverStatusWD",
            new
            {
                id = id,
                status = status
            },
            commandType: CommandType.StoredProcedure);
        }
    }
}
         
