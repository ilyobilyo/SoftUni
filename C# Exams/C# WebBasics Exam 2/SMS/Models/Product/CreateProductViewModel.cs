using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Product
{
    public class CreateProductViewModel
    {
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 4 and max length 20 (required)
//•	Has Price – a decimal (in range 0.05 – 1000)
//•	Has a Cart – a Cart object
