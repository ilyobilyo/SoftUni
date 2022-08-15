using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.Car
{
    public class AddCarViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Model { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "{0} is required")]
        public int Year { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]{2} [\d]{4} [A-Z]{2}", ErrorMessage = "{0} must be valid {0}")]
        public string PlateNumber { get; set; }
    }
}
