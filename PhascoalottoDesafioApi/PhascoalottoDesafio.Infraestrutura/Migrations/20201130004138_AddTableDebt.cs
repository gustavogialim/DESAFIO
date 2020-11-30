using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhascoalottoDesafio.Infraestrutura.Migrations
{
    public partial class AddTableDebt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    InstallmentsCount = table.Column<int>(nullable: false),
                    LateDays = table.Column<int>(nullable: false),
                    OriginalValue = table.Column<decimal>(nullable: false),
                    InterestValue = table.Column<decimal>(nullable: false),
                    FinalValue = table.Column<decimal>(nullable: false),
                    OrientationPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtInstallment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    FinalValue = table.Column<decimal>(nullable: false),
                    DebtId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtInstallment_Debt_DebtId",
                        column: x => x.DebtId,
                        principalTable: "Debt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtInstallment_DebtId",
                table: "DebtInstallment",
                column: "DebtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtInstallment");

            migrationBuilder.DropTable(
                name: "Debt");
        }
    }
}
