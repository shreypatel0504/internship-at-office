using System.ComponentModel.DataAnnotations;

namespace FoodChow.Application.DTOs
{
    public class CreateMasterReasonDto
    {
        [Required]
        public string ReasonName { get; set; } = string.Empty;

        public string ReasonDescription { get; set; }

        public bool Status { get; set; } = true;
    }
}