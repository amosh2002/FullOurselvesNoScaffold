using Microsoft.EntityFrameworkCore.Migrations;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Ambion_AmbionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AmbionId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AmbionId",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "CurrentAmbionID",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurrentAmbionID",
                table: "Student",
                column: "CurrentAmbionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Ambion_CurrentAmbionID",
                table: "Student",
                column: "CurrentAmbionID",
                principalTable: "Ambion",
                principalColumn: "AmbionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Ambion_CurrentAmbionID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CurrentAmbionID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurrentAmbionID",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "AmbionId",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_AmbionId",
                table: "Student",
                column: "AmbionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Ambion_AmbionId",
                table: "Student",
                column: "AmbionId",
                principalTable: "Ambion",
                principalColumn: "AmbionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
