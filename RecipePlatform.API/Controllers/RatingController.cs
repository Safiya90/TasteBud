using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetRatings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetRatings()
        {
            var rat = _context.Ratings.ToList();
            if (rat.Count == 0)
            {
                return Ok("Empty Result");
            }
            return Ok(rat); //succesed 200 with data

        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetRating(int id)
        {
            var rat = _context.Ratings.FirstOrDefault(r => r.Id == id);
            if (rat == null)
            {
                return NotFound();
            }
            return Ok(rat);
        }



        [HttpPost]
        public ActionResult createRating(Rating obj)
        {
            Rating rat = new Rating()
            {
                RatingStar = obj.RatingStar
            };
            _context.Ratings.Add(rat);
            _context.SaveChanges();
            return Ok(rat);
        }

        [HttpPost("id")]
        public ActionResult UpdateRating(int id, Rating obj)
        {
            if (id == null)
            {
                return BadRequest("Rating data is required");
            }
            var rat = _context.Ratings.FirstOrDefault(r => r.Id == id);
            if (rat == null)
            {
                return NotFound($"Rating with ID {id} not found");
            }
            _context.Ratings.Update(rat);
            _context.SaveChanges();
            return Ok(rat);

        }


        [HttpDelete("id")]
        public ActionResult DeletRating(int id)
        {
            if (id <= 0)
            {
                return BadRequest();

            }
            var rat = _context.Ratings.FirstOrDefault(rat => rat.Id == id);
            if (rat is null)
            {
                return NotFound();
            }
            _context.Ratings.Remove(rat);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
