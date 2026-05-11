using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Domain.Interfaces;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeAdminPortal.Infra.Repositories;

public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeeRepository
{
  public async Task<List<Employee>> GetAllAsync()
  {
    return await dbContext.Employees.ToListAsync();
  }

  public async Task<Employee?> GetByIdAsync(Guid id)
  {
    return await dbContext.Employees.FindAsync(id);
  }

  public async Task<EntityEntry<Employee>> CreateAsync(Employee employee)
  {
    var newEmployee = await dbContext.Employees.AddAsync(employee);
    await dbContext.SaveChangesAsync();

    return newEmployee;
  }

  public async Task<int> UpdateAsync(Guid id, UpdateEmployeeDto updateEmployeeDto)
  {
    return await dbContext.Employees
      .Where(e => e.Id == id)
      .ExecuteUpdateAsync(setters => setters
        .SetProperty(p => p.Email, updateEmployeeDto.Email)
        .SetProperty(p => p.Name, updateEmployeeDto.Name)
        .SetProperty(p => p.Phone, updateEmployeeDto.Phone)
        .SetProperty(p => p.Salary, updateEmployeeDto.Salary)
      );
  }

  public async Task DeleteAsync(Guid id)
  {
    // This should be improved
    var employee = await this.GetByIdAsync(id);

    if (employee != null)
    {
      dbContext.Employees.Remove(employee);
      await dbContext.SaveChangesAsync();
    }
  }
}