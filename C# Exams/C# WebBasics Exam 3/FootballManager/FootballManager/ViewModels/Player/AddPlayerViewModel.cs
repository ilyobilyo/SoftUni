using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Player
{
    public class AddPlayerViewModel
    {
        [StringLength(80, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Position { get; set; }

        [Range(0, 10)]
        public byte Speed { get; set; }

        [Range(0, 10)]
        public byte Endurance { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }
    }
}
