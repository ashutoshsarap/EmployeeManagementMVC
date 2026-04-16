using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Entity
{
    public class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;


    }
}
