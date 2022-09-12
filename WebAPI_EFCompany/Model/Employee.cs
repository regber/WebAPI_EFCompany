using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_EFCompany.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public Member Member { get; set; }
    }
}
