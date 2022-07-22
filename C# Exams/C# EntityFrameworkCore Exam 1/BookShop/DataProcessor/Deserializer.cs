namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(BookInputMode[]),
                new XmlRootAttribute("Books"));

            var reader = new StringReader(xmlString);

            var bookDtos = serializer.Deserialize(reader) as BookInputMode[];

            var books = new List<Book>();

            foreach (var dto in bookDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var publishedOnDate = DateTime.ParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var book = new Book
                {
                    Name = dto.Name,
                    Genre = (Genre)dto.Genre,
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = publishedOnDate,
                };

                books.Add(book);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<List<AuthorImportModel>>(jsonString);

            var authors = new List<Author>();

            var sb = new StringBuilder();

            foreach (var dto in authorsDtos)
            {

                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isEmailInvalid = authors.FirstOrDefault(x => x.Email == dto.Email) != null;

                if (isEmailInvalid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Phone = dto.Phone,
                };


                foreach (var authorBook in dto.Books)
                {
                    var book = context.Books.Find(authorBook.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book,
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, ($"{author.FirstName} {author.LastName}"), author.AuthorsBooks.Count));
            }

            context.AddRange(authors);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}