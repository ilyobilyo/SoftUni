using System.ComponentModel.DataAnnotations;

namespace ReadApiDemo.Models
{
	public class CreateProductModel
	{
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
