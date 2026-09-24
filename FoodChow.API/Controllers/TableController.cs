using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/table")]
    public class TableController : ControllerBase
    {
        private readonly TableService _service;
        private readonly ReservationService _reservationService;
        private readonly ReservationRequestService _requestService;

        public TableController(TableService service,ReservationService reservationService,ReservationRequestService requestService)
        {
            _service = service;
            _reservationService = reservationService;
            _requestService = requestService;
        }

       
        [HttpGet("shop/{shopId}")]
        public async Task<IActionResult> GetShopTables(long shopId)
        {
            return Ok(await _service.GetShopTables(shopId));
        }

        [HttpPost("shop")]
        public async Task<IActionResult> AddShopTable(ShopDineInTableEntity model)
        {
            await _service.AddShopTable(model);
            return Ok();
        }

        [HttpPut("shop")]
        public async Task<IActionResult> UpdateShopTable(ShopDineInTableEntity model)
        {
            await _service.UpdateShopTable(model);
            return Ok();
        }
        
        [HttpDelete("shop/{id}")]
        public async Task<IActionResult> DeleteShopTable(long id)
        {
            await _service.DeleteShopTable(id);
            return Ok();
        }

        [HttpGet("all/{shopId}")]
        public async Task<IActionResult> GetAll(long shopId)
        {
            return Ok(await _service.GetAll(shopId));
        }

        
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(long id, int status)
        {
            await _service.UpdateStatus(id, status);
            return Ok();
        }

        //[HttpGet("with-category/{shopId}")]
        //public async Task<IActionResult> GetWithCategory(long shopId)
        //{
        //    return Ok(await _service.GetWithCategory(shopId));
        //}

        [HttpGet("categories/{shopId}")]
        public async Task<IActionResult> GetCategories(long shopId)
        {
            var results = await _service.GetCategories(shopId);
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id,int shopId)
        {
            await _service.Delete(id,shopId);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id, long shopId)
        {
            await _service.Delete(id, shopId);
            return Ok();
        }

        

        //[HttpPost("request")]
        //public async Task<IActionResult> AddRequest(ReservationRequestEntity m)
        //{
        //    await _requestService.Add(m);
        //    return Ok();
        //}

        //[HttpGet("request/all/{shopId}")]
        //public async Task<IActionResult> GetAllRequests(long shopId)
        //{
        //    return Ok(await _requestService.GetAll(shopId));
        //}

        //[HttpGet("request/{id}")]
        //public async Task<IActionResult> GetRequest(long id)
        //{
        //    return Ok(await _requestService.Get(id));
        //}

        //[HttpPut("request/status")]
        //public async Task<IActionResult> UpdateRequestStatus(long id, int status)
        //{
        //    await _requestService.UpdateStatus(id, status);

        //    if (status == 1)
        //    {
        //        var req = await _requestService.Get(id);
        //        await _reservationService.CreateFromRequest(req);
        //    }

        //    return Ok();
        //}

        //[HttpDelete("request/{id}")]
        //public async Task<IActionResult> DeleteRequest(long id)
        //{
        //    await _requestService.Delete(id);
        //    return Ok();
        //}

     

        [HttpGet("reservations/{shopId}")]
        public async Task<IActionResult> GetReservations(long shopId)
        {
            return Ok(await _reservationService.GetAll(shopId));
        }

        [HttpGet("reservation/{id}")]
        public async Task<IActionResult> GetReservation(long id)
        {
            return Ok(await _reservationService.Get(id));
        }

        [HttpDelete("reservation/{id}")]
        public async Task<IActionResult> DeleteReservation(long id)
        {
            await _reservationService.Delete(id);
            return Ok();
        }

        [HttpPost("InsertPosTableCategory")]
        public async Task<IActionResult> InsertPosTableCategory(
    string categoryName,
    int status,
    long shopId)
        {
            return Ok(await _service.InsertPosTableCategory(
                categoryName,
                status,
                shopId));
        }

        [HttpPost("InsertPosTableEntryCategoryWise")]
        public async Task<IActionResult> InsertPosTableEntryCategoryWise(
            long categoryId,
            string tableName,
            int status,
            string noOfPeople,
            long shopId,
            string businessType)
        {
            return Ok(await _service.InsertPosTableEntryCategoryWise(
                categoryId,
                tableName,
                status,
                noOfPeople,
                shopId,
                businessType));
        }

        [HttpPut("UpdatePosTableCategoryName")]
        public async Task<IActionResult> UpdatePosTableCategoryName(
            long id,
            string categoryName)
        {
            await _service.UpdatePosTableCategoryName(id, categoryName);
            return Ok();
        }

        [HttpPut("UpdatePosTableEntry")]
        public async Task<IActionResult> UpdatePosTableEntry(
            long id,
            long categoryId,
            string tableName,
            int status,
            string noOfPeople,
            string businessType)
        {
            await _service.UpdatePosTableEntry(
                id,
                categoryId,
                tableName,
                status,
                noOfPeople,
                businessType);

            return Ok();
        }

        [HttpDelete("DeletePosTableCategory")]
        public async Task<IActionResult> DeletePosTableCategory(long id)
        {
            await _service.DeletePosTableCategory(id);
            return Ok();
        }

        [HttpDelete("DeletePosTableEntry")]
        public async Task<IActionResult> DeletePosTableEntry(long id)
        {
            await _service.DeletePosTableEntry(id);
            return Ok();
        }

        [HttpGet("GetAllTableListWithCategories")]
        public async Task<IActionResult> GetAllTableListWithCategories(long shopId)
        {
            return Ok(await _service.GetAllTableListWithCategories(shopId));
        }

        [HttpPost("addTablesInBulk")]
        public async Task<IActionResult> AddTablesInBulk(
            long shopId,
            string prefix,
            int count,
            int noOfSeat)
        {
            await _service.AddTablesInBulk(
                shopId,
                prefix,
                count,
                noOfSeat);

            return Ok();
        }


    }
}
