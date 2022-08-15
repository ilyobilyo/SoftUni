using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using CarShop.ViewModels.Issue;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly IValidatorService validatorService;
        private readonly IRepository repo;
        private readonly IUserService userService;

        public IssueService(IValidatorService validatorService, IRepository repo, IUserService userService)
        {
            this.validatorService = validatorService;
            this.repo = repo;
            this.userService = userService;
        }

        public (bool isAdded, IEnumerable<ErrorViewModel> errors) AddIssue(AddIssueFormViewModel model)
        {
            var (isValid, errors) = validatorService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errors);
            }

            bool isAdded = true;
            var dbErrors = new List<ErrorViewModel>();

            var car = repo.All<Car>()
                .FirstOrDefault(x => x.Id == model.CarId);

            car.Issues.Add(new Issue()
            {
                CarId = model.CarId,
                Description = model.Description,
            });

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;

                dbErrors.Add(new ErrorViewModel() { ErrorMessage = "Unexpected error. Database cant save this issue!" });
            }

            return (isAdded, dbErrors);
        }

        public (bool isDeleted, IEnumerable<ErrorViewModel> errors) Delete(string carId, string issueId)
        {
            var car = repo.All<Car>()
                 .Where(x => x.Id == carId)
                 .FirstOrDefault();

            var issue = repo.All<Issue>()
                .Where(x => x.Id == issueId)
                .FirstOrDefault();

            bool isDeleted = true;

            var errors = new List<ErrorViewModel>();

            try
            {
                car.Issues.Remove(issue);

                repo.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(new ErrorViewModel() { ErrorMessage = "Unexpected error! Cannot remove issue. Try again later." });

                isDeleted = false;
            }

            return (isDeleted, errors); 
        }

        public (bool isFixed, IEnumerable<ErrorViewModel> errors) Fix(string carId, string issueId, string userId)
        {
            bool isMechanic = userService.GetUserTypeIsMechanic(userId);

            var errors = new List<ErrorViewModel>();

            if (!isMechanic)
            {
                errors.Add(new ErrorViewModel()
                {
                    ErrorMessage = "Only Mechanics can fix Issues!"
                });

                return (isMechanic, errors);
            }

            bool isFixed = true;

            var issue = repo.All<Issue>()
                .Where(x => x.CarId == carId && x.Id == issueId)
                .FirstOrDefault();

            issue.IsFixed = true;

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(new ErrorViewModel() { ErrorMessage = "Unexpected error. Database can not save fixes!" });

                isFixed = false;
            }

            return (isFixed, errors);
        }

        public CarIssuesViewModel GetAllIssues(string carId)
        {
            return repo.All<Car>()
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesViewModel()
                {
                    Id = x.Id,
                    Model = x.Model,
                    Issues = x.Issues.Select(x => new IssueListViewModel()
                    {
                        Description = x.Description,
                        IsFixed = x.IsFixed ? "Yes" : "Not yet",
                        IssueId = x.Id
                    })
                    .ToList()
                })
                .FirstOrDefault();
        }
    }
}
