using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_Project.Migrations
{
    public partial class RenameFKConstrainsInEmployeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__employee__job_id__48CFD27E",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK__employee__pub_id__4BAC3F29",
                table: "employees");

            migrationBuilder.AddForeignKey(
                name: "FK__employees__job_id__48CFD27E",
                table: "employees",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "job_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__employees__pub_id__4BAC3F29",
                table: "employees",
                column: "pub_id",
                principalTable: "publishers",
                principalColumn: "pub_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__employees__job_id__48CFD27E",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK__employees__pub_id__4BAC3F29",
                table: "employees");

            migrationBuilder.AddForeignKey(
                name: "FK__employee__job_id__48CFD27E",
                table: "employees",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "job_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__employee__pub_id__4BAC3F29",
                table: "employees",
                column: "pub_id",
                principalTable: "publishers",
                principalColumn: "pub_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
