using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.Entities
{
    public class Offer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public required string Code { get; set; } = string.Empty;

        public required string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public decimal? DiscountPercentage { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be a positive value.")]
        public decimal? DiscountAmount { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required Status Status { get; set; }
    }
}
