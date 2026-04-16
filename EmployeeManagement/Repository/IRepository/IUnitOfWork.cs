namespace EmployeeManagement.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IEmployeeRepository Employee { get; }

        void Save();

    }
}
