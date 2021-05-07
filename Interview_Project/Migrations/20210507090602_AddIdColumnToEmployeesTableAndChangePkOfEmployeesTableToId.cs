using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_Project.Migrations
{
    public partial class AddIdColumnToEmployeesTableAndChangePkOfEmployeesTableToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_emp_id",
                table: "employees");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "employees");

            migrationBuilder.AlterColumn<string>(
                name: "emp_id",
                table: "employees",
                type: "char(9)",
                unicode: false,
                fixedLength: true,
                maxLength: 9,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(9)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_emp_id",
                table: "employees",
                column: "emp_id")
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
