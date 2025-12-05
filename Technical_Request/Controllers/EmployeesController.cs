using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeByID(int id)
        {
            Employee? employee = employees.FirstOrDefault(e => e.Id == id);
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
            {
                return BadRequest();
            }
            Employee? existingEmployee = employees.FirstOrDefault(e => e.Id == newEmployee.Id);
            if (existingEmployee != null)
            {
                return Conflict();
            }

            employees.Add(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, Employee editedEmployee)
        {
            if(editedEmployee == null)
            {
                return BadRequest();
            }
            Employee? employeeToEdit = employees.FirstOrDefault(e => e.Id == id);
            if(employeeToEdit == null)
            {
                return NotFound();
            }

            Employee? testEmployee = employees.FirstOrDefault(e => e.Id == editedEmployee.Id);
            if(testEmployee != null && testEmployee.Id != employeeToEdit.Id)
            {
                return Conflict();
            }

            employeeToEdit.Id = editedEmployee.Id;
            employeeToEdit.FirstName = editedEmployee.FirstName;
            employeeToEdit.Surname = editedEmployee.Surname;
            employeeToEdit.LastName = editedEmployee.LastName;
            employeeToEdit.PIN = editedEmployee.PIN;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id) 
        {
            Employee? employeeToDelete = employees.FirstOrDefault(e => e.Id == id);
            if(employeeToDelete == null)
            {
                return NotFound();
            }
            employees.Remove(employeeToDelete);
            return NoContent();
        }
    }
}
