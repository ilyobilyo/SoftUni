namespace CarShop.ViewModels.Issue
{
    public class CarIssuesViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public bool IsAuthenticated { get; set; } = true;

		public ICollection<IssueListViewModel> Issues { get; set; }
    }
}
