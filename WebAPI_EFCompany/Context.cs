using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using WebAPI_EFCompany.Model;

namespace WebAPI_EFCompany
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public Context()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Company.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().OwnsOne(m => m.Member);
            /*modelBuilder.Entity<Employee>().Ignore(e => e.PositionId);
            modelBuilder.Entity<Employee>().Ignore(e => e.Position);*/
            modelBuilder.Entity<Position>().Ignore(e => e.Employees);
            modelBuilder.Entity<Position>().HasOne(d=> d.Head);
            //modelBuilder.Entity<Employee>().HasOne(e => e.Position).WithMany(p => p.Employees).HasForeignKey(e => e.PositionId);
            //modelBuilder.Entity<Position>().HasOne(e => e.Department).WithMany(p => p.Positions).HasForeignKey(e => e.DepartmentId);
            //modelBuilder.Entity<Position>().HasOne(p => p.Head);
            //modelBuilder.Entity<Department>().HasOne(p => p.Head);

            ContentFilling(modelBuilder);
        }

        private void ContentFilling(ModelBuilder modelBuilder)
        {
            //Employee dirEmp1 = new Employee() { Member = new Member { } };

            Department directorate = new Department() { Id = 1, Name = "Дирекция" };
            Department shop = new Department() { Id = 2, Name = "Котельный цех" };
            Department oppr = new Department() { Id = 3, Name = "ОППР" };

            Position director = new Position() { Id=1, Name = "Директор", Salary = 200000, VacationDayCount = 56, DepartmentId = 1 };
            Position dirSecretary = new Position() { Id = 2, Name = "Секретарь руководителя", Salary = 60000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfSecurity = new Position() { Id = 3, Name = "Заместитель директора по безопасности", Salary = 80000, VacationDayCount = 28, DepartmentId = 1};
            Position dirHeadOfAHO = new Position() { Id = 4, Name = "Заместитель директора по снабжению", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfPersonal = new Position() { Id = 5, Name = "Заместитель директора по кадрам", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };

            Position shopHead = new Position() { Id = 6, Name = "Начальник КЦ", Salary = 70000, VacationDayCount = 56, DepartmentId=2 };
            Position shopShiftHead = new Position() { Id = 7, Name = "Начальник смены КЦ", Salary = 60000, VacationDayCount = 44, DepartmentId=2 };
            Position shopSeniorMachinist = new Position() { Id = 8, Name = "Старший машинист", Salary = 55000, VacationDayCount = 44, DepartmentId=2 };
            Position shopBoilerMachinist = new Position() { Id = 9, Name = "Машинист котлов", Salary = 50000, VacationDayCount = 44, DepartmentId=2 };
            Position shopBoilerCrawler = new Position() { Id = 10, Name = "Обходчик по котельному оборудованию", Salary = 45000, VacationDayCount = 44, DepartmentId=2 };
            Position shopMillEquipCrawler = new Position() { Id = 11, Name = "Обходчик по мельничному оборудованию", Salary = 40000, VacationDayCount = 44, DepartmentId=2 };
            Position shopAshRemovalCrawler = new Position() { Id = 12, Name = "Обходчик по злоудалению", Salary = 35000, VacationDayCount = 44, DepartmentId=2 };

            Position opprHead = new Position() { Id = 13, Name = "Начальник ОППР", Salary = 70000, VacationDayCount = 28, DepartmentId=3 };
            Position opprDeputyHead = new Position() { Id = 14, Name = "Заместитель начальника ОППР", Salary = 65000, VacationDayCount = 28, DepartmentId=3 };
            Position opprLeadEngineer = new Position() { Id = 15, Name = "Ведущий инженер ОППР", Salary = 50000, VacationDayCount = 28, DepartmentId=3 };
            Position opprEstimator = new Position() { Id = 16, Name = "Сметчик", Salary = 55000, VacationDayCount = 28, DepartmentId=3 };
            Position opprEngineer = new Position() { Id = 17, Name = "Инженер ОППР", Salary = 45000, VacationDayCount = 28, DepartmentId=3 };



            modelBuilder.Entity<Department>().HasData(new Department[] { directorate, shop,oppr });
            modelBuilder.Entity<Position>().HasData(new Position[] { director, dirSecretary, dirHeadOfSecurity, dirHeadOfAHO, dirHeadOfPersonal, 
                                                                     shopHead, shopShiftHead, shopSeniorMachinist, shopBoilerMachinist,shopBoilerCrawler,shopMillEquipCrawler,shopAshRemovalCrawler,
                                                                     opprHead,opprDeputyHead,opprLeadEngineer,opprEstimator,opprEngineer});
        }
    }
}
