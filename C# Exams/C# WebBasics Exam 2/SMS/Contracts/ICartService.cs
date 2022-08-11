using SMS.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface ICartService
    {
        IEnumerable<CartViewModel> AddProduct(string userId, string productId);
        IEnumerable<CartViewModel> GetProducts(string userId);
        void BuyProducts(string id);
    }
}
