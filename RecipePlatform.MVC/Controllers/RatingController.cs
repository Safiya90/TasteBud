using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.MVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly IGenericRepository<Rating> _rating;
        public RatingController(IGenericRepository<Rating> rating)
        {
            _rating = rating;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
