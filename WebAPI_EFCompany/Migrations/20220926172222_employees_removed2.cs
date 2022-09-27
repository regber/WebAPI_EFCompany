using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_EFCompany.Migrations
{
    public partial class employees_removed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Member_Id",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
