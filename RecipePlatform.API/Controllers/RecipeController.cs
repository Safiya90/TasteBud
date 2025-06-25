using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetRecipes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetRecipes()
        {
            var rec = _context.Recipes.ToList();
            if (rec.Count == 0)
            {
                return Ok("Empty Result");
            }
            return Ok(rec); //succesed 200 with data

        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetRecipes(int id)
        {
            var rec = _context.Recipes.FirstOrDefault(c => c.Id == id);
            if (rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }



        [HttpPost]
        public ActionResult createrecipe(Recipe obj)
        {
            Recipe rec = new Recipe()
            {
                Title = obj.Title
            };
            _context.Recipes.Add(rec);
            _context.SaveChanges();
            return Ok(rec);
        }

        [HttpPost("id")]
        public ActionResult Updaterecipes(int id, Recipe obj)
        {
            if (id == null)
            {
                return BadRequest("Recipe data is required");
            }
            var rec = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (rec == null)
            {
                return NotFound($"Recipe with ID {id} not found");
            }
            _context.Recipes.Update(rec);
            _context.SaveChanges();
            return Ok(rec);

        }


        [HttpDelete("id")]
        public ActionResult DeletRecipe(int id)
        {
            if (id <= 0)
            {
                return BadRequest();

            }
            var rec = _context.Recipes.FirstOrDefault(rec => rec.Id == id);
            if (rec is null)
            {
                return NotFound();
            }
            _context.Recipes.Remove(rec);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
