namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ImportDto;
    using System.Linq;
    using Newtonsoft.Json;
    using Artillery.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CountryInputModel[]),
                new XmlRootAttribute("Countries"));

            var reader = new StringReader(xmlString);

            var countryDtos = serializer.Deserialize(reader) as CountryInputModel[];

            var countries = new List<Country>();

            var sb = new StringBuilder();

            foreach (var dto in countryDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = dto.CountryName,
                    ArmySize = dto.ArmySize,
                };

                countries.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ManufacturerInputModel[]),
                new XmlRootAttribute("Manufacturers"));

            var reader = new StringReader(xmlString);

            var manufacturerDtos = serializer.Deserialize(reader) as ManufacturerInputModel[];

            var manufacturers = new List<Manufacturer>();

            var sb = new StringBuilder();

            foreach (var dto in manufacturerDtos)
            {
                if (!IsValid(dto)
                    || manufacturers.Any(x => x.ManufacturerName == dto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var foundedArray = dto.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var countryArray = foundedArray.TakeLast(2).ToArray();

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = dto.ManufacturerName,
                    Founded = dto.Founded,
                };

                manufacturers.Add(manufacturer);

                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", countryArray)));
            }

            context.Manufacturers.AddRange(manufacturers);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ShellInputModel[]),
                new XmlRootAttribute("Shells"));

            var reader = new StringReader(xmlString);

            var shellDtos = serializer.Deserialize(reader) as ShellInputModel[];

            var shells = new List<Shell>();

            var sb = new StringBuilder();

            foreach (var dto in shellDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = dto.ShellWeight,
                    Caliber = dto.Caliber,
                };

                shells.Add(shell);

                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var gunDtos = JsonConvert.DeserializeObject<GunInputModel[]>(jsonString);

            var guns = new List<Gun>();

            var sb = new StringBuilder();

            foreach (var dto in gunDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGunTypeValid = Enum.TryParse<GunType>(dto.GunType, out var validGunType);

                if (!isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = dto.ManufacturerId,
                    GunWeight = dto.GunWeight,
                    BarrelLength = dto.BarrelLength,
                    NumberBuild = dto.NumberBuild,
                    Range = dto.Range,
                    GunType = validGunType,
                    ShellId = dto.ShellId,
                };

                foreach (var countryDto in dto.Countries)
                {
                    var country = context.Countries.FirstOrDefault(x => x.Id == countryDto.Id);

                    if (country == null)
                    {
                        continue;
                    }

                    gun.CountriesGuns.Add(new CountryGun
                    {
                        Gun = gun,
                        Country = country,
                    });
                }

                guns.Add(gun);

                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(guns);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
