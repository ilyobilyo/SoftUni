using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid().ToString();
            Products = new List<Product>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
