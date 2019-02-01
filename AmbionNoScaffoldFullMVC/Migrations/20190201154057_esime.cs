using Microsoft.EntityFrameworkCore.Migrations;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    public partial class esime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentStatus",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StudentStatus",
                table: "Student",
                nullable: false,
                defaultValue: false);
        }
    }
}
