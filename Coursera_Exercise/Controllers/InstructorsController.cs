using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
       private static List<Instructor> instructors = new List<Instructor>
       {
           new Instructor{ Id = 1, First_name="Gandalf", Last_name="The Gray", time_created = DateTime.Now},
           new Instructor{ Id = 2, First_name="Moiraine", Last_name="Sedai", time_created = DateTime.Now},
           new Instructor{ Id = 3, First_name="Leto Atreides", Last_name="The Second The Second", time_created = DateTime.Now},
           new Instructor{ Id = 4, First_name="Archangel", Last_name="Michael", time_created = DateTime.Now},
           new Instructor{ Id = 5, First_name="Eda", Last_name="Clawthorne", time_created = DateTime.Now},
       };

        [HttpGet]
        public ActionResult<List<Instructor>> GetInstructors()
        {
            return Ok(instructors);
        }
    }
}
