using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController(IPrinterRepository repo, MySqlDalc dalc) : ControllerBase
    {
        // ✅ 1 - GET ALL
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] long shopId)
        {
            try
            {
                var result = await repo.GetAllAsync(shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = result });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 2 - GET BY ID
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long id, [FromQuery] long shopId)
        {
            try
            {
                var result = await repo.GetByIdAsync(id, shopId);
                if (result is null)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Printer not found.", Data = null });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = result });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 3 - ADD
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddPrinterDto dto)
        {
            try
            {
                var newId = await repo.AddAsync(dto);
                return Ok(new ApiResponse<object> { Success = true, Message = "Printer added successfully", Data = newId });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 4 - UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePrinterDto dto)
        {
            try
            {
                await repo.UpdateAsync(dto);
                return Ok(new ApiResponse<object> { Success = true, Message = "Printer updated successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 5 - DELETE
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] long shopId)
        {
            try
            {
                await repo.DeleteAsync(id, shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Printer deleted successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 6 - GET All Templates
        [HttpGet("templates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            try
            {
                var result = await dalc.ExecuteSpListAsync<dynamic>("USPGetAllTemplates");
                if (result is null || !result.Any())
                    return NotFound("No templates found.");

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = result });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 7 - GET Template By Id
        [HttpGet("get-template-by-id")]
        public async Task<IActionResult> GetTemplateById([FromQuery] int shopId, [FromQuery] int templateId)
        {
            try
            {
                var result = await dalc.ExecuteSpListAsync<dynamic>(
                    "USPGetPrintingTemplate",
                    new { templateId, shop_id = shopId });

                if (result is null || !result.Any())
                    return NotFound("Template not found.");

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = result });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 8 - GET Printing Template Sorted
        [HttpGet("GetPrintingTemplateSorted")]
        public async Task<IActionResult> GetPrintingTemplateSorted([FromQuery] int templateId, [FromQuery] int shopId)
        {
            try
            {
                var result = await dalc.ExecuteSpListAsync<dynamic>(
                    "USPGetPrintingTemplate",
                    new { templateId, shop_id = shopId });

                if (result is null || !result.Any())
                    return Ok(new ApiResponse<object> { Success = true, Message = "No data found.", Data = null });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = result });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 9 - UPDATE Template Fields
        [HttpPut("update-template-fields")]
        public async Task<IActionResult> UpdateTemplateFields(
            [FromQuery] int shopId,
            [FromQuery] int templateId,
            [FromQuery] int existingFieldId,
            [FromBody] UpdateTemplateDto template)      
        {
            try
            {
                foreach (var field in template.FieldDetails)
                {
                    if (field.FieldId > 0)
                    {
                        await dalc.ExecuteSpNonQueryAsync("UpdateFieldDetails", new
                        {
                            shop_id = shopId,
                            template_id = templateId,
                            section_id = field.SectionId,
                            field_id = existingFieldId,
                            label_name = field.LabelName ?? string.Empty,
                            tag_name = field.TagName ?? string.Empty,
                            position = field.Position,
                            alignment = field.Alignment ?? string.Empty,
                            font_size = field.FontSize ?? string.Empty,
                            font_style = field.FontStyle ?? string.Empty,
                            width = field.Width ?? string.Empty,
                            default_value = field.DefaultValue ?? string.Empty
                        });
                    }
                    else
                    {
                        await dalc.ExecuteSpNonQueryAsync("InsertFieldDetails", new
                        {
                            shop_id = shopId,
                            template_id = templateId,
                            section_id = field.SectionId,
                            column_no = field.Column,
                            position = field.Position,
                            label_name = field.LabelName ?? string.Empty,
                            tag_name = field.TagName ?? string.Empty,
                            alignment = field.Alignment ?? string.Empty,
                            font_size = field.FontSize ?? string.Empty,
                            font_style = field.FontStyle ?? string.Empty,
                            width = field.Width ?? string.Empty,
                            default_value = field.DefaultValue ?? string.Empty,
                            display_position = field.DisplayPosition
                        });
                    }
                }

                return Ok(new ApiResponse<object> { Success = true, Message = "Template fields updated successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 10 - DELETE Field
        [HttpDelete("delete-field")]
        public async Task<IActionResult> DeleteField([FromQuery] int shopId, [FromQuery] int fieldId)
        {
            try
            {
                await dalc.ExecuteSpNonQueryAsync("USPDeleteField",
                    new { field_id = fieldId, shop_id = shopId });

                return Ok(new ApiResponse<object> { Success = true, Message = "Field deleted successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 11 - UPDATE Paper Size
        [HttpGet("UpdatePaperSize")]
        public async Task<IActionResult> UpdatePaperSize([FromQuery] int template_id, [FromQuery] string paper_size)
        {
            try
            {
                await dalc.ExecuteSpNonQueryAsync("USP_update_printer_papersize",
                    new { template_id, paper_size });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 12 - UPDATE Field Positions
        [HttpPost("update-positions")]
        public async Task<IActionResult> UpdateFieldPositions([FromBody] FieldPositionUpdateDto request)
        {
            try
            {
                foreach (var fieldId in request.FieldIds)
                {
                    await dalc.ExecuteSpNonQueryAsync("updateprintingdisplayposition",
                        new { pos = request.DisplayPosition, id = fieldId });
                }

                return Ok(new ApiResponse<object> { Success = true, Message = "Display position updated successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 13 - GET Printing Generic Field
        [HttpGet("GetPrintingGenericField")]
        public async Task<IActionResult> GetPrintingGenericField([FromQuery] int template_id)
        {
            try
            {
                var result = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetPrintingGenericField",
                    new { template_id });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = result.FirstOrDefault()
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

    }
}