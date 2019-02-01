using Microsoft.EntityFrameworkCore.Migrations;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    public partial class AddedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StudentStatus",
                table: "Student",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GradeStatus",
                table: "Grade",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AmbionStatus",
                table: "Ambion",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentStatus",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GradeStatus",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "AmbionStatus",
                table: "Ambion");
        }
    }
}
