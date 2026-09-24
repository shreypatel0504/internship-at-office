using System.ComponentModel.DataAnnotations;

namespace FoodChow.Application.DTOs
{
    public class UpdateMasterReasonDto
    {
        [Required]
        public int ReasonId { get; set; }

        [Required]
        public string ReasonName { get; set; } = string.Empty;

        public string? ReasonDescription { get; set; }

        public bool Status { get; set; }
    }
}   