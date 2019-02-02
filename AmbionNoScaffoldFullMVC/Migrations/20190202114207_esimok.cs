using Microsoft.EntityFrameworkCore.Migrations;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    public partial class esimok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Grade",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Grade",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
