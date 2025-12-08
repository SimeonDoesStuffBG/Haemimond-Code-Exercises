using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_Request.Data;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TechnicalRequestContext context;

        private DbSet<Employee> Employees
        {
            get { return context.Employees; }
        }

        public EmployeesController(TechnicalRequestContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {
            Employee? employee = await Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
            {
                return BadRequest();
            }
            Employee? existingEmployee = await Employees.FirstOrDefaultAsync(e=>e.PIN == newEmployee.PIN);
            if (existingEmployee != null)
            {
                return Conflict();
            }

            Employees.Add(newEmployee);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(int id, Employee editedEmployee)
        {
            if(editedEmployee == null)
            {
                return BadRequest();
            }
            Employee? employeeToEdit = await Employees.FindAsync(id);
            if(employeeToEdit == null)
            {
                return NotFound();
            }

            Employee? testEmployee = await Employees.FirstOrDefaultAsync(e => e.PIN == editedEmployee.PIN);
            if(testEmployee != null && testEmployee.PIN != employeeToEdit.PIN)
            {
                return Conflict();
            }

            employeeToEdit.FirstName = editedEmployee.FirstName;
            employeeToEdit.Surname = editedEmployee.Surname;
            employeeToEdit.LastName = editedEmployee.LastName;
            employeeToEdit.PIN = editedEmployee.PIN;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) 
        {
            Employee? employeeToDelete = await Employees.FindAsync(id);
            if(employeeToDelete == null)
            {
                return NotFound();
            }
            
            Employees.Remove(employeeToDelete);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
