using Demo.Domain.Entities;
using Demo.EmployeeAdminPortal.DTOs;
using Demo.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var result = _dbContext.Employees.ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto employeeDto)
        {
            var employeeEntity = new Employee
            {
                Name = employeeDto.Name,
                Phone = employeeDto.Phone,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary

            };
            _dbContext.Employees.Add(employeeEntity);
            _dbContext.SaveChanges();

            return Ok(employeeEntity);

        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee =  _dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDto employeeDto)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee is null)
                return NotFound();

            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Phone = employeeDto.Phone;
            employee.Salary = employeeDto.Salary;

            _dbContext.SaveChanges();
            return Ok(employee);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee is null)
                return NotFound();

            _dbContext.Remove(employee);
            _dbContext.SaveChanges();
            return Ok(employee);
        }
    }
}
