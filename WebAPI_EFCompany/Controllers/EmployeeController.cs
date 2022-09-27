using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_EFCompany.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_EFCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet("GetEmployee")]
        public JsonResult GetEmployee(int employeeId)
        {
            using (Context db = new Context())
            {
                var employee =db.Employees.FirstOrDefault(e => e.Id == employeeId);

                return new JsonResult(employee);
            }  
        }

        [HttpGet("GetEmployees")]
        public JsonResult GetEmployees()
        {
            ICollection<Employee> employees = new List<Employee>();

            using (Context db = new Context())
            {
                employees = db.Employees.ToList();
            }

            return new JsonResult(employees);
        }

        [HttpPost("AddEmployee")]
        public bool AddEmployee(int positionNumber, int age, string firstName, string lastName, string middleName, string passportSeries, string passportNumber )
        {
            using (Context db = new Context())
            {
                try
                {
                    var newEmployee = new Employee {PositionNumber = positionNumber, Member = new Member { Age= age, FirstName= firstName, LastName= lastName, MiddleName= middleName, PassportSeries= passportSeries, PassportNumber = passportNumber } };

                    db.Employees.Add(newEmployee);

                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        [HttpDelete("DeleteEmployee")]
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                using (Context db = new Context())
                {
                    var employee = db.Employees.FirstOrDefault(e => e.Id == employeeId);

                    db.Employees.Remove(employee);

                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut("EditEmployee")]
        public bool EditEmployee(int employeeId,int positionNumber, int age, string firstName, string lastName, string middleName, string passportSeries, string passportNumber)
        {


            using (Context db = new Context())
            {
                try
                {
                    var employee = db.Employees/*.Include(e=>e.Member).Include(e=>e.PositionNumber)*/.FirstOrDefault(e => e.Id == employeeId);
                    var perviousInfoPositionNimber = employee.PositionNumber;
                    var perviousInfoMember = employee.Member;

                    employee.PositionNumber = positionNumber==0? perviousInfoPositionNimber: positionNumber;

                    employee.Member = new Member {  Age = age==0? perviousInfoMember.Age:age, 
                                                    FirstName = firstName==null? perviousInfoMember.FirstName:firstName, 
                                                    LastName = lastName== null ? perviousInfoMember.LastName:lastName,
                                                    MiddleName = middleName== null ? perviousInfoMember.MiddleName:middleName, 
                                                    PassportSeries = passportSeries== null? perviousInfoMember.PassportSeries:passportSeries, 
                                                    PassportNumber = passportNumber== null ? perviousInfoMember.PassportNumber:passportNumber };

                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


    }
}
