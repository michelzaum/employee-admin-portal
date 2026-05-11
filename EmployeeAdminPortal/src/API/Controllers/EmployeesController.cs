using EmployeeAdminPortal.Application.Services.Interfaces;
using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController(IEmployeeService employeeService) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetAllEmployees()
  {
    try
    {
      var employees = await employeeService.GetAllAsync();
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
      var employee = await employeeService.GetByIdAsync(id);

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

      await employeeService.CreateAsync(employee);

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
      var employee = await employeeService.UpdateAsync(id, updateEmployeeDto);
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
      await employeeService.DeleteAsync(id);
      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }
}
