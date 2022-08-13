using FootballManager.ViewModels.Player;
using FootballManager.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        bool IsRegistered(RegisterViewModel model);
        string Login(LoginViewModel model);
        IEnumerable<MyCollectionViewModel> GetMyCollection(string id);
        bool AddToCollection(int playerId, string id);
        bool RemoveToCollection(int playerId, string id);
    }
}
