using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Cart = new Cart();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        [MaxLength(36)]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
