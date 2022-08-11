using SMS.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool isValid, string error) ValidateModel(CreateProductViewModel model);

        IEnumerable<ProductListViewModel> GetProducts();
    }
}
