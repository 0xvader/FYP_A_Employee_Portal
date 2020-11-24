using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Portal_Test.Migrations
{
    public partial class dbcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "P_path",
                table: "pmast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "P_title",
                table: "pmast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FATHERNM",
                table: "family",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MOTHERNM",
                table: "family",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_path",
                table: "pmast");

            migrationBuilder.DropColumn(
                name: "P_title",
                table: "pmast");

            migrationBuilder.DropColumn(
                name: "FATHERNM",
                table: "family");

            migrationBuilder.DropColumn(
                name: "MOTHERNM",
                table: "family");
        }
    }
}
