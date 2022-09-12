using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_EFCompany.Model
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Employee Head { get; set; }

        public ICollection<Position> Positions { get; set; }
    }
}
