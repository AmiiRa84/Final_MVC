using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Entities
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }

    }
}
