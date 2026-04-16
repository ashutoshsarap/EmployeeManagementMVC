using EmployeeManagement.Models.DTO;

namespace EmployeeManagement.Service.IService
{
    public interface IEmployeeService
    {

        public void Add(EmployeeDTO employeeDTO);
        public List<EmployeeDTO> GetAll();
        public EmployeeDTO GetById(int id);
        public void Update(EmployeeDTO employeeDTO);
        public void Delete(int id);
    }
}
