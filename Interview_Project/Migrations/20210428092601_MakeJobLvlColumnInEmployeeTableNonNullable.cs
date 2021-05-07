using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_Project.Migrations
{
    public partial class MakeJobLvlColumnInEmployeeTableNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "job_lvl",
                table: "employee",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "((10))",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true,
                oldDefaultValueSql: "((10))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "job_lvl",
                table: "employee",
                type: "tinyint",
                nullable: true,
                defaultValueSql: "((10))",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "((10))");
        }
    }
}
