using EmployeeManagement.Models.Entity;

namespace EmployeeManagement.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
        void Update(EmployeeEntity employee );
        void Delete(int id);

    }
}
