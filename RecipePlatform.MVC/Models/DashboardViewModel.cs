using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.MVC.Models
{
    public class DashboardViewModel
    {
        public List<Category> Categories { get; set; }
        public List<RecipeSummaryViewModel> Recipes { get; set; }
        public List<UserSummaryViewModel> Users { get; set; }
    }

    public class RecipeSummaryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostedBy { get; set; }
    }

    public class UserSummaryViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
