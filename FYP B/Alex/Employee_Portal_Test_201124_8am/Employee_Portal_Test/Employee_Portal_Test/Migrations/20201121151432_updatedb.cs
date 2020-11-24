using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Portal_Test.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "INAME",
                table: "pmast",
                unicode: false,
                fixedLength: true,
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "INAME",
                table: "pmast",
                type: "char(3)",
                unicode: false,
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
