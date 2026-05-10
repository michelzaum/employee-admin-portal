using EmployeeAdminPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Infra.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<Employee> Employees { get; set; }
  }
}
