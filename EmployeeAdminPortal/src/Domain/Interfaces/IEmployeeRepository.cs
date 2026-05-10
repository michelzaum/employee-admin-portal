using EmployeeAdminPortal.Domain.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Domain.Interfaces;

public interface IEmployeeRepository
{
  Task<List<Employee>> GetAllAsync();
  Task<Employee> GetByIdAsync(Guid id);
  Task<Employee> CreateAsync(AddEmployeeDto addEmployeeDto);
  Task<Employee> UpdateAsync(Guid id, UpdateEmployeeDto updateEmployeeDto);
  Task DeleteAsync(int id);
}
