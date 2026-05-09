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
    try
    {
      var employees = context.Employees.ToList();
      return Ok(employees);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public IActionResult GetEmployeeById(Guid id)
  {
    try
    {
      var employee = context.Employees.Find(id);

      if (employee == null)
      {
        return NotFound();
      }

      return Ok(employee);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpPost]
  public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
  {
    try
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
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpPut("{id}")]
  public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
  {
    try
    {
      var employee = context.Employees.Find(id);

      if (employee == null)
      {
        return NotFound();
      }

      employee.Name = updateEmployeeDto.Name;
      employee.Email = updateEmployeeDto.Email;
      employee.Phone = updateEmployeeDto.Phone;
      employee.Salary = updateEmployeeDto.Salary;

      context.SaveChanges();
      return Ok(employee);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteEmployee(Guid id)
  {
    try
    {
      var employee = context.Employees.Find(id);

      if (employee == null)
      {
        return NotFound();
      }

      context.Employees.Remove(employee);
      context.SaveChanges();
      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }
}
