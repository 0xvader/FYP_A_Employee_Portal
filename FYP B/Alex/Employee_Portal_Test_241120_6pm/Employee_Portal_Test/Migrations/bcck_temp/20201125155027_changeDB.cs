using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Portal_Test.Migrations.bcck_temp
{
    public partial class changeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocType",
                table: "Doc",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocType",
                table: "Doc");
        }
    }
}
