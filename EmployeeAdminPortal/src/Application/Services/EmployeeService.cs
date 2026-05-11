using EmployeeAdminPortal.Application.Services.Interfaces;
using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Domain.Interfaces;
using EmployeeAdminPortal.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeAdminPortal.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
  public async Task<List<Employee>> GetAllAsync()
  {
    return await employeeRepository.GetAllAsync();
  }

  public async Task<Employee?> GetByIdAsync(Guid id)
  {
    return await employeeRepository.GetByIdAsync(id);
  }

  public async Task<EntityEntry<Employee>> CreateAsync(Employee employee)
  {
    return await employeeRepository.CreateAsync(employee);
  }

  public async Task<int> UpdateAsync(Guid id, UpdateEmployeeDto updateEmployeeDto)
  {
    return await employeeRepository.UpdateAsync(id, updateEmployeeDto);
  }

  public async Task DeleteAsync(Guid id)
  {
    await employeeRepository.DeleteAsync(id);
  }
}