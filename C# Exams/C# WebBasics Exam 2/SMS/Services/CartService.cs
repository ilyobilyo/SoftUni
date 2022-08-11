using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Cart;
using SMS.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<CartViewModel> AddProduct(string userId, string productId)
        {
            var user = repo.All<User>()
                .Where(x => x.Id == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefault();

            var product = repo.All<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefault();

            user.Cart.Products.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }

            return user
                .Cart
                .Products
                .Select(x => new CartViewModel
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2")
                });
        }

        public void BuyProducts(string id)
        {
            var user = repo.All<User>()
                .Where(x => x.Id == id)
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefault();

            user.Cart.Products.Clear();

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<CartViewModel> GetProducts(string userId)
        {
            var user = repo.All<User>()
                .Where(x => x.Id == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefault();

            return user
                .Cart
                .Products
                .Select(x => new CartViewModel
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2")
                });
        }
    }
}
