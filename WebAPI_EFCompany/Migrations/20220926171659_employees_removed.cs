using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_EFCompany.Migrations
{
    public partial class employees_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member_Id",
                table: "Employees",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Member_Id",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "PositionNumber" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "PositionNumber" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "PositionNumber" },
                values: new object[] { 3, 3 });
        }
    }
}
