using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController(ApplicationDbContext context) : ControllerBase
{
  [HttpGet]
  public IActionResult GetAllEmployees()
  {
    var employees = context.Employees.ToList();
    return Ok(employees);
  }

  [HttpGet("{id}")]
  public IActionResult GetEmployeeById(Guid id)
  {
    var empployee = context.Employees.Find(id);

    if (empployee == null)
    {
      return NotFound();
    }

    return Ok(empployee);
  }

  [HttpPost]
  public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
  {
    var employee = new Employee
    {
      Name = addEmployeeDto.Name,
      Email = addEmployeeDto.Email,
      Phone = addEmployeeDto.Phone,
      Salary = addEmployeeDto.Salary
    };

    context.Employees.Add(employee);
    context.SaveChanges();

    return Ok(employee);
  }
}