
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                    .Where(g => g.GunType == Data.Models.Enums.GunType.AntiAircraftGun)
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range",
                    })
                    .OrderByDescending(g => g.GunWeight)
                    .ToArray()
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            var json = JsonConvert.SerializeObject(shells, Formatting.Indented);

            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new GunOutputModel
                {
                    Manufactirer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                    .Where(s => s.Country.ArmySize > 4500000)
                    .Select(s => new CountryOutputModel
                    {
                        Country = s.Country.CountryName,
                        ArmySize = s.Country.ArmySize,
                    })
                    .OrderBy(s => s.ArmySize)
                    .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            var serializer = new XmlSerializer(typeof(GunOutputModel[]),
                new XmlRootAttribute("Guns"));

            var writer = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();

            nameSpace.Add("", "");

            serializer.Serialize(writer, guns, nameSpace);

            return writer.ToString().TrimEnd();
        }
    }
}
