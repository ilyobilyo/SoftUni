using CarShop.Data.Models;
using CarShop.ViewModels;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        (bool isAdded, IEnumerable<ErrorViewModel> errors) AddIssue(AddIssueFormViewModel model);
        CarIssuesViewModel GetAllIssues(string carId);
        (bool isFixed, IEnumerable<ErrorViewModel> errors) Fix(string carId, string issueId, string userId);
        (bool isDeleted, IEnumerable<ErrorViewModel> errors) Delete(string carId, string issueId);
	}
}
