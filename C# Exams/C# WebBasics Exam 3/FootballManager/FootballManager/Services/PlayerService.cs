using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IValidatorService validatorService;
        private readonly IRepository repo;

        public PlayerService(IValidatorService validatorService, IRepository repo)
        {
            this.validatorService = validatorService;
            this.repo = repo;   
        }

        public bool AddPlayer(AddPlayerViewModel model)
        {
            bool isModelValid = validatorService.ValidateModel(model);

            bool isPlayerAdded = true;

            if (!isModelValid)
            {
                isPlayerAdded = false;

                return isPlayerAdded;
            }

            var player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            try
            {
                repo.Add(player);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isPlayerAdded = false;
            }

            return isPlayerAdded;
        }

       

        public IEnumerable<AllPlayerViewModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(x => new AllPlayerViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                    Position = x.Position,
                    Endurance = x.Endurance,
                    Speed = x.Speed,
                    Description = x.Description,
                })
                .ToList();
        }
    }
}
