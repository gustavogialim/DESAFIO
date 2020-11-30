using Microsoft.EntityFrameworkCore.Migrations;

namespace PhascoalottoDesafio.Infraestrutura.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    MaxInstallments = table.Column<int>(type: "int", nullable: false),
                    InterestType = table.Column<int>(type: "int", nullable: false),
                    InterestValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ComissionPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");
        }
    }
}
