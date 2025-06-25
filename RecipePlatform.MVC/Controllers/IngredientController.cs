using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.MVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IGenericRepository<Ingredient> _ingredient;
        public IngredientController(IGenericRepository<Ingredient> ingredient)
            {
            _ingredient = ingredient;

        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
