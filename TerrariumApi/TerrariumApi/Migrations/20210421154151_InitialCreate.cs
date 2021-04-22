using Microsoft.EntityFrameworkCore.Migrations;

namespace TerrariumApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileDataSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaxAllowedTemperature = table.Column<double>(type: "REAL", nullable: false),
                    MinAllowedTemperature = table.Column<double>(type: "REAL", nullable: false),
                    MaxAllowedCarbonDioxideLevel = table.Column<double>(type: "REAL", nullable: false),
                    MinAllowedCarbonDioxideLevel = table.Column<double>(type: "REAL", nullable: false),
                    MaxHumidityLevel = table.Column<double>(type: "REAL", nullable: false),
                    MinHumidityLevel = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDataSet", x => x.Id);
                });

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
                    IsArtificialLightOn = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerrariumDataSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerrariumDataSnapshot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    CarbonDioxideLevel = table.Column<double>(type: "REAL", nullable: false),
                    HumidityLevel = table.Column<double>(type: "REAL", nullable: false),
                    NaturalLightLevel = table.Column<double>(type: "REAL", nullable: false),
                    IsArtificialLightOn = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerrariumDataSnapshot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileName = table.Column<string>(type: "TEXT", nullable: true),
                    ProfileDataDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ProfileDataId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileSet_ProfileDataSet_ProfileDataId",
                        column: x => x.ProfileDataId,
                        principalTable: "ProfileDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerrariumSet",
                columns: table => new
                {
                    TerrariumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerrariumName = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalName = table.Column<string>(type: "TEXT", nullable: true),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_TerrariumSet_UserSet_UserId",
                        column: x => x.UserId,
                        principalTable: "UserSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTasksSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Repeated = table.Column<bool>(type: "INTEGER", nullable: false),
                    TerrariumDataSnapshotId = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrariumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTasksSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledTasksSet_TerrariumDataSnapshot_TerrariumDataSnapshotId",
                        column: x => x.TerrariumDataSnapshotId,
                        principalTable: "TerrariumDataSnapshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledTasksSet_TerrariumSet_TerrariumId",
                        column: x => x.TerrariumId,
                        principalTable: "TerrariumSet",
                        principalColumn: "TerrariumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSet_ProfileDataId",
                table: "ProfileSet",
                column: "ProfileDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTasksSet_TerrariumDataSnapshotId",
                table: "ScheduledTasksSet",
                column: "TerrariumDataSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTasksSet_TerrariumId",
                table: "ScheduledTasksSet",
                column: "TerrariumId");

            migrationBuilder.CreateIndex(
                name: "IX_TerrariumSet_TerrariumDataId",
                table: "TerrariumSet",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TerrariumSet_UserId",
                table: "TerrariumSet",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileSet");

            migrationBuilder.DropTable(
                name: "ScheduledTasksSet");

            migrationBuilder.DropTable(
                name: "ProfileDataSet");

            migrationBuilder.DropTable(
                name: "TerrariumDataSnapshot");

            migrationBuilder.DropTable(
                name: "TerrariumSet");

            migrationBuilder.DropTable(
                name: "TerrariumDataSet");

            migrationBuilder.DropTable(
                name: "UserSet");
        }
    }
}
