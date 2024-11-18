using dotNetCoreWebAPI.Data;
using dotNetCoreWebAPI.Models;
using dotNetCoreWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public EmployeesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dBContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeesById(int id)
        {
            var byEmployeeId = dBContext.Employees.Find(id);

            if (byEmployeeId == null) 
            { 
                return NotFound(); 
            }

            return Ok(byEmployeeId);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee() 
            { 
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            dBContext.Employees.Add(employeeEntity);
            dBContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployees(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var updateEmployee = dBContext.Employees.Find(id);

            if (updateEmployee is null) 
            { 
                return NotFound(); 
            }

            if (id <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            updateEmployee.Name = updateEmployeeDto.Name;
            updateEmployee.Email = updateEmployeeDto.Email;
            updateEmployee.Phone = updateEmployeeDto.Phone;
            dBContext.SaveChanges();
            
            return Ok(updateEmployee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployees(int id)
        {
            var deleteEmployee = dBContext.Employees.Find(id);

            if (deleteEmployee is null) 
            { 
                return NotFound(); 
            }

            if (id <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            dBContext.Employees.Remove(deleteEmployee);
            dBContext.SaveChanges();

            return Ok();
            //return NoContent();
        }
    }
}
