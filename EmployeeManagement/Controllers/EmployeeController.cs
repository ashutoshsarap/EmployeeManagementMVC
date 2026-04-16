using EmployeeManagement.Models;
using EmployeeManagement.Models.DTO;
using EmployeeManagement.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            var employeeVMs = employees.Select(e => new EmployeeVM
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Position = e.Position
            }).ToList();
            return View(employeeVMs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDTO = new EmployeeDTO
                    {
                        Name = employeeVM.Name,
                        Email = employeeVM.Email,
                        Position = employeeVM.Position
                    };
                    _employeeService.Add(employeeDTO);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeVM = new EmployeeVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Position = employee.Position
            };
            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Update(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDTO = new EmployeeDTO
                    {
                        Id = employeeVM.Id,
                        Name = employeeVM.Name,
                        Email = employeeVM.Email,
                        Position = employeeVM.Position
                    };
                    _employeeService.Update(employeeDTO);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
