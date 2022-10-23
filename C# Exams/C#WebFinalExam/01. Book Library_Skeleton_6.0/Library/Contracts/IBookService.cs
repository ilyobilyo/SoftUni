using Library.Models.Books;
using Library.Models.Category;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllAsync();
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        Task<bool> AddBookAsync(AddBookViewModel model);
        Task<bool> AddMovieToCollectionAsync(int bookId, string? userId);
        Task<IEnumerable<MyBookViewModel>> GetMyBooks(string? userId);
        Task<bool> RemoveFromCollection(int bookId, string? userId);
    }
}
