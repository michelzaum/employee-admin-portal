using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeAdminPortal.Application.Services.Interfaces;

public interface IEmployeeService
{
  Task<List<Employee>> GetAllAsync();
  Task<Employee?> GetByIdAsync(Guid id);
  Task<EntityEntry<Employee>> CreateAsync(Employee employee);
  Task<int> UpdateAsync(Guid id, UpdateEmployeeDto updateEmployeeDto);
  Task DeleteAsync(Guid id);
}
