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
    public class PositionController : Controller
    {
        /// <summary>
        /// Получить должность по Id
        /// </summary>
        /// <param name="positionId">Id должности</param>
        /// <returns></returns>
        [HttpGet("GetPosition")]
        public JsonResult GetPosition(int positionId)
        {
            using (Context db = new Context())
            {
                var position = db.Positions.FirstOrDefault(p => p.Id == positionId);

                return new JsonResult(position);
            }
        }

        /// <summary>
        /// Получить список должностей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPositions")]
        public JsonResult GetPositions()
        {
            ICollection<Position> positions = new List<Position>();

            using (Context db = new Context())
            {
                positions = db.Positions.ToList();
            }

            return new JsonResult(positions);
        }

        /// <summary>
        /// Добавить должность
        /// </summary>
        /// <param name="departmentId">Id отдела куда добавляется должность</param>
        /// <param name="name">Название должности</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="vacationDayCount">Отпускные дни</param>
        /// <param name="headId">Руководитель должности</param>
        /// <returns></returns>
        [HttpPost("AddPosition")]
        public bool AddPosition(int departmentId, string name, int salary, int vacationDayCount,int headId)
        {
            using (Context db = new Context())
            {

                try
                {
                    var head = db.Employees.FirstOrDefault(e => e.Id == headId);
                    var newPosition = new Position { DepartmentId = departmentId, Name = name, Salary = salary, VacationDayCount = vacationDayCount, Head = head };

                    db.Positions.Add(newPosition);

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
        /// Удалить должность по Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpDelete("DeletePosition")]
        public bool DeletePosition(int positionId)
        {
            using (Context db = new Context())
            {
                try
                {
                    var position=db.Positions.FirstOrDefault(p=>p.Id== positionId);

                    db.Positions.Remove(position);

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
        /// Изменить должность
        /// </summary>
        /// <param name="positionId">Id должности</param>
        /// <param name="departmentId">Id отдела</param>
        /// <param name="name">Название должности</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="vacationDayCount">Отпускные дни</param>
        /// <param name="headId">Руководитель должности</param>
        /// <returns></returns>
        [HttpPut("EditPosition")]
        public bool EditPosition(int positionId, int departmentId, string name, int salary, int vacationDayCount, int headId)
        {
            using (Context db = new Context())
            {
                try
                {
                    var position = db.Positions.Include(p=>p.Head).FirstOrDefault(e => e.Id == positionId);


                    position.Head = headId == 0 ? position.Head : db.Employees.FirstOrDefault(e=>e.Id== headId);
                    position.Name = name == null ? position.Name : name;
                    position.Salary = salary == 0 ? position.Salary : salary;
                    position.VacationDayCount = vacationDayCount == 0 ? position.VacationDayCount : vacationDayCount;
                    position.DepartmentId = departmentId == 0 ? position.DepartmentId : departmentId;

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
        /// Назначить руководителя должности
        /// </summary>
        /// <param name="positionId">Id должности</param>
        /// <param name="employeeId">Id работника</param>
        /// <returns></returns>
        [HttpPut("SetPositionHead")]
        public bool SetPositionHead(int positionId,int employeeId)
        {
            using (Context db = new Context())
            {
                try
                {
                    var position = db.Positions.FirstOrDefault(p => p.Id == positionId);
                    var head = db.Employees.FirstOrDefault(e => e.Id == employeeId);

                    position.Head = head;

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
