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
        /// Получить список отделов с основной информацией
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDepartments")]
        public JsonResult GetDepartments()
        {
            using (Context db = new Context())
            {
                var departments = db.Departments.Include(d => d.Head).Include(d => d.Positions).Select(d => new { Id = d.Id, Name = d.Name, Head = d.Head, PositionsCount = d.Positions.Count() }).ToList();

                return new JsonResult(departments);
            }
        }

        /// <summary>
        /// Получить список должностей отдела
        /// </summary>
        /// <param name="departmentId">Id отдела</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получить работников отдела
        /// </summary>
        /// <param name="departmentId">Id отдела</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получить главу отдела
        /// </summary>
        /// <param name="departmentId">Id отдела</param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавить отдел
        /// </summary>
        /// <param name="departmentName">Имя отдела</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удалить отдел с указанным Id
        /// </summary>
        /// <param name="departmentId">Id отдела</param>
        /// <returns>Возвращает true если операция прошла успешно</returns>
        [HttpDelete("DeleteDepartment")]
        public bool DeleteDepartment(int departmentId)
        {
            using (Context db = new Context())
            {
                try
                {
                    var department = db.Departments.FirstOrDefault(d => d.Id == departmentId);

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

        /// <summary>
        /// Изменить данные отдела
        /// </summary>
        /// <param name="departmentId">Id отдела</param>
        /// <param name="departmentName">Новое название отдела</param>
        /// <returns></returns>
        [HttpPut("EditDepartment")]
        public bool EditDepartment(int departmentId, string departmentName)
        {

            using (Context db = new Context())
            {
                try
                {
                    var department = db.Departments.FirstOrDefault(e => e.Id == departmentId);

                    var perviousDepartmentName = department.Name;

                    department.Name = departmentName == null ? perviousDepartmentName : departmentName;

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
        /// Назначить главу отдела
        /// </summary>
        /// <param name="departmentId">Id отдела</param>
        /// <param name="employeeId">Id работника</param>
        /// <returns></returns>
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
