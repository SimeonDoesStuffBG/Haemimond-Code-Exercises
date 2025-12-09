using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<List<TechnicalService>>> GetTechnicalServices()
        {
            return Ok(await TechnicalServices.ToListAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [HttpPost("{serviceId}/blocks/{blockId}")]
        [Authorize]
        public async Task<IActionResult> AddBlock(int serviceId, int blockId)
        {
            TechnicalService? technicalService = await TechnicalServices.FindAsync(serviceId);
            Block? block = await context.Blocks.FindAsync(blockId);
            if (technicalService==null || block == null)
            {
                return NotFound();
            }
            ServiceBlock? testServiceBlock = await context.ServiceBlocks.FindAsync(serviceId, blockId);
            if(testServiceBlock != null) 
            {
                return Conflict();
            }
            ServiceBlock serviceBlock = new ServiceBlock { BlockId = blockId, ServiceId = serviceId };
            context.ServiceBlocks.Add(serviceBlock);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{serviceId}/blocks/{blockId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBlock(int serviceId, int blockId)
        {
            ServiceBlock? serviceBlock = await context.ServiceBlocks.FindAsync(serviceId, blockId);
            if(serviceBlock == null)
            {
                return NotFound();
            }

            context.ServiceBlocks.Remove(serviceBlock);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{serviceId}/systems/{systemId}")]
        [Authorize]
        public async Task<IActionResult> AddSystem(int serviceId, int systemId)
        {
            TechnicalService? technicalService = await TechnicalServices.FindAsync(serviceId);
            Models.System? system = await context.Systems.FindAsync(systemId);
            if(system == null || technicalService == null)
            {
                return NotFound();
            }
            ServiceSystem? existingServiceSystem = await context.ServiceSystems.FindAsync(serviceId, systemId);
            if(existingServiceSystem != null)
            {
                return Conflict();
            }
            ServiceSystem serviceSystem = new ServiceSystem { SystemId = systemId, ServiceId = serviceId };
            context.ServiceSystems.Add(serviceSystem);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{serviceId}/systems/{systemId}")]
        [Authorize]
        public async Task<IActionResult> RemoveSystem(int serviceId, int systemId)
        {
            ServiceSystem? serviceSystem = await context.ServiceSystems.FindAsync(serviceId, systemId);
            if (serviceSystem == null)
            {
                return NotFound();
            }

            context.ServiceSystems.Remove(serviceSystem);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{serviceId}/ResponsiblePersons/{activity}/{employeeId}")]
        [Authorize]
        public async Task<IActionResult> AddResponsiblePerson(int serviceId, int employeeId, string activity)
        {
            TechnicalService? technicalService = await TechnicalServices.FindAsync(serviceId);
            Employee? employee = await context.Employees.FindAsync(employeeId);
            bool validActivity = ResponsiblePerson.Activities.Contains(activity);
            if (employee == null || technicalService == null || !validActivity) 
            {
                return NotFound();
            }
            ResponsiblePerson? existingResponsiblePerson = await context.ResponsiblePersons.FindAsync(serviceId, activity);
            if(existingResponsiblePerson != null)
            {
                return Conflict();
            }

            ResponsiblePerson responsiblePerson = new ResponsiblePerson { ServiceId=serviceId, EmployeeId =employeeId, Activity = activity };
            context.ResponsiblePersons.Add(responsiblePerson);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{serviceId}/ResponsiblePersons/{activity}")]
        [Authorize]
        public async Task<IActionResult> RemoveResponsiblePerson(int serviceId, string activity)
        {
            ResponsiblePerson? responsiblePerson = await context.ResponsiblePersons.FindAsync(serviceId, activity);

            if (responsiblePerson == null) 
            {
                return NotFound();
            }

            context.ResponsiblePersons.Remove(responsiblePerson);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
