using Library.Contracts;
using Library.Data.Common;
using Library.Data.Models;
using Library.Models.Books;
using Library.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repo;

        public BookService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
            };

            try
            {
                await repo.AddAsync(book);
                await repo.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddMovieToCollectionAsync(int bookId, string? userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Include(x => x.ApplicationUsersBooks)
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            var book = await repo.All<Book>()
                .FirstOrDefaultAsync(x => x.Id == bookId);

            if (user == null || book == null)
            {
                return false;
            }

            if (!user.ApplicationUsersBooks.Any(x => x.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUser = user,
                    ApplicationUserId = userId,
                    Book = book
                });

                await repo.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAsync()
        {
            var books = await repo.All<Book>()
                .Include(x => x.Category)
                .ToListAsync();

            return books
                .Select(x => new AllBookViewModel()
            {
                Author = x.Author,
                Category = x.Category.Name,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Rating = x.Rating,
                Title = x.Title,
            });
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var categories = await repo.All<Category>()
                .ToListAsync();

            return categories
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                });
        }

        public async Task<IEnumerable<MyBookViewModel>> GetMyBooks(string? userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .ThenInclude(x => x.Book)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.ApplicationUsersBooks
                .Select(x => new MyBookViewModel()
                {
                    Author = x.Book.Author,
                    Category = x.Book.Category.Name,
                    Description = x.Book.Description,
                    Id = x.Book.Id,
                    ImageUrl = x.Book.ImageUrl,
                    Rating = x.Book.Rating,
                    Title = x.Book.Title
                });
        }

        public async Task<bool> RemoveFromCollection(int bookId, string? userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            var book = user.ApplicationUsersBooks.FirstOrDefault(x => x.BookId == bookId);

            if (book == null)
            {
                return false;
            }

            user.ApplicationUsersBooks.Remove(book);

            await repo.SaveChangesAsync();

            return true;
        }
    }
}
