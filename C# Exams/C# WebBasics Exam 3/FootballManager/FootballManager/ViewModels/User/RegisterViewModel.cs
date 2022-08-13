using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.User
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
