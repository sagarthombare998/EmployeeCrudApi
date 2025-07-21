using EmployeeCrudApi.Models;
using EmployeeCrudApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => Ok(_employeeService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = _employeeService.GetById(id);
            if (emp is null) return NotFound($"Employee with ID {id} not found.");

            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FullName) || string.IsNullOrWhiteSpace(employee.Department) || employee.Salary < 0)
            {
                return BadRequest("Invalid employee data.");
            }

            var newEmp = _employeeService.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = newEmp.Id }, newEmp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updatedEmployee)
        {
            if (string.IsNullOrWhiteSpace(updatedEmployee.FullName) || string.IsNullOrWhiteSpace(updatedEmployee.Department) || updatedEmployee.Salary < 0)
            {
                return BadRequest("Invalid employee data.");
            }

            var success = _employeeService.Update(id, updatedEmployee);

            if (!success) return NotFound($"Employee with ID {id} not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _employeeService.Delete(id);
            if (!success) return NotFound($"Employee with ID {id} not found.");

            return NoContent();
        }
    }
}

