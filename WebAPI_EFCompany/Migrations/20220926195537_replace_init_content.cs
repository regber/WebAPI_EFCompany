using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_EFCompany.Migrations
{
    public partial class replace_init_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HeadId", "Name" },
                values: new object[] { 1, null, "Дирекция" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HeadId", "Name" },
                values: new object[] { 2, null, "Котельный цех" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HeadId", "Name" },
                values: new object[] { 3, null, "ОППР" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 1, 1, null, "Директор", 200000, 56 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 15, 3, null, "Ведущий инженер ОППР", 50000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 14, 3, null, "Заместитель начальника ОППР", 65000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 13, 3, null, "Начальник ОППР", 70000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 12, 2, null, "Обходчик по злоудалению", 35000, 44 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 11, 2, null, "Обходчик по мельничному оборудованию", 40000, 44 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 10, 2, null, "Обходчик по котельному оборудованию", 45000, 44 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 16, 3, null, "Сметчик", 55000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 9, 2, null, "Машинист котлов", 50000, 44 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 7, 2, null, "Начальник смены КЦ", 60000, 44 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 6, 2, null, "Начальник КЦ", 70000, 56 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 5, 1, null, "Заместитель директора по кадрам", 80000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 4, 1, null, "Заместитель директора по снабжению", 80000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 3, 1, null, "Заместитель директора по безопасности", 80000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 2, 1, null, "Секретарь руководителя", 60000, 28 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 8, 2, null, "Старший машинист", 55000, 44 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "HeadId", "Name", "Salary", "VacationDayCount" },
                values: new object[] { 17, 3, null, "Инженер ОППР", 45000, 28 });
        }
    }
}
