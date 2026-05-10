using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeAdminPortal.Domain.Interfaces;

public interface IEmployeeRepository
{
  Task<List<Employee>> GetAllAsync();
  Task<Employee?> GetByIdAsync(Guid id);
  Task<EntityEntry<Employee>> CreateAsync(Employee employee);
  Task<Employee> UpdateAsync(Guid id, UpdateEmployeeDto updateEmployeeDto);
  Task DeleteAsync(int id);
}
