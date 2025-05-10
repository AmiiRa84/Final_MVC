using Company.DAL.Data.DBContexts;
using Company.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Company.Repository
{
    public class EmployeeRepository
    {
        private readonly CompanyDBContext _context;

        public EmployeeRepository()
        {
            _context = new CompanyDBContext();
        }

        //public IEnumerable<Employee> GetAll() => _context.Employees.ToList();
        public IEnumerable<Employee> GetAll() => _context.Employees.Include(e => e.department).ToList();

        public Employee GetById(int id) => _context.Employees.Find(id);

        public int Add(Employee employee)
        {
            // Make sure Department exists before adding
            var departmentExists = _context.Departments.Any(d => d.Id == employee.DepartmentId);
            if (!departmentExists)
            {
                return 0; // Indicate failure
            }

            _context.Employees.Add(employee);
            return _context.SaveChanges();
        }
        public int Update(Employee Emp)
        {
            _context.Employees.Update(Emp);
            // return how many row affected in DB
            return _context.SaveChanges();
        }
        public int Delete(Employee Emp)
        {
            _context.Employees.Remove(Emp);
            // return how many row affected in DB
            return _context.SaveChanges();
        }




    }

}