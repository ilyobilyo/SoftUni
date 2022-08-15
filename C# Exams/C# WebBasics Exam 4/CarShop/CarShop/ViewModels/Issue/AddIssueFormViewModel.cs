using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.Issue
{
    public class AddIssueFormViewModel
    {
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "{0} must be minimum {1} characters long")]
        public string Description { get; set; }

        [Required]
        public string CarId { get; set; }
    }
}

