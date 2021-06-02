using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TerrariumApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TerrariumDataSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    CarbonDioxideLevel = table.Column<double>(type: "REAL", nullable: false),
                    HumidityLevel = table.Column<double>(type: "REAL", nullable: false),
                    NaturalLightLevel = table.Column<double>(type: "REAL", nullable: false),
                    IsArtificialLightOn = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVentOn = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerrariumDataSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarbonDioxideLevelRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarbonDioxideLevelRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarbonDioxideLevelRecords_TerrariumDataSet_TerrariumDataId",
                        column: x => x.TerrariumDataId,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HumidityLevelRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumidityLevelRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HumidityLevelRecords_TerrariumDataSet_TerrariumDataId",
                        column: x => x.TerrariumDataId,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NaturalLightLevelRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalLightLevelRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalLightLevelRecords_TerrariumDataSet_TerrariumDataId",
                        column: x => x.TerrariumDataId,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperatureRecords_TerrariumDataSet_TerrariumDataId",
                        column: x => x.TerrariumDataId,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerrariumSet",
                columns: table => new
                {
                    TerrariumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerrariumName = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalName = table.Column<string>(type: "TEXT", nullable: true),
                    ActiveProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerrariumSet", x => x.TerrariumId);
                    table.ForeignKey(
                        name: "FK_TerrariumSet_TerrariumDataSet_TerrariumDataId",
                        column: x => x.TerrariumDataId,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileName = table.Column<string>(type: "TEXT", nullable: true),
                    MinTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    MinHumid = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxHumid = table.Column<int>(type: "INTEGER", nullable: false),
                    MinCo2 = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxCo2 = table.Column<int>(type: "INTEGER", nullable: false),
                    MinLight = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxLight = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrariumId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileSet_TerrariumSet_TerrariumId",
                        column: x => x.TerrariumId,
                        principalTable: "TerrariumSet",
                        principalColumn: "TerrariumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTasksSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ToggleLight = table.Column<bool>(type: "INTEGER", nullable: false),
                    ToggleVent = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeStamp = table.Column<string>(type: "TEXT", nullable: true),
                    TerrariumId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTasksSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledTasksSet_TerrariumSet_TerrariumId",
                        column: x => x.TerrariumId,
                        principalTable: "TerrariumSet",
                        principalColumn: "TerrariumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UId = table.Column<string>(type: "TEXT", nullable: true),
                    TerrariumId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSet_TerrariumSet_TerrariumId",
                        column: x => x.TerrariumId,
                        principalTable: "TerrariumSet",
                        principalColumn: "TerrariumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarbonDioxideLevelRecords_TerrariumDataId",
                table: "CarbonDioxideLevelRecords",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_HumidityLevelRecords_TerrariumDataId",
                table: "HumidityLevelRecords",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalLightLevelRecords_TerrariumDataId",
                table: "NaturalLightLevelRecords",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSet_TerrariumId",
                table: "ProfileSet",
                column: "TerrariumId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTasksSet_TerrariumId",
                table: "ScheduledTasksSet",
                column: "TerrariumId");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureRecords_TerrariumDataId",
                table: "TemperatureRecords",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TerrariumSet_TerrariumDataId",
                table: "TerrariumSet",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSet_TerrariumId",
                table: "UserSet",
                column: "TerrariumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarbonDioxideLevelRecords");

            migrationBuilder.DropTable(
                name: "HumidityLevelRecords");

            migrationBuilder.DropTable(
                name: "NaturalLightLevelRecords");

            migrationBuilder.DropTable(
                name: "ProfileSet");

            migrationBuilder.DropTable(
                name: "ScheduledTasksSet");

            migrationBuilder.DropTable(
                name: "TemperatureRecords");

            migrationBuilder.DropTable(
                name: "UserSet");

            migrationBuilder.DropTable(
                name: "TerrariumSet");

            migrationBuilder.DropTable(
                name: "TerrariumDataSet");
        }
    }
}
