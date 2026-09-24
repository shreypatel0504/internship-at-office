using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly MySqlDalc _dalc;

        public OfferRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task SaveOffer(OfferEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "RMS_SaveRestaurantOffer",
                new
                {
                    shop_id = model.shop_id,

                    discount = model.discount,

                    title = model.title,

                    description = model.description,

                    type = model.type,

                    start_date = model.start_date,

                    end_date = model.end_date,

                    total = model.total,

                    claimed = model.claimed,

                    redeemed = model.redeemed,

                    available = model.available,

                    status = model.status,

                    created_date = DateTime.Now,

                    updated_date = DateTime.Now
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task SaveOfferNew(OfferEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "RMS_SaveRestaurantOfferNew",
                new
                {
                    shop_id = model.shop_id,

                    discount = model.discount,

                    title = model.title,

                    description = model.description,

                    type = model.type,

                    start_date = model.start_date,

                    end_date = model.end_date,

                    total = model.total,

                    claimed = model.claimed,

                    redeemed = model.redeemed,

                    available = model.available,

                    status = model.status,

                    offer_order_method = model.offer_order_method,

                    start_date_str = model.start_date_str,

                    end_date_str = model.end_date_str,

                    start_time = model.start_time,

                    end_time = model.end_time,

                    term_condition = model.term_condition,

                    created_date = DateTime.Now,

                    updated_date = DateTime.Now,

                    days = model.days
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UploadOfferImage(long id, string image_name)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateOfferImage",
                new
                {
                    id = id,
                    image_name = image_name
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetAllOffers(
        long shopId,
        int flag,
        string currtime)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "RMS_GetAllRestaurantsOffers",
                new
                {
                    shop_id = shopId,
                    flag = flag,
                    currtime = currtime
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task ChangeOfferStatus(long id, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_ChangeOfferStatus",
                new
                {
                    p_id = id,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateOffer(OfferEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "RMS_UpdateRestaurantOffer",
                new
                {
                    id = model.id,

                    shop_id = model.shop_id,

                    discount = model.discount,

                    title = model.title,

                    description = model.description,

                    type = model.type,

                    start_date = model.start_date,

                    end_date = model.end_date,

                    total = model.total,

                    claimed = model.claimed,

                    redeemed = model.redeemed,

                    available = model.available,

                    status = model.status,

                    updated_date = DateTime.Now
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateOfferNew(OfferEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "RMS_UpdateRestaurantOfferNew",
                new
                {
                    id = model.id,

                    shop_id = model.shop_id,

                    discount = model.discount,

                    title = model.title,

                    description = model.description,

                    type = model.type,

                    start_date = model.start_date,

                    end_date = model.end_date,

                    total = model.total,

                    claimed = model.claimed,

                    redeemed = model.redeemed,

                    available = model.available,

                    status = model.status,

                    offer_order_method = model.offer_order_method,

                    start_date_str = model.start_date_str,

                    end_date_str = model.end_date_str,

                    start_time = model.start_time,

                    end_time = model.end_time,

                    term_condition = model.term_condition,

                    updated_date = DateTime.Now,

                    days = model.days
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<dynamic> GetLastOfferImage(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "RMS_GetRestaurantImageForOffer",
                new
                {
                    shop_id = shopId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UploadRestaurantImage(long shopId, string image)
        {
            var existing = await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
                "USP_GetShopOverview",
                new
                {
                    shop_id = shopId
                },
                commandType: CommandType.StoredProcedure);

            if (existing != null)
            {
                await _dalc.CreateConnection().ExecuteAsync(
                    "USP_UpdateFoodShopOverview",
                    new
                    {
                        shop_id = shopId,
                        image = image
                    },
                    commandType: CommandType.StoredProcedure);
            }
            else
            {
                await _dalc.CreateConnection().ExecuteAsync(
                    "USP_AddToFoodShopOverview",
                    new
                    {
                        shop_id = shopId,
                        image = image
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<dynamic> GetOfferById(long id)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync(
                "USP_GetOfferById",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteOffer(long id)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteOffer",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetActiveOffers(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetActiveOffers",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetExpiredOffers(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetExpiredOffers",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetOffersByDate(long shopId, DateTime start, DateTime end)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetOffersByDate",
                new
                {
                    p_shop_id = shopId,
                    p_start = start,
                    p_end = end
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOfferTiming(long id,DateTime startDateTime,DateTime endDateTime,DateTime startDate,DateTime endDate,string startTime,string endTime,string days)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateOfferTiming",
                new
                {
                    p_id = id,
                    p_start_datetime = startDateTime,
                    p_end_datetime = endDateTime,
                    p_start_date = startDate,
                    p_end_date = endDate,
                    p_start_time = startTime,
                    p_end_time = endTime,
                    p_days = days
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetAllOffersNew(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "RMS_GetAllRestaurantsOffers",
                new
                {
                    shop_id = shopId,
                    flag = 0,
                    currtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}