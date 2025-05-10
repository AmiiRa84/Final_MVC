using Company.DAL.Entities;
using Company.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _repository;

        public DepartmentController()
        {
            _repository = new DepartmentRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get all departments from repository
            var departments = _repository.GetAll();

            // Pass the departments to the view
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.Add(department);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create department");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _repository.GetById(id);
            if (department is null)
                return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _repository.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.Update(department);
                if (result > 0)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Failed to update department");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _repository.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            var result = _repository.Delete(department);
            if (result > 0)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to delete department");
            return View(department);
        }
    }
}