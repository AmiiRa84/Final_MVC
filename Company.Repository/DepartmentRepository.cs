using Company.DAL.Data.DBContexts;
using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository
{
    public class DepartmentRepository
    {
        //me7tag access 3l db
        private readonly CompanyDBContext _context; //just reference leh access 3l department
        public DepartmentRepository()
        {
            _context = new CompanyDBContext(); //while creating object
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return _context.Departments.Find(id); //dwarli 3la l department lli bl id dah

        }
        //me7tagha terga3 int l create object blnesbali row
        public int Add(Department department)
        {
            _context.Add(department);//l7ad hn alsa msm34 fl database
            return _context.SaveChanges(); //indicates how many row affected in database 34an keda 3mmlt enha htrg3 int

        }
        public int Update(Department department)
        {
            _context.Update(department);
            return _context.SaveChanges();
        }
        public int Delete(Department department)
        {
            _context.Remove(department);
            return _context.SaveChanges();
        }


    }
}