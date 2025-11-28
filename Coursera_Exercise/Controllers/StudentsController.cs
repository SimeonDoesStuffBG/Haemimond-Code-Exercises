using Coursera_Exercise.Data;
using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly CourseraExerciseContext _context;
        private DbSet<Student> Students
        {
            get { return _context.Students; }
        }
        public StudentsController(CourseraExerciseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return Ok(await Students.ToListAsync());
        }

        [HttpGet("{pin}")]
        [Authorize]
        public async Task<ActionResult<Student>> GetStudentByPIN(string pin)
        {
            Student? student = await Students.FindAsync(pin);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Student>> CreateStudent(Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest();
            }
            Student? existingStudent = await Students.FindAsync(newStudent.PIN);
            if (existingStudent != null)
            {
                return Conflict();
            }

            Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentByPIN), new { pin = newStudent.PIN }, newStudent);
        }

        [HttpPut("{pin}")]
        [Authorize]
        public async Task<IActionResult> UpdateStudent(string pin, Student editedStudent)
        {
            Student? student = await Students.FindAsync(pin);
            if (student == null)
            {
                return NotFound();
            }
            Student? otherStudent = await Students.FindAsync(editedStudent.PIN);
            if (otherStudent != null && otherStudent.PIN != pin)
            {
                return Conflict();
            }

            student.First_name = editedStudent.First_name;
            student.Last_name = editedStudent.Last_name;
            student.Time_created = editedStudent.Time_created;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{pin}")]
        [Authorize]
        public async Task<IActionResult> DeleteStudent(string pin)
        {
            Student? student = await Students.FindAsync(pin);
            if (student == null)
            {
                return NotFound();
            }

            Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{pin}/course/{id}")]
        public async Task<ActionResult<StudentCourse>> EnrollInCourse(string pin, int id)
        {
            Student? student = await Students.FindAsync(pin);
            Course? course = await _context.Courses.FindAsync(id);
            if (student == null || course == null)
            {
                return BadRequest();
            }
            StudentCourse? existingCourse = await _context.StudentsCourse.FindAsync(pin, id);
            if (existingCourse != null)
            {
                return Conflict();
            }
            StudentCourse studentCourse = new StudentCourse { Student_pin = pin, Course_id = id };
            _context.StudentsCourse.Add(studentCourse);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{pin}/course/{id}")]
        [Authorize]
        public async Task<IActionResult> FinishCourse(string pin, int id)
        {
            StudentCourse? studentCourse = await _context.StudentsCourse.FindAsync(pin, id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            if (studentCourse.Completion_Date != null)
            {
                return Conflict();
            }

            studentCourse.Completion_Date = DateOnly.FromDateTime(DateTime.Now);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{pin}/course/{id}")]
        [Authorize]
        public async Task<IActionResult> AbandonCourse(string pin, int id)
        {
            StudentCourse? studentCourse = await _context.StudentsCourse.FindAsync(pin, id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            if (studentCourse.Completion_Date != null)
            {
                return Conflict();
            }

            _context.StudentsCourse.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
