using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TerrariumApi.Migrations
{
    public partial class AddListsOfRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TerrariumDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    TerrariumDataId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    TerrariumDataId2 = table.Column<int>(type: "INTEGER", nullable: true),
                    TerrariumDataId3 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_TerrariumDataSet_TerrariumDataId",
                        column: x => x.TerrariumDataId,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_TerrariumDataSet_TerrariumDataId1",
                        column: x => x.TerrariumDataId1,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_TerrariumDataSet_TerrariumDataId2",
                        column: x => x.TerrariumDataId2,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_TerrariumDataSet_TerrariumDataId3",
                        column: x => x.TerrariumDataId3,
                        principalTable: "TerrariumDataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Record_TerrariumDataId",
                table: "Record",
                column: "TerrariumDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_TerrariumDataId1",
                table: "Record",
                column: "TerrariumDataId1");

            migrationBuilder.CreateIndex(
                name: "IX_Record_TerrariumDataId2",
                table: "Record",
                column: "TerrariumDataId2");

            migrationBuilder.CreateIndex(
                name: "IX_Record_TerrariumDataId3",
                table: "Record",
                column: "TerrariumDataId3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record");
        }
    }
}
