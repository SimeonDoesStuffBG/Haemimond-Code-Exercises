using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_Request.Data;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsController : ControllerBase
    {
        private readonly TechnicalRequestContext context;

        private DbSet<Models.System> Systems 
        { 
            get {  return context.Systems; } 
        } 

        public SystemsController(TechnicalRequestContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.System>>> GetSystems()
        {
            return Ok(await Systems.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.System>> GetSystemById(int id) 
        {
            Models.System? system = await Systems.FindAsync(id);
            if (system == null)
            {
                return NotFound();
            }

            return Ok(system);
        }

        [HttpPost]
        public async Task<ActionResult<Models.System>> CreateSystem(Models.System newSystem) 
        {
            if ( newSystem == null)
            {
                return BadRequest();
            }
            if( newSystem.Parent !=null)
            {
                Models.System? parent = await Systems.FindAsync(newSystem.Parent);
                if(parent == null || newSystem.Parent == newSystem.Id)
                {
                    return BadRequest("Invalid parent");
                }
            }
            Models.System? testSystem = await Systems.FirstOrDefaultAsync(i=>i.Code==newSystem.Code);
            if (testSystem != null) 
            {
                return Conflict();
            }

            Systems.Add(newSystem);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSystemById), new { id = newSystem.Id }, newSystem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSystem(int id, Models.System editedSystem)
        {
            if(editedSystem == null)
            {
                return BadRequest();
            }
            if (editedSystem.Parent != null)
            {
                int? parentId = editedSystem.Parent;
                List<int?> parents = [];
                do
                {
                    Models.System? parent = await Systems.FindAsync(parentId);
                    
                    if (parent == null || parents.Contains(parentId))
                    {
                        return BadRequest("Invalid parent");
                    }
                    parents.Add(parentId);
                    parentId = parent.Parent;
                } while (parentId != null);
            }
            Models.System? systemToEdit = await Systems.FindAsync(id);
            if(systemToEdit == null)
            {
                return NotFound();
            }

            Models.System? testSystem = await Systems.FirstOrDefaultAsync(s => s.Code == editedSystem.Code);
            if(testSystem != null && testSystem.Code != systemToEdit.Code)
            {
                return Conflict();
            }

            systemToEdit.Name = editedSystem.Name;
            systemToEdit.Code = editedSystem.Code;
            systemToEdit.Parent = editedSystem.Parent;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystem(int id)
        {
            Models.System? systemToDelete = await Systems.FindAsync(id);
            if(systemToDelete == null)
            {
                return NoContent();
            }

            Systems.Remove(systemToDelete);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
