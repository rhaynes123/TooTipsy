using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TooTipsy.Data.Migrations
{
    public partial class AddCalculations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    BillAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TipAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    FormulaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");
        }
    }
}
