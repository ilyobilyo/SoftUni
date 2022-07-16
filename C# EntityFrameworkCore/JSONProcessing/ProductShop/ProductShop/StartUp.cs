using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.InputModels;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();
            
            //string inputJson = File.ReadAllText("../../../Datasets//categories-products.json");
            Console.WriteLine(GetUsersWithProducts(db));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(s => s.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(s => s.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(s => s.BuyerId != null).Select(c => new
                        {
                            name = c.Name,
                            price = c.Price,
                        })
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var result = new
            {
                usersCount = context.Users.Count(x => x.ProductsSold.Any(s => s.BuyerId != null)),
                users = users
            };

            var setting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, };

            var json = JsonConvert.SerializeObject(result, Formatting.Indented, setting);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = $"{x.CategoryProducts.Average(s => s.Product.Price):f2}",
                    totalRevenue = $"{x.CategoryProducts.Sum(s => s.Product.Price):f2}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0 && x.ProductsSold.Any(s => s.BuyerId > 0))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(s => new
                    {
                        name = s.Name,
                        price = s.Price,
                        buyerFirstName = s.Buyer.FirstName,
                        buyerLastName = s.Buyer.LastName
                    })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new 
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName,
                })
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonProducts;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitialazeAutomapper();

            var inputCategoryProduct = JsonConvert.DeserializeObject<List<InputCategoryProduct>>(inputJson);

            var categoryProducts = mapper.Map<List<CategoryProduct>>(inputCategoryProduct);

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            foreach (var category in categories)
            {
                if (category.Name == null)
                {
                    continue;
                }

                context.Categories.Add(category);
            }

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        public static void InitialazeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}