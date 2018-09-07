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
                    Duration = table.Column<int>(nullable: false),
                    DurationUnits = table.Column<int>(nullable: false),
                    EstimatedCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventure", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AdventureMember",
                columns: table => new
                {
                    AdventureId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureMember", x => new { x.AdventureId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_AdventureMember_Adventure_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventure",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdventureMember_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventureMember_MemberId",
                table: "AdventureMember",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventureMember");

            migrationBuilder.DropTable(
                name: "Adventure");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
