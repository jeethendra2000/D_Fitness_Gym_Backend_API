using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.OfferDto
{
    public class CreateOfferDto
    {
        [Required(ErrorMessage = "Offer code is required.")]
        [StringLength(50, ErrorMessage = "Offer code cannot exceed 50 characters.")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public decimal? DiscountPercentage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be positive.")]
        public decimal? DiscountAmount { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required]
        public Status Status { get; set; }

        // Cross-field validation (Choose ONLY one discount type)
        public bool IsValidDiscount() => !(DiscountPercentage.HasValue && DiscountAmount.HasValue);
    }
}
