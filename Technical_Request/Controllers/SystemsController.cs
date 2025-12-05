using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsController : ControllerBase
    {
        private static List<Models.System> systems = new List<Models.System>
        {
           
        };

        [HttpGet]
        public ActionResult<List<Models.System>> GetSystems()
        {
            return systems;
        }

        [HttpGet("{id}")]
        public ActionResult<Models.System> GetSystemById(int id) 
        {
            Models.System? system = systems.FirstOrDefault(s=>s.Id==id);
            if (system == null)
            {
                return NotFound();
            }

            return system;
        }

        [HttpPost]
        public ActionResult<Models.System> CreateSystem(Models.System newSystem) 
        {
            if ( newSystem == null)
            {
                return BadRequest();
            }
            if( newSystem.Parent !=null)
            {
                Models.System? parent = systems.FirstOrDefault(i=>i.Id==newSystem.Parent);
                if(parent == null || newSystem.Parent == newSystem.Id)
                {
                    return BadRequest("Invalid parent");
                }
            }
            Models.System? testSystem = systems.FirstOrDefault(i=>i.Id==newSystem.Id || i.Code==newSystem.Code);
            if (testSystem != null) 
            {
                return Conflict();
            }

            systems.Add(newSystem);
            return CreatedAtAction(nameof(GetSystemById), new { id = newSystem.Id }, newSystem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSystem(int id, Models.System editedSystem)
        {
            if(editedSystem == null)
            {
                return BadRequest();
            }
            if (editedSystem.Parent != null)
            {
                int? parentId = editedSystem.Parent;
                do
                {
                    Models.System? parent = systems.FirstOrDefault(s => s.Id == parentId);
                    if (parent == null || parent.Id == editedSystem.Id)
                    {
                        return BadRequest("Invalid parent");
                    }
                    parentId = parent.Parent;
                } while (parentId != null);
            }
            Models.System? systemToEdit = systems.FirstOrDefault(s => s.Id == id);
            if(systemToEdit == null)
            {
                return NotFound();
            }

            Models.System? testSystem = systems.FirstOrDefault(s => s.Id == editedSystem.Id);
            if(testSystem != null && testSystem.Id != systemToEdit.Id)
            {
                return Conflict();
            }
            testSystem = systems.FirstOrDefault(s => s.Code == systemToEdit.Code);
            if(testSystem != null && testSystem.Code != editedSystem.Code)
            {
                return Conflict();
            }

            systemToEdit.Id = editedSystem.Id;
            systemToEdit.Name = editedSystem.Name;
            systemToEdit.Code = editedSystem.Code;
            systemToEdit.Parent = editedSystem.Parent;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSystem(int id)
        {
            Models.System? systemToDelete = systems.FirstOrDefault(s => s.Id == id);
            if(systemToDelete == null)
            {
                return NoContent();
            }

            systems.Remove(systemToDelete);
            return NoContent();
        }
    }
}
