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
    public class CompanyController : ControllerBase
    {

        public CompanyController()
        {
            using (Context db = new Context())
            {
                if(db.Departments.Count()==0)
                {
                    InitContentFilling(db);
                }
            }
        }
        private void InitContentFilling(Context db)
        {

            Department directorate = new Department() { Id = 1, Name = "Дирекция" };
            Department shop = new Department() { Id = 2, Name = "Котельный цех" };
            Department oppr = new Department() { Id = 3, Name = "ОППР" };


            Position director = new Position() { Id = 1, Name = "Директор", Salary = 200000, VacationDayCount = 56, DepartmentId = 1 };
            Position dirSecretary = new Position() { Id = 2, Name = "Секретарь руководителя", Salary = 60000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfSecurity = new Position() { Id = 3, Name = "Заместитель директора по безопасности", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfAHO = new Position() { Id = 4, Name = "Заместитель директора по снабжению", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfPersonal = new Position() { Id = 5, Name = "Заместитель директора по кадрам", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };

            Position shopHead = new Position() { Id = 6, Name = "Начальник КЦ", Salary = 70000, VacationDayCount = 56, DepartmentId = 2 };
            Position shopShiftHead = new Position() { Id = 7, Name = "Начальник смены КЦ", Salary = 60000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopSeniorMachinist = new Position() { Id = 8, Name = "Старший машинист", Salary = 55000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopBoilerMachinist = new Position() { Id = 9, Name = "Машинист котлов", Salary = 50000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopBoilerCrawler = new Position() { Id = 10, Name = "Обходчик по котельному оборудованию", Salary = 45000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopMillEquipCrawler = new Position() { Id = 11, Name = "Обходчик по мельничному оборудованию", Salary = 40000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopAshRemovalCrawler = new Position() { Id = 12, Name = "Обходчик по злоудалению", Salary = 35000, VacationDayCount = 44, DepartmentId = 2 };

            Position opprHead = new Position() { Id = 13, Name = "Начальник ОППР", Salary = 70000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprDeputyHead = new Position() { Id = 14, Name = "Заместитель начальника ОППР", Salary = 65000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprLeadEngineer = new Position() { Id = 15, Name = "Ведущий инженер ОППР", Salary = 50000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprEstimator = new Position() { Id = 16, Name = "Сметчик", Salary = 55000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprEngineer = new Position() { Id = 17, Name = "Инженер ОППР", Salary = 45000, VacationDayCount = 28, DepartmentId = 3 };


            Employee directorEmpl = new Employee { Id = 1, PositionNumber = 1, Member = new Member { LastName = "Пушной", FirstName = "Алексей", MiddleName = "Александрович", Age = 51, PassportSeries = "3208", PassportNumber = "123456" } };
            Employee dirSecretaryEmpl = new Employee { Id = 2, PositionNumber = 2, Member = new Member { LastName = "Агалакова", FirstName = "Мария", MiddleName = "Сергеевна", Age = 25, PassportSeries = "3208", PassportNumber = "143456" } };
            Employee dirHeadOfSecurityEmpl = new Employee { Id = 3, PositionNumber = 3, Member = new Member { LastName = "Галкин", FirstName = "Сергей", MiddleName = "Викторович", Age = 46, PassportSeries = "3208", PassportNumber = "144456" } };
            Employee dirHeadOfAHOEmpl = new Employee { Id = 4, PositionNumber = 4, Member = new Member { LastName = "Любимов", FirstName = "Александр", MiddleName = "Сергеевич", Age = 35, PassportSeries = "3208", PassportNumber = "444456" } };
            Employee dirHeadOfPersonalEmpl = new Employee { Id = 5, PositionNumber = 5, Member = new Member { LastName = "Юрченко", FirstName = "Ольга", MiddleName = "Александровна", Age = 42, PassportSeries = "3208", PassportNumber = "454456" } };

            Employee shopHeadEmpl = new Employee { Id = 6, PositionNumber = 6, Member = new Member { LastName = "Юркин", FirstName = "Сергей", MiddleName = "Евгеньевич", Age = 40, PassportSeries = "3208", PassportNumber = "454455" } };
            Employee shopShiftHeadEmpl1 = new Employee { Id = 7, PositionNumber = 7, Member = new Member { LastName = "Невадеев", FirstName = "Алдексей", MiddleName = "Марсович", Age = 45, PassportSeries = "3208", PassportNumber = "554455" } };
            Employee shopShiftHeadEmpl2 = new Employee { Id = 8, PositionNumber = 7, Member = new Member { LastName = "Пуряев", FirstName = "Константин", MiddleName = "Викторович", Age = 38, PassportSeries = "3208", PassportNumber = "154455" } };
            Employee shopSeniorMachinistEmpl1 = new Employee { Id = 9, PositionNumber = 8, Member = new Member { LastName = "Агутин", FirstName = "Сергей", MiddleName = "Миронович", Age = 21, PassportSeries = "3208", PassportNumber = "114455" } };
            Employee shopSeniorMachinistEmpl2 = new Employee { Id = 10, PositionNumber = 8, Member = new Member { LastName = "Агутин", FirstName = "Мирон", MiddleName = "Сергеевич", Age = 48, PassportSeries = "3208", PassportNumber = "111455" } };
            Employee shopBoilerMachinistEmpl1 = new Employee { Id = 11, PositionNumber = 9, Member = new Member { LastName = "Волков", FirstName = "Михаил", MiddleName = "Алексеевич", Age = 45, PassportSeries = "3208", PassportNumber = "111155" } };
            Employee shopBoilerMachinistEmpl2 = new Employee { Id = 12, PositionNumber = 9, Member = new Member { LastName = "Смирнов", FirstName = "Иван", MiddleName = "Александрович", Age = 35, PassportSeries = "3208", PassportNumber = "111125" } };
            Employee shopBoilerCrawlerEmpl1 = new Employee { Id = 13, PositionNumber = 10, Member = new Member { LastName = "Пушкин", FirstName = "Сергей", MiddleName = "Сергеевич", Age = 21, PassportSeries = "3208", PassportNumber = "554455" } };
            Employee shopBoilerCrawlerEmpl2 = new Employee { Id = 14, PositionNumber = 10, Member = new Member { LastName = "Шишкин", FirstName = "Мирон", MiddleName = "Сергеевич", Age = 48, PassportSeries = "3208", PassportNumber = "551455" } };
            Employee shopBoilerCrawlerEmpl3 = new Employee { Id = 15, PositionNumber = 10, Member = new Member { LastName = "Сергеев", FirstName = "Михаил", MiddleName = "Александрович", Age = 45, PassportSeries = "3208", PassportNumber = "551155" } };
            Employee shopBoilerCrawlerEmpl4 = new Employee { Id = 16, PositionNumber = 10, Member = new Member { LastName = "Валуев", FirstName = "Иван", MiddleName = "Евгеньевич", Age = 35, PassportSeries = "3208", PassportNumber = "551125" } };
            Employee shopMillEquipCrawlerEmpl1 = new Employee { Id = 17, PositionNumber = 11, Member = new Member { LastName = "Ермилов", FirstName = "Сергей", MiddleName = "Иванович", Age = 28, PassportSeries = "3208", PassportNumber = "551166" } };
            Employee shopMillEquipCrawlerEmpl2 = new Employee { Id = 18, PositionNumber = 11, Member = new Member { LastName = "Потапов", FirstName = "Алексей", MiddleName = "Алексеевич", Age = 50, PassportSeries = "3208", PassportNumber = "551266" } };
            Employee shopAshRemovalCrawlerEmpl1 = new Employee { Id = 19, PositionNumber = 12, Member = new Member { LastName = "Милютин", FirstName = "Виньямин", MiddleName = "Юргентович", Age = 24, PassportSeries = "3208", PassportNumber = "551366" } };
            Employee shopAshRemovalCrawlerEmpl2 = new Employee { Id = 20, PositionNumber = 12, Member = new Member { LastName = "Вачовски", FirstName = "Алексей", MiddleName = "Алексеевич", Age = 35, PassportSeries = "3208", PassportNumber = "551466" } };
            Employee shopAshRemovalCrawlerEmpl3 = new Employee { Id = 21, PositionNumber = 12, Member = new Member { LastName = "Перельман", FirstName = "Александр", MiddleName = "Алексеевич", Age = 48, PassportSeries = "3208", PassportNumber = "551566" } };
            Employee shopAshRemovalCrawlerEmpl4 = new Employee { Id = 22, PositionNumber = 12, Member = new Member { LastName = "Георгиев", FirstName = "Василий", MiddleName = "Васильевич", Age = 45, PassportSeries = "3208", PassportNumber = "551666" } };

            Employee opprHeadEmpl = new Employee { Id = 23, PositionNumber = 13, Member = new Member { LastName = "Пузырьков", FirstName = "Иван", MiddleName = "Иванович", Age = 53, PassportSeries = "3208", PassportNumber = "552666" } };
            Employee opprDeputyHeadEmpl = new Employee { Id = 24, PositionNumber = 14, Member = new Member { LastName = "Черная", FirstName = "Алла", MiddleName = "Евгеньевна", Age = 50, PassportSeries = "3208", PassportNumber = "553666" } };
            Employee opprLeadEngineerEmpl1 = new Employee { Id = 25, PositionNumber = 15, Member = new Member { LastName = "Загребельный", FirstName = "Сергей", MiddleName = "Михайлович", Age = 51, PassportSeries = "3208", PassportNumber = "544666" } };
            Employee opprLeadEngineerEmpl2 = new Employee { Id = 26, PositionNumber = 15, Member = new Member { LastName = "Юнгблюд", FirstName = "Евгений", MiddleName = "Юрьевич", Age = 38, PassportSeries = "3208", PassportNumber = "554666" } };
            Employee opprLeadEngineerEmpl3 = new Employee { Id = 27, PositionNumber = 15, Member = new Member { LastName = "Шишкин", FirstName = "Станислав", MiddleName = "Андреевич", Age = 34, PassportSeries = "3208", PassportNumber = "555666" } };
            Employee opprEstimatorEmpl1 = new Employee { Id = 28, PositionNumber = 16, Member = new Member { LastName = "Ванеева", FirstName = "Ольга", MiddleName = "Александровна", Age = 48, PassportSeries = "3208", PassportNumber = "555566" } };
            Employee opprEstimatorEmpl2 = new Employee { Id = 29, PositionNumber = 16, Member = new Member { LastName = "Нарышкина", FirstName = "Любовь", MiddleName = "Александровна", Age = 50, PassportSeries = "3208", PassportNumber = "555766" } };
            Employee opprEngineerEmpl = new Employee { Id = 30, PositionNumber = 17, Member = new Member { LastName = "Любов", FirstName = "Денис", MiddleName = "Анатольевич", Age = 24, PassportSeries = "3208", PassportNumber = "555866" } };
            

            db.Departments.AddRange(new Department[] { directorate, shop, oppr });

            db.Positions.AddRange(new Position[] { director, dirSecretary, dirHeadOfSecurity, dirHeadOfAHO, dirHeadOfPersonal,
                                                   shopHead, shopShiftHead, shopSeniorMachinist, shopBoilerMachinist,shopBoilerCrawler,shopMillEquipCrawler,shopAshRemovalCrawler,
                                                   opprHead,opprDeputyHead,opprLeadEngineer,opprEstimator,opprEngineer});

            db.Employees.AddRange(new Employee[] { directorEmpl, dirSecretaryEmpl, dirHeadOfSecurityEmpl, dirHeadOfAHOEmpl, dirHeadOfPersonalEmpl,
                                                   shopHeadEmpl,shopShiftHeadEmpl1,shopShiftHeadEmpl2,shopSeniorMachinistEmpl1,shopSeniorMachinistEmpl2,shopBoilerMachinistEmpl1,shopBoilerMachinistEmpl2,shopBoilerCrawlerEmpl1,shopBoilerCrawlerEmpl2,shopBoilerCrawlerEmpl3, shopBoilerCrawlerEmpl4,shopMillEquipCrawlerEmpl1,shopMillEquipCrawlerEmpl2, shopAshRemovalCrawlerEmpl1, shopAshRemovalCrawlerEmpl2, shopAshRemovalCrawlerEmpl3, shopAshRemovalCrawlerEmpl4,
                                                   opprHeadEmpl,opprDeputyHeadEmpl,opprLeadEngineerEmpl1,opprLeadEngineerEmpl2, opprLeadEngineerEmpl3,opprEstimatorEmpl1,opprEstimatorEmpl2,opprEngineerEmpl});

            db.SaveChanges();

            directorate.Head = directorEmpl;
            shop.Head = shopHeadEmpl;
            oppr.Head = opprHeadEmpl;

            db.SaveChanges();
        }

        /// <summary>
        /// This is the API which will return a list of customers
        /// </summary>
        /// <returns>abrakadabra</returns>
        [HttpGet]
        public string Get()
        {
            string str = "";

            using (Context db = new Context())
            {
                var departments = db.Departments.Include(d=>d.Positions).ThenInclude(p=>p.Employees).ThenInclude(e=>e.Member).ToList();

                foreach (var d in departments)
                {
                    foreach(var p in d.Positions)
                    {
                        foreach(var e in p.Employees)
                        {
                            str += $"Name: {d.Name} PositName: {p.Name}  EmplName: {e.Member.FirstName}" + Environment.NewLine;
                        }
                        
                    }
                }
                return str;
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
