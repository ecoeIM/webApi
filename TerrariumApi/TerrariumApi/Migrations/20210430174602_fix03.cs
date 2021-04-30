using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TerrariumApi.Migrations
{
    public partial class fix03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStampOfCreation",
                table: "ScheduledTasksSet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStampOfExecution",
                table: "ScheduledTasksSet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStampOfCreation",
                table: "ScheduledTasksSet");

            migrationBuilder.DropColumn(
                name: "TimeStampOfExecution",
                table: "ScheduledTasksSet");
        }
    }
}
