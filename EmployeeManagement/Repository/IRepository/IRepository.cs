using System.Linq.Expressions;

namespace EmployeeManagement.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {

        public List<T> GetAll();
        public T Get(Expression<Func<T,bool>> filter);
        public void Add(T entity);
        
    }
}
