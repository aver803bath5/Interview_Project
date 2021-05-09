using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_Project.Migrations
{
    public partial class MakeEmpIdColumnOfEmployeesTableRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "emp_id",
                table: "employees",
                type: "char(9)",
                unicode: false,
                fixedLength: true,
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(9)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 9,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "emp_id",
                table: "employees",
                type: "char(9)",
                unicode: false,
                fixedLength: true,
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(9)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 9);
        }
    }
}
