﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.DataProcessor.ImportDto
{
    public class GunInputModel
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(100, 1350000)]
        public int GunWeight { get; set; }

        [Required]
        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; }

        [Required]
        public int ShellId { get; set; }


        public GunCountry[] Countries { get; set; }

    }

    public class GunCountry
    {
        public int? Id { get; set; }
    }
}
//{
//    "ManufacturerId": 14,
//    "GunWeight": 531616,
//    "BarrelLength": 6.86,
//    "NumberBuild": 287,
//    "Range": 120000,
//    "GunType": "Howitzer",
//    "ShellId": 41,
//    "Countries": [
//      { "Id": 86 },
//      { "Id": 57 },
//      { "Id": 64 },
//      { "Id": 74 },
//      { "Id": 58 }
////    ]
////  },

//•	Id – integer, Primary Key
//•	ManufacturerId – integer, foreign key (required)
//•	GunWeight– integer in range[100…1_350_000](required)
//•	BarrelLength – double in range[2.00….35.00](required)
//•	NumberBuild – integer
//•	Range – integer in range[1….100_000](required)
//•	GunType – enumeration of GunType, with possible values (Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
//•	ShellId – integer, foreign key(required)
//•	CountriesGuns – a collection of CountryGun
