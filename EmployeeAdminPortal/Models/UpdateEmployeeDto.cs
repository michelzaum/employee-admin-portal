using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models;

public class UpdateEmployeeDto
{
  [Required(ErrorMessage = "Name is required")]
  [StringLength(100)]
  public required string Name { get; set; }
  
  [Required]
  [EmailAddress(ErrorMessage = "Invalid e-mail format")]
  public required string Email { get; set; }
  
  [Phone]
  public string? Phone { get; set; }
  
  [Range(0, 1000000)]
  public decimal Salary { get; set; }
}
