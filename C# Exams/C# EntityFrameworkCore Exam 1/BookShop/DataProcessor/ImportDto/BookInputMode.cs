﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookInputMode
    {
        [XmlElement("Name")]
        [MinLength(3)]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Range(1,3)]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        [Range(50,5000)]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}

//< Book >
//    < Name > Hairy Torchwood </ Name >
//    < Genre > 3 </ Genre >
//    < Price > 41.99 </ Price >
//    < Pages > 3013 </ Pages >
//    < PublishedOn > 01 / 13 / 2013 </ PublishedOn >
//  </ Book >


