using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_Project.Migrations
{
    public partial class RenameEmployeeTableToEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "employee",
                newName: "employees");

            // TODO: I don't know if this table has these indexes because when run these migrations the app complains that  the parameter @objname is ambiguous or the claimed @objtype (INDEX) is wrong.
            // migrationBuilder.RenameIndex(
            //     name: "IX_employee_pub_id",
            //     table: "employees",
            //     newName: "IX_employees_pub_id");
            //
            // migrationBuilder.RenameIndex(
            //     name: "IX_employee_job_id",
            //     table: "employees",
            //     newName: "IX_employees_job_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "employees",
                newName: "employee");

            // migrationBuilder.RenameIndex(
            //     name: "IX_employees_pub_id",
            //     table: "employee",
            //     newName: "IX_employee_pub_id");
            //
            // migrationBuilder.RenameIndex(
            //     name: "IX_employees_job_id",
            //     table: "employee",
            //     newName: "IX_employee_job_id");
        }
    }
}