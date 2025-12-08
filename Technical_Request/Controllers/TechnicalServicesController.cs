using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_Request.Data;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalServicesController : ControllerBase
    {
        private readonly TechnicalRequestContext context;

        private DbSet<TechnicalService> TechnicalServices
        {
            get {  return context.TechnicalServices; }
        }
        public TechnicalServicesController(TechnicalRequestContext _context) 
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TechnicalService>>> GetTechnicalServices()
        {
            return Ok(await TechnicalServices.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicalService>> GetTechnicalServiceById(int id)
        {
            TechnicalService? technicalService = await TechnicalServices.FindAsync(id);
            if (technicalService == null)
            {
                return NotFound();
            }
            return Ok(technicalService);
        }

        [HttpPost]
        public async Task<ActionResult<TechnicalService>> CreateTechnicalService(TechnicalService newTechnicalService)
        {
            if(newTechnicalService == null)
            {
                return BadRequest();
            }
            
            TechnicalServices.Add(newTechnicalService);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetTechnicalServiceById), new { id = newTechnicalService.Id }, newTechnicalService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTechnicalService(int id, TechnicalService editedTechnicalService)
        {
            if(editedTechnicalService == null)
            {
                return BadRequest();
            }
            TechnicalService? technicalServiceToEdit = await TechnicalServices.FindAsync(id);
            if(technicalServiceToEdit == null)
            {
                return NotFound();
            }
           
            technicalServiceToEdit.Name = editedTechnicalService.Name;
            technicalServiceToEdit.Description = editedTechnicalService.Description;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicalService(int id)
        {
            TechnicalService? technicalServiceToDelete = await TechnicalServices.FindAsync(id);
            if (technicalServiceToDelete == null) 
            {
                return NotFound();
            }

            TechnicalServices.Remove(technicalServiceToDelete);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
