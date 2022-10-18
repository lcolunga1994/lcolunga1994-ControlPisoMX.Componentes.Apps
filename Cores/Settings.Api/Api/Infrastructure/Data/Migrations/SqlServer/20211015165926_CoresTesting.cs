namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Infrastructure.Data.Migrations.SqlServer
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CoresTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "corestesting");

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "corestesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Settings", x => x.Id));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings",
                schema: "corestesting");
        }
    }
}
