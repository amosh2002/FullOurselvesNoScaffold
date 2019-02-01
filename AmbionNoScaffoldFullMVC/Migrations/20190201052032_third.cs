using Microsoft.EntityFrameworkCore.Migrations;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_GradeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "CurrentGradeID",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurrentGradeID",
                table: "Student",
                column: "CurrentGradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grade_CurrentGradeID",
                table: "Student",
                column: "CurrentGradeID",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grade_CurrentGradeID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CurrentGradeID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurrentGradeID",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
