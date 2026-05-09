using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController(ApplicationDbContext context) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetAllEmployees()
  {
    try
    {
      var employees = await context.Employees.ToListAsync();
      return Ok(employees);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetEmployeeById(Guid id)
  {
    try
    {
      var employee = await context.Employees.FindAsync(id);

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
  public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
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
      await context.SaveChangesAsync();

      return Ok(employee);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
  {
    try
    {
      var employee = await context.Employees.FindAsync(id);

      if (employee == null)
      {
        return NotFound();
      }

      employee.Name = updateEmployeeDto.Name;
      employee.Email = updateEmployeeDto.Email;
      employee.Phone = updateEmployeeDto.Phone;
      employee.Salary = updateEmployeeDto.Salary;

      await context.SaveChangesAsync();
      return Ok(employee);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteEmployee(Guid id)
  {
    try
    {
      var employee = await context.Employees.FindAsync(id);

      if (employee == null)
      {
        return NotFound();
      }

      context.Employees.Remove(employee);
      await context.SaveChangesAsync();
      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }
}
