using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InstructionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetInstruction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetInstruction()
        {
            var inst = _context.Ingredients.ToList();
            if (inst.Count == 0)
            {
                return Ok("Empty Result");
            }
            return Ok(inst); //succesed 200 with data

        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetInstruction(int id)
        {
            var inst = _context.Instructions.FirstOrDefault(c => c.Id == id);
            if (inst == null)
            {
                return NotFound();
            }
            return Ok(inst);
        }



        [HttpPost]
        public ActionResult createInstruction(Instruction obj)
        {
            Instruction inst = new Instruction()
            {
                Name = obj.Name
            };
            _context.Instructions.Add(inst);
            _context.SaveChanges();
            return Ok(inst);
        }

        [HttpPost("id")]
        public ActionResult UpdateInstruction(int id, Instruction obj)
        {
            if (id == null)
            {
                return BadRequest("Instruction data is required");
            }
            var inst = _context.Instructions.FirstOrDefault(i => i.Id == id);
            if (inst == null)
            {
                return NotFound($"Instruction with ID {id} not found");
            }
            _context.Instructions.Update(inst);
            _context.SaveChanges();
            return Ok(inst);

        }


        [HttpDelete("id")]
        public ActionResult DeleteInstruction(int id)
        {
            if (id <= 0)
            {
                return BadRequest();

            }
            var inst = _context.Instructions.FirstOrDefault(inst => inst.Id == id);
            if (inst is null)
            {
                return NotFound();
            }
            _context.Instructions.Remove(inst);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
