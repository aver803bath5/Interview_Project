using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_Project.Migrations
{
    public partial class MakeCountryColumnInPublishersTableRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "publishers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValueSql: "('USA')",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValueSql: "('USA')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "publishers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                defaultValueSql: "('USA')",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldDefaultValueSql: "('USA')");
        }
    }
}
