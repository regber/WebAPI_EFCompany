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
        /// <summary>
        /// Получить данные работника по его Id
        /// </summary>
        /// <param name="employeeId">Id работника</param>
        /// <returns></returns>
        [HttpGet("GetEmployee")]
        public JsonResult GetEmployee(int employeeId)
        {
            using (Context db = new Context())
            {
                var employee =db.Employees.FirstOrDefault(e => e.Id == employeeId);

                return new JsonResult(employee);
            }  
        }

        /// <summary>
        /// Получить список работников
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Добавить работника
        /// </summary>
        /// <param name="positionNumber">Id должности</param>
        /// <param name="age">Возраст работника</param>
        /// <param name="firstName">Имя работника</param>
        /// <param name="lastName">Фамилия работника</param>
        /// <param name="middleName">Отчество работника</param>
        /// <param name="passportSeries">Серия паспорта</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удалить работника по его Id
        /// </summary>
        /// <param name="employeeId">Id работника</param>
        /// <returns></returns>
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

        /// <summary>
        /// Изменить данные работника
        /// </summary>
        /// <param name="employeeId">Id работника</param>
        /// <param name="positionNumber">Id должности</param>
        /// <param name="age">Возраст работника</param>
        /// <param name="firstName">Имя работника</param>
        /// <param name="lastName">Фамилия работника</param>
        /// <param name="middleName">Отчество работника</param>
        /// <param name="passportSeries">Серия паспорта</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <returns></returns>
        [HttpPut("EditEmployee")]
        public bool EditEmployee(int employeeId,int positionNumber, int age, string firstName, string lastName, string middleName, string passportSeries, string passportNumber)
        {
            using (Context db = new Context())
            {
                try
                {
                    var employee = db.Employees.FirstOrDefault(e => e.Id == employeeId);
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
