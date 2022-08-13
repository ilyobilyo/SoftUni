using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly IUserService userService;

        public PlayersController(Request request,
            IPlayerService playerService, IUserService userService) 
            : base(request)
        {
            this.playerService = playerService;
            this.userService = userService;
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddPlayerViewModel model)
        {
            bool isPlayerAdded = playerService.AddPlayer(model);

            if (!isPlayerAdded)
            {
                return View(new { IsAuthenticated = true });
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response All()
        {
            var allPlayers = playerService.GetAllPlayers();

            return View(new { IsAuthenticated = true, Players = allPlayers});
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            bool isPlayerAddedToMyCollection = userService.AddToCollection(playerId, User.Id);

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response Collection()
        {
            var userCollection = userService.GetMyCollection(User.Id);

            return View(new { IsAuthenticated = true, Players = userCollection });
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            bool isPlayerRemovedFromCollection = userService.RemoveToCollection(playerId, User.Id);

            return Redirect("/Players/Collection");
        }
    }
}
