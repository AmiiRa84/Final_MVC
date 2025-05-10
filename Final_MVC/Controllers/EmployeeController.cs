using Company.DAL.Entities;
using Company.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartmentRepository _departmentRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
            _departmentRepository = new DepartmentRepository();
        }

        private void LoadDepartments()
        {
            var departments = _departmentRepository.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
           // employee.department = _departmentRepository.GetById(employee.DepartmentId);

                var result = _employeeRepository.Add(employee);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // If the save operation failed
                    LoadDepartments();
                    return View(employee);
                }
            
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();

            LoadDepartments();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeRepository.Update(employee);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            LoadDepartments();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            var result = _employeeRepository.Delete(employee);
            if (result > 0)
                return RedirectToAction("Index");

            return View(employee);
        }
    }
}