using EmployeeManagement.Data;
using EmployeeManagement.Repository.IRepository;

namespace EmployeeManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IEmployeeRepository Employee { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
        }
         public void Save()
        {
            _db.SaveChanges();
        }
    }
}
