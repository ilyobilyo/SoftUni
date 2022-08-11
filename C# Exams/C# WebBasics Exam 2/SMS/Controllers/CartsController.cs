using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(Request request, ICartService cartService)
            : base(request)
        {
            this.cartService = cartService;
        }


        [Authorize]
        public Response AddProduct(string productId)
        {
            var products = cartService.AddProduct(User.Id, productId);

            return View(new { IsAuthenticated = true, Products = products}, "/Carts/Details");
        }

        [Authorize]
        public Response Details()
        {
            var products = cartService.GetProducts(User.Id);

            return View(new { IsAuthenticated = true, Products = products });
        }

        [Authorize]
        public Response Buy()
        {
            cartService.BuyProducts(User.Id);

            return Redirect("/");
        }
    }
}
