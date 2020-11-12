using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Portal_Test.Migrations.Employee_Portal_TestDb
{
    public partial class UpdateAspNetUserTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Empname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Empname",
                table: "AspNetUsers",
                newName: "Name");
        }
    }
}
