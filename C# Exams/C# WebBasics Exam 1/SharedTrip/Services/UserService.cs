using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            if (repo.All<User>().Any(x => x.Username == model.Username))
            {
                throw new ArgumentException("This username is already used");
            }

            if (repo.All<User>().Any(x => x.Email == model.Email))
            {
                throw new ArgumentException("This email is already used");
            }

            var user = new User()
            {
                Email = model.Email,
                Username = model.Username,
            };

            user.Password = HashPassword(model.Password);

            repo.Add(user);
            repo.SaveChanges();
        }


        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            var errors = new List<ErrorViewModel>();

            if (model.Username == null ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is reqired and must be between 5 and 20 charachters"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is reqired"));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is reqired and must be between 6 and 20 charachters"));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and Confirm Password are is not the sam"));
            }

            return (isValid, errors);
        }

        public (bool isCorrect, string userId) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            var userId = string.Empty;

            var user = GetUser(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashPassword(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (isCorrect, userId);
        }


        private string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordBytes));
            }
        }


        private User GetUser(string username)
        {
            return repo.All<User>()
                .FirstOrDefault(x => x.Username == username);
        }
    }
}

