namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PlayInputModel[]),
                new XmlRootAttribute("Plays"));

            var reader = new StringReader(xmlString);

            var playDtos = serializer.Deserialize(reader) as PlayInputModel[];

            var plays = new List<Play>();

            var sb = new StringBuilder();

            foreach (var dto in playDtos)
            {
                var isGenreValid = Enum.TryParse<Genre>(dto.Genre, out var validGenre);

                var isTimeSpanValid = TimeSpan.TryParseExact(dto.Duration, "c", CultureInfo.InvariantCulture, out var duration);

                var minTimeSpan = new TimeSpan(1, 0, 0);

                if (!IsValid(dto) || !isGenreValid
                    || !isTimeSpanValid || duration < minTimeSpan)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = dto.Title,
                    Duration = duration,
                    Rating = dto.Rating,
                    Genre = validGenre,
                    Description = dto.Description,
                    Screenwriter = dto.Screenwriter,
                };

                plays.Add(play);

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CastInputModel[]),
                new XmlRootAttribute("Casts"));

            var reader = new StringReader(xmlString);

            var castDtos = serializer.Deserialize(reader) as CastInputModel[];

            var casts = new List<Cast>();

            var sb = new StringBuilder();

            foreach (var dto in castDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = dto.FullName,
                    IsMainCharacter = dto.IsMainCharacter,
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId,
                };

                casts.Add(cast);

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatreDto = JsonConvert.DeserializeObject<List<TheatreInputModel>>(jsonString);

            var sb = new StringBuilder();

            var theatres = new List<Theatre>();

            foreach (var dto in theatreDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.Director,
                };

                foreach (var ticketDto in dto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };

                    theatre.Tickets.Add(ticket);
                }

                theatres.Add(theatre);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.AddRange(theatres);

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
