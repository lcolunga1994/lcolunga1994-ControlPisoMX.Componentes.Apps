using Microsoft.EntityFrameworkCore.Migrations;

namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Infrastructure.Data.Migrations.SqlServer
{
    public partial class RemoveId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                schema: "corestesting",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "corestesting",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "corestesting",
                table: "Settings",
                type: "varchar(900)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                schema: "corestesting",
                table: "Settings",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                schema: "corestesting",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "corestesting",
                table: "Settings",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(900)",
                oldUnicode: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "corestesting",
                table: "Settings",
                type: "int",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                schema: "corestesting",
                table: "Settings",
                column: "Id");
        }
    }
}
