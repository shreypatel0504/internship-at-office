using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodChow.Domain.Entities
{
    [Table("master_reason")]
    public class MasterReason
    {
        [Key]
        [Column("reason_id")]
        public int ReasonId { get; set; }

        [Required]
        [Column("reason_name")]
        [MaxLength(255)]
        public string ReasonName { get; set; } = string.Empty;

        [Column("reason_description")]
        public string? ReasonDescription { get; set; }

        [Column("status")]
        public bool Status { get; set; } = true;

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }
}