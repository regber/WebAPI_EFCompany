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
    public class DepartmentController : ControllerBase
    {



        /// <summary>
        /// This is the API which will return a list of customers
        /// </summary>
        /// <returns>abrakadabra</returns>
        [HttpPost("AddDepartment")]
        public bool AddDepartment(string departmentName)
        {
            using (Context db = new Context())
            {
                try
                {
                    db.Departments.Add(new Department { Name = departmentName });

                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        [HttpDelete("DeleteDepartment")]
        public bool DeleteDepartment(int departmentId)
        {
            using (Context db = new Context())
            {
                try
                {
                    var department=db.Departments.FirstOrDefault(d => d.Id == departmentId);

                    db.Departments.Remove(department);

                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        [HttpGet("GetDepartments")]
        public JsonResult GetDepartments()
        {
            using (Context db = new Context())
            {
                var departments = db.Departments.Include(d => d.Head).Include(d => d.Positions).Select(d => new { Id = d.Id, Name = d.Name, Head = d.Head, PositionsCount = d.Positions.Count() }).ToList();

                return new JsonResult(departments);
            }
        }

        [HttpGet("GetDepartmentPositions")]
        public JsonResult GetDepartmentPositions(int departmentId)
        {
            ICollection<Position> departmentPositions=new List<Position>();

            using (Context db = new Context())
            {
                var department = db.Departments.Include(d => d.Positions).FirstOrDefault(d => d.Id == departmentId);

                if(department!=null)
                {
                    departmentPositions=department.Positions;
                }
            }

            return new JsonResult(departmentPositions);
        }

        [HttpGet("GetDepartmentEmployees")]
        public JsonResult GetDepartmentEmployees(int departmentId)
        {
            ICollection<Employee> departmentEmployees = new List<Employee>();

            using (Context db = new Context())
            {
                departmentEmployees = db.Employees.Where(e => e.Position.DepartmentId == departmentId).ToList();
            }

            return new JsonResult(departmentEmployees);
        }

        [HttpGet("GetDepartmentHead")]
        public JsonResult GetDepartmentHead(int departmentId)
        {
            Employee head = new Employee();

            using (Context db = new Context())
            {
                var department = db.Departments.Include(d => d.Head).FirstOrDefault(d => d.Id == departmentId);
                head = department?.Head;
            }

            return new JsonResult(head);
        }

        [HttpPut("SetDepartmentHead")]
        public bool SetDepartmentHead( int departmentId, int employeeId)
        {
            Employee head;

            using (Context db = new Context())
            {
                try
                {
                    head = db.Employees.FirstOrDefault(e => e.Id == employeeId);
                    var department = db.Departments.FirstOrDefault(d => d.Id == departmentId);

                    department.Head = head;

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
