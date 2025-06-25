using Microsoft.AspNetCore.Mvc;

namespace RecipePlatform.PL.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
