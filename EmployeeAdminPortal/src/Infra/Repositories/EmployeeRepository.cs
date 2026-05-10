using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Domain.Interfaces;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Infra.Data;

namespace EmployeeAdminPortal.Infra.Repositories;

public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeeRepository
{
  public Task<List<Employee>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Employee> GetByIdAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<Employee> CreateAsync(AddEmployeeDto addEmployeeDto)
  {
    throw new NotImplementedException();
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