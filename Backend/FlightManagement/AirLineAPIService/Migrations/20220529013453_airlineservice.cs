using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirLineAPIService.Migrations
{
    public partial class airlineservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineNo = table.Column<int>(nullable: false),
                    airlineLogo = table.Column<string>(nullable: true),
                    contactNumber = table.Column<int>(nullable: false),
                    contactAddress = table.Column<string>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.AirlineNo);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    FlightNumber = table.Column<int>(nullable: false),
                    FK_AirlineNo = table.Column<int>(nullable: false),
                    Fromplace = table.Column<string>(nullable: true),
                    Toplace = table.Column<string>(nullable: true),
                    startDatetime = table.Column<DateTime>(nullable: false),
                    EndDatetime = table.Column<DateTime>(nullable: false),
                    BusinessSeats = table.Column<int>(nullable: false),
                    NonBusinessSeats = table.Column<int>(nullable: false),
                    ticketCost = table.Column<int>(nullable: false),
                    NumberOfRows = table.Column<int>(nullable: false),
                    meal = table.Column<int>(nullable: false),
                    instrumentUsed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_Inventories_Airlines_FK_AirlineNo",
                        column: x => x.FK_AirlineNo,
                        principalTable: "Airlines",
                        principalColumn: "AirlineNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_FK_AirlineNo",
                table: "Inventories",
                column: "FK_AirlineNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Airlines");
        }
    }
}
