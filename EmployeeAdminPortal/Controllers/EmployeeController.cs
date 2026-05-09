using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(ApplicationDbContext context) : ControllerBase
{
  [HttpGet]
  public IActionResult GetAllEmployees()
  {
    var employees = context.Employees.ToList();
    return Ok(employees);
  }
}