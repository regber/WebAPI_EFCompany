using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI_EFCompany.Model;

namespace WebAPI_EFCompany
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            using (Context db = new Context())
            {
                if (db.Departments.Count() == 0)
                {
                    InitContentFilling(db);
                }
            }
        }


        private void InitContentFilling(Context db)
        {

            Department directorate = new Department() { Id = 1, Name = "��������" };
            Department shop = new Department() { Id = 2, Name = "��������� ���" };
            Department oppr = new Department() { Id = 3, Name = "����" };


            Position director = new Position() { Id = 1, Name = "��������", Salary = 200000, VacationDayCount = 56, DepartmentId = 1 };
            Position dirSecretary = new Position() { Id = 2, Name = "��������� ������������", Salary = 60000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfSecurity = new Position() { Id = 3, Name = "����������� ��������� �� ������������", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfAHO = new Position() { Id = 4, Name = "����������� ��������� �� ���������", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };
            Position dirHeadOfPersonal = new Position() { Id = 5, Name = "����������� ��������� �� ������", Salary = 80000, VacationDayCount = 28, DepartmentId = 1 };

            Position shopHead = new Position() { Id = 6, Name = "��������� ��", Salary = 70000, VacationDayCount = 56, DepartmentId = 2 };
            Position shopShiftHead = new Position() { Id = 7, Name = "��������� ����� ��", Salary = 60000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopSeniorMachinist = new Position() { Id = 8, Name = "������� ��������", Salary = 55000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopBoilerMachinist = new Position() { Id = 9, Name = "�������� ������", Salary = 50000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopBoilerCrawler = new Position() { Id = 10, Name = "�������� �� ���������� ������������", Salary = 45000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopMillEquipCrawler = new Position() { Id = 11, Name = "�������� �� ����������� ������������", Salary = 40000, VacationDayCount = 44, DepartmentId = 2 };
            Position shopAshRemovalCrawler = new Position() { Id = 12, Name = "�������� �� �����������", Salary = 35000, VacationDayCount = 44, DepartmentId = 2 };

            Position opprHead = new Position() { Id = 13, Name = "��������� ����", Salary = 70000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprDeputyHead = new Position() { Id = 14, Name = "����������� ���������� ����", Salary = 65000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprLeadEngineer = new Position() { Id = 15, Name = "������� ������� ����", Salary = 50000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprEstimator = new Position() { Id = 16, Name = "�������", Salary = 55000, VacationDayCount = 28, DepartmentId = 3 };
            Position opprEngineer = new Position() { Id = 17, Name = "������� ����", Salary = 45000, VacationDayCount = 28, DepartmentId = 3 };


            Employee directorEmpl = new Employee { Id = 1, PositionNumber = 1, Member = new Member { LastName = "������", FirstName = "�������", MiddleName = "�������������", Age = 51, PassportSeries = "3208", PassportNumber = "123456" } };
            Employee dirSecretaryEmpl = new Employee { Id = 2, PositionNumber = 2, Member = new Member { LastName = "���������", FirstName = "�����", MiddleName = "���������", Age = 25, PassportSeries = "3208", PassportNumber = "143456" } };
            Employee dirHeadOfSecurityEmpl = new Employee { Id = 3, PositionNumber = 3, Member = new Member { LastName = "������", FirstName = "������", MiddleName = "����������", Age = 46, PassportSeries = "3208", PassportNumber = "144456" } };
            Employee dirHeadOfAHOEmpl = new Employee { Id = 4, PositionNumber = 4, Member = new Member { LastName = "�������", FirstName = "���������", MiddleName = "���������", Age = 35, PassportSeries = "3208", PassportNumber = "444456" } };
            Employee dirHeadOfPersonalEmpl = new Employee { Id = 5, PositionNumber = 5, Member = new Member { LastName = "�������", FirstName = "�����", MiddleName = "�������������", Age = 42, PassportSeries = "3208", PassportNumber = "454456" } };

            Employee shopHeadEmpl = new Employee { Id = 6, PositionNumber = 6, Member = new Member { LastName = "�����", FirstName = "������", MiddleName = "����������", Age = 40, PassportSeries = "3208", PassportNumber = "454455" } };
            Employee shopShiftHeadEmpl1 = new Employee { Id = 7, PositionNumber = 7, Member = new Member { LastName = "��������", FirstName = "��������", MiddleName = "��������", Age = 45, PassportSeries = "3208", PassportNumber = "554455" } };
            Employee shopShiftHeadEmpl2 = new Employee { Id = 8, PositionNumber = 7, Member = new Member { LastName = "������", FirstName = "����������", MiddleName = "����������", Age = 38, PassportSeries = "3208", PassportNumber = "154455" } };
            Employee shopSeniorMachinistEmpl1 = new Employee { Id = 9, PositionNumber = 8, Member = new Member { LastName = "������", FirstName = "������", MiddleName = "���������", Age = 21, PassportSeries = "3208", PassportNumber = "114455" } };
            Employee shopSeniorMachinistEmpl2 = new Employee { Id = 10, PositionNumber = 8, Member = new Member { LastName = "������", FirstName = "�����", MiddleName = "���������", Age = 48, PassportSeries = "3208", PassportNumber = "111455" } };
            Employee shopBoilerMachinistEmpl1 = new Employee { Id = 11, PositionNumber = 9, Member = new Member { LastName = "������", FirstName = "������", MiddleName = "����������", Age = 45, PassportSeries = "3208", PassportNumber = "111155" } };
            Employee shopBoilerMachinistEmpl2 = new Employee { Id = 12, PositionNumber = 9, Member = new Member { LastName = "�������", FirstName = "����", MiddleName = "�������������", Age = 35, PassportSeries = "3208", PassportNumber = "111125" } };
            Employee shopBoilerCrawlerEmpl1 = new Employee { Id = 13, PositionNumber = 10, Member = new Member { LastName = "������", FirstName = "������", MiddleName = "���������", Age = 21, PassportSeries = "3208", PassportNumber = "554455" } };
            Employee shopBoilerCrawlerEmpl2 = new Employee { Id = 14, PositionNumber = 10, Member = new Member { LastName = "������", FirstName = "�����", MiddleName = "���������", Age = 48, PassportSeries = "3208", PassportNumber = "551455" } };
            Employee shopBoilerCrawlerEmpl3 = new Employee { Id = 15, PositionNumber = 10, Member = new Member { LastName = "�������", FirstName = "������", MiddleName = "�������������", Age = 45, PassportSeries = "3208", PassportNumber = "551155" } };
            Employee shopBoilerCrawlerEmpl4 = new Employee { Id = 16, PositionNumber = 10, Member = new Member { LastName = "������", FirstName = "����", MiddleName = "����������", Age = 35, PassportSeries = "3208", PassportNumber = "551125" } };
            Employee shopMillEquipCrawlerEmpl1 = new Employee { Id = 17, PositionNumber = 11, Member = new Member { LastName = "�������", FirstName = "������", MiddleName = "��������", Age = 28, PassportSeries = "3208", PassportNumber = "551166" } };
            Employee shopMillEquipCrawlerEmpl2 = new Employee { Id = 18, PositionNumber = 11, Member = new Member { LastName = "�������", FirstName = "�������", MiddleName = "����������", Age = 50, PassportSeries = "3208", PassportNumber = "551266" } };
            Employee shopAshRemovalCrawlerEmpl1 = new Employee { Id = 19, PositionNumber = 12, Member = new Member { LastName = "�������", FirstName = "��������", MiddleName = "����������", Age = 24, PassportSeries = "3208", PassportNumber = "551366" } };
            Employee shopAshRemovalCrawlerEmpl2 = new Employee { Id = 20, PositionNumber = 12, Member = new Member { LastName = "��������", FirstName = "�������", MiddleName = "����������", Age = 35, PassportSeries = "3208", PassportNumber = "551466" } };
            Employee shopAshRemovalCrawlerEmpl3 = new Employee { Id = 21, PositionNumber = 12, Member = new Member { LastName = "���������", FirstName = "���������", MiddleName = "����������", Age = 48, PassportSeries = "3208", PassportNumber = "551566" } };
            Employee shopAshRemovalCrawlerEmpl4 = new Employee { Id = 22, PositionNumber = 12, Member = new Member { LastName = "��������", FirstName = "�������", MiddleName = "����������", Age = 45, PassportSeries = "3208", PassportNumber = "551666" } };

            Employee opprHeadEmpl = new Employee { Id = 23, PositionNumber = 13, Member = new Member { LastName = "���������", FirstName = "����", MiddleName = "��������", Age = 53, PassportSeries = "3208", PassportNumber = "552666" } };
            Employee opprDeputyHeadEmpl = new Employee { Id = 24, PositionNumber = 14, Member = new Member { LastName = "������", FirstName = "����", MiddleName = "����������", Age = 50, PassportSeries = "3208", PassportNumber = "553666" } };
            Employee opprLeadEngineerEmpl1 = new Employee { Id = 25, PositionNumber = 15, Member = new Member { LastName = "������������", FirstName = "������", MiddleName = "����������", Age = 51, PassportSeries = "3208", PassportNumber = "544666" } };
            Employee opprLeadEngineerEmpl2 = new Employee { Id = 26, PositionNumber = 15, Member = new Member { LastName = "�������", FirstName = "�������", MiddleName = "�������", Age = 38, PassportSeries = "3208", PassportNumber = "554666" } };
            Employee opprLeadEngineerEmpl3 = new Employee { Id = 27, PositionNumber = 15, Member = new Member { LastName = "������", FirstName = "���������", MiddleName = "���������", Age = 34, PassportSeries = "3208", PassportNumber = "555666" } };
            Employee opprEstimatorEmpl1 = new Employee { Id = 28, PositionNumber = 16, Member = new Member { LastName = "�������", FirstName = "�����", MiddleName = "�������������", Age = 48, PassportSeries = "3208", PassportNumber = "555566" } };
            Employee opprEstimatorEmpl2 = new Employee { Id = 29, PositionNumber = 16, Member = new Member { LastName = "���������", FirstName = "������", MiddleName = "�������������", Age = 50, PassportSeries = "3208", PassportNumber = "555766" } };
            Employee opprEngineerEmpl = new Employee { Id = 30, PositionNumber = 17, Member = new Member { LastName = "�����", FirstName = "�����", MiddleName = "�����������", Age = 24, PassportSeries = "3208", PassportNumber = "555866" } };


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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger Demo API",
                    Description = "Demo API for showing Swagger",
                    Version = "v1"
                });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddDbContext<Context>();
            
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                                                                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });
        }
    }
}
