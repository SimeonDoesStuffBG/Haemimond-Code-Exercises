using Coursera_Exercise.Data;
using Coursera_Exercise.DB_Views;
using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseraExerciseContext _context;
        private DbSet<Course> Courses
        {
            get { return _context.Courses; }
        }
        public CoursesController(CourseraExerciseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            return Ok(await Courses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseByID(int id)
        {
            Course? course = await Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course newCourse)
        {
            if(newCourse == null)
            {
                return NotFound();
            }

            Courses.Add(newCourse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourseByID), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(int id, Course editedCourse)
        {
            Course? course = await Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            Course? otherCourse = await Courses.FindAsync(id);
            if (otherCourse!=null && editedCourse.Id != course.Id)
            {
                return Conflict();
            }

            course.Name = editedCourse.Name;
            course.Instructor_id = editedCourse.Instructor_id;
            course.Total_time = editedCourse.Total_time;
            course.Credit = editedCourse.Credit;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            Course? course = await Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport()
        {
            List<StudentCredit> studentCredits = await _context.StudentCredits.ToListAsync();
            foreach (StudentCredit student in studentCredits)
            {
                List<CourseDetails> courseDetails = await _context.CourseDetails
                    .FromSql(@$"GetCourseDetails @StudentPIN = {student.Student_PIN}")
                    .ToListAsync();

                Console.WriteLine($"{student.Student_Name}, {student.Total_Credit}");
                foreach (CourseDetails details in courseDetails)
                {
                    Console.WriteLine($"    {details.Course_name}, {details.Total_time}, {details.Credit}, {details.Instructor_name}");
                }
            }
            return NoContent();
        }
    }
}
