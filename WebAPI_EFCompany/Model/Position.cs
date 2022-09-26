using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_EFCompany.Model
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Salary { get; set; }
        public int VacationDayCount { get; set;}

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public Employee? Head { get; set; }

        //[NotMapped]
        public ICollection<Employee> Employees { get; set; }
    }
}
