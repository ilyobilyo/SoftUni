using Library.Contracts;
using Library.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await bookService.GetAllAsync();

            return View(books);
        }

        public async Task<IActionResult> AddToCollection(int bookId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var isAddedToCollection = await bookService.AddMovieToCollectionAsync(bookId, userId);

            if (!isAddedToCollection)
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel();

            var categories = await bookService.GetAllCategories();

            model.Categories = categories.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isAdded = await bookService.AddBookAsync(model);

            if (!isAdded)
            {
                return View(model);
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var myBooks = await bookService.GetMyBooks(userId);

                return View(myBooks);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            bool isRemoved = await bookService.RemoveFromCollection(bookId, userId);

            if (!isRemoved)
            {
                return RedirectToAction(nameof(Mine));
            }

            return RedirectToAction(nameof(Mine));
        }
    }
}
