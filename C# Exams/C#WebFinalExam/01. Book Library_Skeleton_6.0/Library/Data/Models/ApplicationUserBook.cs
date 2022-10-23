using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class ApplicationUserBook
    {
        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
