using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.User
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "{0} must be valid email")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserType { get; set; }
    }
}
