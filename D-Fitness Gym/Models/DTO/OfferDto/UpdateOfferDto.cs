using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.OfferDto
{
    public class UpdateOfferDto
    {
        [StringLength(50, ErrorMessage = "Offer code cannot exceed 50 characters.")]
        public string? Code { get; set; }

        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public decimal? DiscountPercentage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be positive.")]
        public decimal? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Status? Status { get; set; }

        // Validation rule: only one discount allowed
        public bool IsValidDiscount() =>
            !(DiscountPercentage.HasValue && DiscountAmount.HasValue);
    }
}
