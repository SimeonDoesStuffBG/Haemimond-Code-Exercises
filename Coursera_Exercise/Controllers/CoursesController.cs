using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Name="Programming basics", Instructor_id=3, Total_Time=23, Credit=20, Time_created = DateTime.Now},
            new Course { Id = 2, Name="Object orianted programming", Instructor_id=3, Total_Time=13, Credit=1, Time_created = DateTime.Now},
            new Course { Id = 3, Name="Parody", Instructor_id=2, Total_Time=22,Credit=22, Time_created =DateTime.Now},
            new Course { Id = 4, Name="Creative Writing", Instructor_id=5, Total_Time=43, Credit=9, Time_created = DateTime.Now},
            new Course { Id = 5, Name="Elvish", Instructor_id=1, Total_Time=34, Credit=23, Time_created = DateTime.Now},
        };

        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseByID(int id)
        {
            Course? course = courses.FirstOrDefault(c => c.Id == id);
            if(course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}
