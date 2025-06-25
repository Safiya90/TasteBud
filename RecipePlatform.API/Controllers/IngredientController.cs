using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetIngredients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetIngredients()
        {
            var ings = _context.Ingredients.ToList();
            if (ings.Count == 0)
            {
                return Ok("Empty Result");
            }
            return Ok(ings); //succesed 200 with data

        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetIngredient(int id)
        {
            var ings = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ings == null)
            {
                return NotFound();
            }
            return Ok(ings);
        }



        [HttpPost]
        public ActionResult createIngredient(Ingredient obj)
        {
            Ingredient ing = new Ingredient()
            {
                Name = obj.Name
            };
            _context.Ingredients.Add(ing);
            _context.SaveChanges();
            return Ok(ing);
        }

        [HttpPost("id")]
        public ActionResult UpdateIngredient(int id, Ingredient obj)
        {
            if (id == null)
            {
                return BadRequest("Ingredient data is required");
            }
            var ing = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ing == null)
            {
                return NotFound($"Ingredient with ID {id} not found");
            }
            _context.Ingredients.Update(ing);
            _context.SaveChanges();
            return Ok(ing);

        }


        [HttpDelete("id")]
        public ActionResult DeletIngredient(int id)
        {
            if (id <= 0)
            {
                return BadRequest();

            }
            var ing = _context.Ingredients.FirstOrDefault(ing => ing.Id == id);
            if (ing is null)
            {
                return NotFound();
            }
            _context.Ingredients.Remove(ing);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
