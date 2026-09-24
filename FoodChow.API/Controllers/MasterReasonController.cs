using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterReasonController : ControllerBase
    {
        private readonly MasterReasonService _service;

        public MasterReasonController(MasterReasonService service)
        {
            _service = service;
        }

        // Get All
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAllAsync();

                return Ok(new
                {
                    success = true,
                    message = "Master reason list fetched successfully",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // Get By Id
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long reasonId)
        {
            try
            {
                var data = await _service.GetByIdAsync(reasonId);

                if (data == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Record not found"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Record fetched successfully",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateMasterReasonDto dto)
        {
            Console.WriteLine("🔥 NEW CODE EXECUTING");

            try
            {
                var id = await _service.AddAsync(dto);

                return Ok(new
                {
                    success = true,
                    message = "Master reason added successfully",
                    insertedId = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateMasterReasonDto dto)
        {
            try
            {
                var result = await _service.UpdateAsync(dto);

                return Ok(new
                {
                    success = result > 0,
                    message = result > 0
                        ? "Master reason updated successfully"
                        : "Update failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long reasonId)
        {
            try
            {
                var result = await _service.DeleteAsync(reasonId);

                return Ok(new
                {
                    success = result,
                    message = result
                        ? "Master reason deleted successfully"
                        : "Delete failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}