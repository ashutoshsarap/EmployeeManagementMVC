using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

    }
}
