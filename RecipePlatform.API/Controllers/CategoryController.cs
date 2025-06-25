using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var cats = _context.Categories.ToList();
            if (cats.Count == 0)
            {
                return Ok("Empty Result");
            }
            return Ok(cats); //succesed 200 with data

        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetCategory(int id)
        {
            var cats = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (cats == null)
            {
                return NotFound();
            }
            return Ok(cats);
        }



        [HttpPost]
        public ActionResult createcategory(Category obj)
        {
            Category cat = new Category()
            {
                Name = obj.Name
            };
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return Ok(cat);
        }

        [HttpPost("id")]
        public ActionResult UpdateCategory(int id, Category obj)
        {
            if (id == null)
            {
                return BadRequest("Category data is required");
            }
            var cat = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return NotFound($"Category with ID {id} not found");
            }
            _context.Categories.Update(cat);
            _context.SaveChanges();
            return Ok(cat);

        }


        [HttpDelete("id")]
        public ActionResult DeletCategory(int id)
        {
            if (id <= 0)
            {
                return BadRequest();

            }
            var cat = _context.Categories.FirstOrDefault(cat => cat.Id == id);
            if (cat is null)
            {
                return NotFound();
            }
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
