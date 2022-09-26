using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_EFCompany.Model
{
    public class Employee
    {
        public int Id { get; set; }

        //[NotMapped]
        public int PositionId { get; set; }
        //[NotMapped]
        public Position Position { get; set; }

        public Member Member { get; set; }
    }
}
