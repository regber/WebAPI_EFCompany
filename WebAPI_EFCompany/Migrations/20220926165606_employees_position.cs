using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_EFCompany.Migrations
{
    public partial class employees_position : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Employees",
                newName: "PositionNumber");

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                table: "Positions",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Positions_HeadId",
                table: "Positions",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionNumber",
                table: "Employees",
                column: "PositionNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionNumber",
                table: "Employees",
                column: "PositionNumber",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Employees_HeadId",
                table: "Positions",
                column: "HeadId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionNumber",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Employees_HeadId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_HeadId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionNumber",
                table: "Employees");

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

            migrationBuilder.DropColumn(
                name: "HeadId",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "PositionNumber",
                table: "Employees",
                newName: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
