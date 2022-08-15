using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using CarShop.ViewModels.User;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly IValidatorService validatorService;
        private readonly IRepository repo;

        public UserService(IValidatorService validatorService, IRepository repo)
        {
            this.validatorService = validatorService;
            this.repo = repo;
        }

        public bool GetUserTypeIsMechanic(string id)
        {
            return repo.All<User>()
                .FirstOrDefault(x => x.Id == id)
                .IsMechanic;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .FirstOrDefault(x => x.Username == model.Username && x.Password == HashPassword(model.Password));

            return user?.Id;
        }

        public (bool isRegistered, IEnumerable<ErrorViewModel>) Register(RegisterViewModel model)
        {
            var (isValid, errorMessages) = validatorService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errorMessages);
            }

            bool isRegistered = true;
            List<ErrorViewModel> dbErrors = new List<ErrorViewModel>();

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                IsMechanic = IsMechanic(model.UserType),
                Password = HashPassword(model.Password)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isRegistered = false;
                dbErrors.Add(new ErrorViewModel() { ErrorMessage = "Unexpected error. Database cant save user!" });
            }

            return (isRegistered, dbErrors);
        }

        private string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using(SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordBytes));
            }
        }

        private bool IsMechanic(string userType)
        {
            if (userType == "Client")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
