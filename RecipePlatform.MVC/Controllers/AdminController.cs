using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.Models.Entities.UserManagement;
using RecipePlatform.Models.Entities;
using RecipePlatform.PL.MVC.Models;

namespace RecipePlatform.PL.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Recipe> _recipeRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            IGenericRepository<Category> categoryRepo,
            IGenericRepository<Recipe> recipeRepo,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _categoryRepo = categoryRepo;
            _recipeRepo = recipeRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            // Get Categories
            var categories = (await _categoryRepo.GetAllAsync()).ToList();

            // Get Recipes (simplified, assumes Recipe has Title and ApplicationUser navigation property)
            var recipes = (await _recipeRepo.GetAllAsync())
                .Select(r => new RecipeSummaryViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    PostedBy = r.UserID != null ? r.UserID : "Unknown"
                }).ToList();

            // Get Users + Roles
            var users = _userManager.Users.ToList();
            var userList = new List<UserSummaryViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserSummaryViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = roles.FirstOrDefault() ?? "No Role"
                });
            }

            var model = new DashboardViewModel
            {
                Categories = categories,
                Recipes = recipes,
                Users = userList
            };

            return View(model);
        }
    }
}

