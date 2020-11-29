using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Portal_Test.Migrations.Employee_Portal_TestDb
{
    public partial class importdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dept",
                table: "AspNetUsers",
                type: "varchar(30)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dept",
                table: "AspNetUsers");
        }
    }
}
