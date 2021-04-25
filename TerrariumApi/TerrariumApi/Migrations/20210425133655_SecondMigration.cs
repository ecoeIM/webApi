using Microsoft.EntityFrameworkCore.Migrations;

namespace TerrariumApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVentOn",
                table: "TerrariumDataSnapshot",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVentOn",
                table: "TerrariumDataSet",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVentOn",
                table: "TerrariumDataSnapshot");

            migrationBuilder.DropColumn(
                name: "IsVentOn",
                table: "TerrariumDataSet");
        }
    }
}
