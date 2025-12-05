using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalServicesController : ControllerBase
    {
        private static List<TechnicalService> technicalServices = new List<TechnicalService>
        {
            new TechnicalService {Id=1, Name="Service 1", Description="Desc", TimeOfCreation=DateTime.Now},
            new TechnicalService {Id=2, Name="Service 2", Description="Descr", TimeOfCreation=DateTime.Now},
            new TechnicalService {Id = 3, Name = "Service 3", Description = "Descri", TimeOfCreation = DateTime.Now},
            new TechnicalService {Id = 4, Name = "Service 4", Description = "Descrip", TimeOfCreation = DateTime.Now},
            new TechnicalService {Id = 5, Name = "Service 5", Description = "Descript", TimeOfCreation = DateTime.Now},
        };

        [HttpGet]
        public ActionResult<List<TechnicalService>> GetTechnicalServices()
        {
            return Ok(technicalServices);
        }

        [HttpGet("{id}")]
        public ActionResult<TechnicalService> GetTechnicalServiceById(int id)
        {
            TechnicalService? technicalService = technicalServices.FirstOrDefault(s => id == s.Id);
            if (technicalService == null)
            {
                return NotFound();
            }
            return Ok(technicalService);
        }

        [HttpPost]
        public ActionResult<TechnicalService> CreateTechnicalService(TechnicalService newTechnicalService)
        {
            if(newTechnicalService == null)
            {
                return BadRequest();
            }
            TechnicalService? existingTechService = technicalServices.FirstOrDefault(s => newTechnicalService.Id == s.Id);
            if (existingTechService != null)
            {
                return Conflict();
            }

            technicalServices.Add(newTechnicalService);
            return CreatedAtAction(nameof(GetTechnicalServiceById), new { id = newTechnicalService.Id }, newTechnicalService);
        }

        [HttpPut("{id}")]
        public IActionResult editTechnicalService(int id, TechnicalService editedTechnicalService)
        {
            if(editedTechnicalService == null)
            {
                return BadRequest();
            }
            TechnicalService? technicalServiceToEdit = technicalServices.FirstOrDefault(s => s.Id == id);
            if(technicalServiceToEdit == null)
            {
                return NotFound();
            }
            TechnicalService? testTechService = technicalServices.FirstOrDefault(s => s.Id == id);
            if(testTechService != null && testTechService.Id != technicalServiceToEdit.Id)
            {
                return Conflict();
            }

            technicalServiceToEdit.Id = editedTechnicalService.Id;
            technicalServiceToEdit.Name = editedTechnicalService.Name;
            technicalServiceToEdit.Description = editedTechnicalService.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTechnicalService(int id)
        {
            TechnicalService? technicalServiceToDelete = technicalServices.FirstOrDefault(s => s.Id == id);
            if (technicalServiceToDelete == null) 
            {
                return NotFound();
            }

            technicalServices.Remove(technicalServiceToDelete);
            return NoContent();
        }
    }
}
