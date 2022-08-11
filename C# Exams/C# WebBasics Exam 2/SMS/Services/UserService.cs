using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Product;
using SMS.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public UserService(IValidationService validationService, IRepository repo)
        {
            this.validationService = validationService;
            this.repo = repo;
        }

        public string GetUsername(string id)
        {
            return repo.All<User>()
                .Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(x => x.Username == model.Username && x.Password == HashPassword(model.Password))
                .FirstOrDefault();

            return user?.Id;
        }

        public (bool isRegistered, string error) Register(RegisterViewModel model)
        {
            bool isRegistered = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            var cart = new Cart();

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                CartId = cart.Id,
                Cart = cart,
                Password = HashPassword(model.Password)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegistered = true;
            }
            catch (Exception)
            {
                error = "Could not save user to Database";
            }

            return (isRegistered, error);
        }

        private string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using(SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordBytes));
            }
        }
    }
}
