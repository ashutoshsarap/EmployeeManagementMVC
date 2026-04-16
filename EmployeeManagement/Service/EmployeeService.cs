using EmployeeManagement.Models.DTO;
using EmployeeManagement.Models.Entity;
using EmployeeManagement.Repository.IRepository;
using EmployeeManagement.Service.IService;

namespace EmployeeManagement.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(EmployeeDTO employeeDTO)
        {
            if (_unitOfWork.Employee.Get(e => e.Email == employeeDTO.Email) != null)
            {
                throw new Exception("Employee with the same email already exists.");
            }
            _unitOfWork.Employee.Add(new EmployeeEntity
            {
                Name = employeeDTO.Name,
                Email = employeeDTO.Email,
                Position = employeeDTO.Position,
                IsActive = true,
                Salary = 0 // Default salary, can be updated later
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var employee = _unitOfWork.Employee.Get(e => e.Id == id);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }
            employee.IsActive = false;
            _unitOfWork.Employee.Update(employee);
            _unitOfWork.Save();
        }

        public List<EmployeeDTO> GetAll()
        {
            return _unitOfWork.Employee.GetAll()
                .Where(e => e.IsActive)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Position = e.Position
                }).ToList();
        }

        public EmployeeDTO GetById(int id)
        {
            var employee = _unitOfWork.Employee.Get(e => e.Id == id && e.IsActive); 
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Position = employee.Position
            };
        }

        public void Update(EmployeeDTO employeeDTO)
        {
            var employee = _unitOfWork.Employee.Get(e => e.Id == employeeDTO.Id);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            employee.Name = employeeDTO.Name;
            employee.Email = employeeDTO.Email;
            employee.Position = employeeDTO.Position;
            _unitOfWork.Employee.Update(employee);
            _unitOfWork.Save();
        }
    }
}
