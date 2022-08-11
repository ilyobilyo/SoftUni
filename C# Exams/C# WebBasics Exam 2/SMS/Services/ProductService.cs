using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Product;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public ProductService(IValidationService validationService, IRepository repo)
        {
            this.validationService = validationService;
            this.repo = repo;
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(x => new ProductListViewModel
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2")
                })
                .ToList();
        }

        public (bool isValid, string error) ValidateModel(CreateProductViewModel model)
        {
            bool isCreated = false;
            string error = null;

            var (isNameValid, validationError) = validationService.ValidateModel(model);

            if (!isNameValid)
            {
                return (isNameValid, validationError);
            }

            decimal price = 0;

            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 0.05m || price > 1000m)
            {
                return (false, "Price must be between 0.05 and 1000");
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = price,
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();

                isCreated = true;
            }
            catch (Exception)
            {
                error = "Could not save Product to Database";
            }

            return (isCreated, error);
        }
    }
}
