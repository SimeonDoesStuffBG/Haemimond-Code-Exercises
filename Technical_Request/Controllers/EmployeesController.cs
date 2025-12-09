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
        [Authorize]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await Employees.ToListAsync());
        }

        [HttpGet("pin={pin}")]
        [Authorize]
        public async Task<ActionResult<Employee>> GetEmployeeByPIN(string pin)
        {
            Employee? employee = await Employees.OrderByDescending(e=>e.DateAdded).FirstOrDefaultAsync(e => e.PIN == pin);
            if (employee == null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }

        [HttpGet("{id}")]
        [Authorize]
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
        [Authorize]
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
            newEmployee.DateAdded = DateTime.Now;

            Employees.Add(newEmployee);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        [Authorize]
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
            
            Employee? previousNameEmployee = await Employees.FirstOrDefaultAsync(e => 
                e.FirstName == editedEmployee.FirstName 
                && e.Surname == editedEmployee.Surname 
                && e.LastName == editedEmployee.LastName 
                );
            if (previousNameEmployee != null && previousNameEmployee.PIN == employeeToEdit.PIN)
            {
                previousNameEmployee.DateAdded = DateTime.Now;
            }
            else
            {
                editedEmployee.PIN = employeeToEdit.PIN;
                editedEmployee.DateAdded = DateTime.Now;
                Employees.Add(editedEmployee);
            }
                              
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
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
