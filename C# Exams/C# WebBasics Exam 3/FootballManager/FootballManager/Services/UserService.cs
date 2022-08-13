using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Player;
using FootballManager.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
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

        public IEnumerable<MyCollectionViewModel> GetMyCollection(string id)
        {
            return repo.All<UserPlayer>()
                .Where(x => x.UserId == id)
                .Select(x => new MyCollectionViewModel()
                {
                    FullName = x.Player.FullName,
                    Description = x.Player.Description,
                    Endurance = x.Player.Endurance,
                    Id = x.Player.Id,
                    ImageUrl = x.Player.ImageUrl,
                    Position = x.Player.Position,
                    Speed = x.Player.Speed,
                })
                .ToList();
        }

        public bool IsRegistered(RegisterViewModel model)
        {
            bool isModelValid = validatorService.ValidateModel(model);

            bool isRegistered = true;

            if (!isModelValid)
            {
                isRegistered = false;

                return isRegistered;
            }

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isRegistered = false;
            }

            return isRegistered;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(x => x.Username == model.Username && x.Password == HashPassword(model.Password))
                .FirstOrDefault();

            return user?.Id;
        }

        public bool AddToCollection(int playerId, string id)
        {
            var user = repo.All<User>()
                .FirstOrDefault(x => x.Id == id);

            var player = repo.All<Player>()
                .FirstOrDefault(x => x.Id == playerId);

            if (player == null || user.UserPlayers.Any(x => x.PlayerId == playerId))
            {
                return false;
            }

            user.UserPlayers.Add(new UserPlayer()
            {
                PlayerId = playerId,
                UserId = id,
                Player = player,
                User = user
            });

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveToCollection(int playerId, string id)
        {
            var user = repo.All<User>()
                .FirstOrDefault(x => x.Id == id);

            var player = repo.All<UserPlayer>()
                .FirstOrDefault(x => x.UserId == id && x.PlayerId == playerId);

            if (player == null)
            {
                return false;
            }

            user.UserPlayers.Remove(player);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            byte[] passwordArr = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArr));
            }
        }
    }
}
