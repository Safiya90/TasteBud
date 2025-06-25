using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.Models.Entities;
using RecipePlatform.Models.Entities.UserManagement;
using RecipePlatform.PL.MVC.Models;

namespace RecipePlatform.PL.MVC.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<Category> _categoryRepository;

        public RecipeController(
            IRecipeService recipeService,
            UserManager<ApplicationUser> userManager,
            IGenericRepository<Category> categoryRepository)
        {
            _recipeService = recipeService;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var viewModel = new AddRecipeViewModel
            {
                Categories = categories.Cast<Category>().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // أعد تعبئة التصنيفات في حال فشل النموذج
                var categories = await _categoryRepository.GetAllAsync();
                model.Categories = categories.Cast<Category>().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);

            var recipe = new Recipe
            {
                Title = model.Title,
                Description = model.Description,
                PrepTimeMinutes = model.PrepTimeMinutes,
                CookTimeMinutes = model.CookTimeMinutes,
                Servings = model.Servings,
                Difficulty = model.Difficulty,
                CategoryId = model.CategoryId,
                UserID = user.Id,
                CreatedDate = DateTime.Now
            };

            await _recipeService.AddRecipeAsync(recipe);

            return RedirectToAction("Index", "Home");
        }
    }
}
