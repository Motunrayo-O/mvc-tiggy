using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTiggy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventure",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PlannedDate = table.Column<DateTime>(nullable: false),
                    EstimatedCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventure", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventure");
        }
    }
}
