using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request, IProductService productService) 
            : base(request)
        {
            this.productService = productService;
        }

        [Authorize]
        public Response Create()
        {
            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Create(CreateProductViewModel model)
        {
            var (isProductValid, validationError) = productService.ValidateModel(model);

            if (!isProductValid)
            {
                return View(new { ErrorMessage = validationError }, "/Error");
            }

            return Redirect("/Home");
        }
    }
}
