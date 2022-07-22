namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                    .OrderByDescending(s => s.Book.Price)
                    .Select(s => new
                    {
                        BookName = s.Book.Name,
                        BookPrice = s.Book.Price.ToString("F2")
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Books.Length)
                .ThenBy(x => x.AuthorName)
                .ToArray();

            var json = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Data.Models.Enums.Genre.Science)
                .Select(x => new BookOutputModel
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.Date)
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(BookOutputModel[]),
                new XmlRootAttribute("Books"));

            var writer = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            serializer.Serialize(writer, books, nameSpace);

            return writer.ToString();
        }
    }
}