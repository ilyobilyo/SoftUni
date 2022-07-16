using AutoMapper;
using ProductShop.InputModels;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<InputCategoryProduct, CategoryProduct>();
        }
    }
}
