using Coursera_Exercise.Data;
using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly CourseraExerciseContext _context;
        private DbSet<Instructor> Instructors
        {
            get { return _context.Instructors; }
        }
        public InstructorsController(CourseraExerciseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Instructor>>> GetInstructors()
        {
            return Ok(await Instructors.ToListAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Instructor>> GetInstructorByID (int id)
        {
            Instructor? instructor = await Instructors.FindAsync(id);
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult<Instructor>> CreateInstructor(Instructor newInstructor)
        {
            if(newInstructor == null)
            {
                return BadRequest();
            }

            Instructors.Add(newInstructor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInstructorByID), new { id = newInstructor.Id }, newInstructor);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInstructor(int id, Instructor editedInstructor)
        {
            Instructor? instructor = await Instructors.FindAsync(id);
            if(instructor == null)
            {
                return NotFound();
            }

            instructor.First_name = editedInstructor.First_name;
            instructor.Last_name = editedInstructor.Last_name;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            Instructor? instructor = await Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
