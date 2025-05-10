using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

    }
}
