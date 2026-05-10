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

  public Task<Employee> UpdateAsync(Guid id, UpdateEmployeeDto updateEmployeeDto)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }
}