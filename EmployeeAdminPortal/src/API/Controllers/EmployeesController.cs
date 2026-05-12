using EmployeeAdminPortal.Application.Services.Interfaces;
using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetAllEmployees()
  {
    try
    {
      logger.LogInformation("Fetching all employees");
      var employees = await employeeService.GetAllAsync();
      return Ok(employees);
    }
    catch (Exception ex)
    {
      logger.LogError($"Error fetching all employees: {ex.Message}");
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetEmployeeById(Guid id)
  {
    try
    {
      logger.LogInformation("Fetching employee by id");
      var employee = await employeeService.GetByIdAsync(id);

      if (employee == null)
      {
        return NotFound();
      }

      return Ok(employee);
    }
    catch (Exception ex)
    {
      logger.LogError($"Error fetching employee with id {id}: {ex.Message}");
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpPost]
  public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
  {
    try
    {
      logger.LogInformation("Creating new employee");
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
      logger.LogError($"Error creating new employee {ex.Message}");
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
  {
    try
    {
      logger.LogInformation("Updating employee");
      var employee = await employeeService.UpdateAsync(id, updateEmployeeDto);
      return Ok(employee);
    }
    catch (Exception ex)
    {
      logger.LogError($"Error updating employee with id {id}: {ex.Message}");
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteEmployee(Guid id)
  {
    try
    {
      logger.LogInformation($"Deleting employee with id {id}");
      await employeeService.DeleteAsync(id);
      return Ok();
    }
    catch (Exception ex)
    {
      logger.LogError($"Error deleting employee with id {id}: {ex.Message}");
      return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
  }
}
