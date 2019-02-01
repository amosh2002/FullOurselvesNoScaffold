using Microsoft.EntityFrameworkCore.Migrations;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmbionId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_AmbionId",
                table: "Student",
                column: "AmbionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Ambion_AmbionId",
                table: "Student",
                column: "AmbionId",
                principalTable: "Ambion",
                principalColumn: "AmbionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Ambion_AmbionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AmbionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_GradeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AmbionId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Student");
        }
    }
}
