using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(0.05, 1000)]
        public decimal Price { get; set; }

        [MaxLength(36)]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
