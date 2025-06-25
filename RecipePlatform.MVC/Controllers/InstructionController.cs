using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.MVC.Controllers
{
    public class InstructionController : Controller
    {
        private readonly IGenericRepository<Instruction> _instruction;
        public InstructionController(IGenericRepository<Instruction> instruction)
        {
            _instruction = instruction;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
