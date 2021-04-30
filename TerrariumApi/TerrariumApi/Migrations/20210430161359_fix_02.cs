using Microsoft.EntityFrameworkCore.Migrations;

namespace TerrariumApi.Migrations
{
    public partial class fix_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarbonDioxideLevelRecord_TerrariumDataSet_TerrariumDataId",
                table: "CarbonDioxideLevelRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_HumidityLevelRecord_TerrariumDataSet_TerrariumDataId",
                table: "HumidityLevelRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_NaturalLightLevelRecord_TerrariumDataSet_TerrariumDataId",
                table: "NaturalLightLevelRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_TemperatureRecord_TerrariumDataSet_TerrariumDataId",
                table: "TemperatureRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemperatureRecord",
                table: "TemperatureRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NaturalLightLevelRecord",
                table: "NaturalLightLevelRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HumidityLevelRecord",
                table: "HumidityLevelRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarbonDioxideLevelRecord",
                table: "CarbonDioxideLevelRecord");

            migrationBuilder.RenameTable(
                name: "TemperatureRecord",
                newName: "TemperatureRecords");

            migrationBuilder.RenameTable(
                name: "NaturalLightLevelRecord",
                newName: "NaturalLightLevelRecords");

            migrationBuilder.RenameTable(
                name: "HumidityLevelRecord",
                newName: "HumidityLevelRecords");

            migrationBuilder.RenameTable(
                name: "CarbonDioxideLevelRecord",
                newName: "CarbonDioxideLevelRecords");

            migrationBuilder.RenameIndex(
                name: "IX_TemperatureRecord_TerrariumDataId",
                table: "TemperatureRecords",
                newName: "IX_TemperatureRecords_TerrariumDataId");

            migrationBuilder.RenameIndex(
                name: "IX_NaturalLightLevelRecord_TerrariumDataId",
                table: "NaturalLightLevelRecords",
                newName: "IX_NaturalLightLevelRecords_TerrariumDataId");

            migrationBuilder.RenameIndex(
                name: "IX_HumidityLevelRecord_TerrariumDataId",
                table: "HumidityLevelRecords",
                newName: "IX_HumidityLevelRecords_TerrariumDataId");

            migrationBuilder.RenameIndex(
                name: "IX_CarbonDioxideLevelRecord_TerrariumDataId",
                table: "CarbonDioxideLevelRecords",
                newName: "IX_CarbonDioxideLevelRecords_TerrariumDataId");

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "TemperatureRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "NaturalLightLevelRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "HumidityLevelRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "CarbonDioxideLevelRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemperatureRecords",
                table: "TemperatureRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NaturalLightLevelRecords",
                table: "NaturalLightLevelRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HumidityLevelRecords",
                table: "HumidityLevelRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarbonDioxideLevelRecords",
                table: "CarbonDioxideLevelRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarbonDioxideLevelRecords_TerrariumDataSet_TerrariumDataId",
                table: "CarbonDioxideLevelRecords",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HumidityLevelRecords_TerrariumDataSet_TerrariumDataId",
                table: "HumidityLevelRecords",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NaturalLightLevelRecords_TerrariumDataSet_TerrariumDataId",
                table: "NaturalLightLevelRecords",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemperatureRecords_TerrariumDataSet_TerrariumDataId",
                table: "TemperatureRecords",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarbonDioxideLevelRecords_TerrariumDataSet_TerrariumDataId",
                table: "CarbonDioxideLevelRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_HumidityLevelRecords_TerrariumDataSet_TerrariumDataId",
                table: "HumidityLevelRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_NaturalLightLevelRecords_TerrariumDataSet_TerrariumDataId",
                table: "NaturalLightLevelRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TemperatureRecords_TerrariumDataSet_TerrariumDataId",
                table: "TemperatureRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemperatureRecords",
                table: "TemperatureRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NaturalLightLevelRecords",
                table: "NaturalLightLevelRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HumidityLevelRecords",
                table: "HumidityLevelRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarbonDioxideLevelRecords",
                table: "CarbonDioxideLevelRecords");

            migrationBuilder.RenameTable(
                name: "TemperatureRecords",
                newName: "TemperatureRecord");

            migrationBuilder.RenameTable(
                name: "NaturalLightLevelRecords",
                newName: "NaturalLightLevelRecord");

            migrationBuilder.RenameTable(
                name: "HumidityLevelRecords",
                newName: "HumidityLevelRecord");

            migrationBuilder.RenameTable(
                name: "CarbonDioxideLevelRecords",
                newName: "CarbonDioxideLevelRecord");

            migrationBuilder.RenameIndex(
                name: "IX_TemperatureRecords_TerrariumDataId",
                table: "TemperatureRecord",
                newName: "IX_TemperatureRecord_TerrariumDataId");

            migrationBuilder.RenameIndex(
                name: "IX_NaturalLightLevelRecords_TerrariumDataId",
                table: "NaturalLightLevelRecord",
                newName: "IX_NaturalLightLevelRecord_TerrariumDataId");

            migrationBuilder.RenameIndex(
                name: "IX_HumidityLevelRecords_TerrariumDataId",
                table: "HumidityLevelRecord",
                newName: "IX_HumidityLevelRecord_TerrariumDataId");

            migrationBuilder.RenameIndex(
                name: "IX_CarbonDioxideLevelRecords_TerrariumDataId",
                table: "CarbonDioxideLevelRecord",
                newName: "IX_CarbonDioxideLevelRecord_TerrariumDataId");

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "TemperatureRecord",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "NaturalLightLevelRecord",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "HumidityLevelRecord",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TerrariumDataId",
                table: "CarbonDioxideLevelRecord",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemperatureRecord",
                table: "TemperatureRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NaturalLightLevelRecord",
                table: "NaturalLightLevelRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HumidityLevelRecord",
                table: "HumidityLevelRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarbonDioxideLevelRecord",
                table: "CarbonDioxideLevelRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarbonDioxideLevelRecord_TerrariumDataSet_TerrariumDataId",
                table: "CarbonDioxideLevelRecord",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HumidityLevelRecord_TerrariumDataSet_TerrariumDataId",
                table: "HumidityLevelRecord",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NaturalLightLevelRecord_TerrariumDataSet_TerrariumDataId",
                table: "NaturalLightLevelRecord",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemperatureRecord_TerrariumDataSet_TerrariumDataId",
                table: "TemperatureRecord",
                column: "TerrariumDataId",
                principalTable: "TerrariumDataSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
