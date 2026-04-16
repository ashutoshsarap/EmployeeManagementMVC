using EmployeeManagement.Data;
using EmployeeManagement.Models.Entity;
using EmployeeManagement.Repository.IRepository;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : Repository<EmployeeEntity>, IEmployeeRepository
    {

        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                employee.IsActive = false;
            }

        }

        public void Update(EmployeeEntity employee)
        {
            var existingEmployee = _db.Employees.FirstOrDefault(e => e.Id == employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.IsActive = employee.IsActive;
            }
        }
    }
}
