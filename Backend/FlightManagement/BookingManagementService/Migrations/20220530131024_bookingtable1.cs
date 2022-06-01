using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementService.Migrations
{
    public partial class bookingtable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetailTbl_Inventory_FlightNumber",
                table: "TicketDetailTbl");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropIndex(
                name: "IX_TicketDetailTbl_FlightNumber",
                table: "TicketDetailTbl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    AirlineNo = table.Column<int>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    airlineLogo = table.Column<string>(nullable: true),
                    contactAddress = table.Column<string>(nullable: true),
                    contactNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.AirlineNo);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    FlightNumber = table.Column<int>(nullable: false),
                    BusinessSeats = table.Column<int>(nullable: false),
                    EndDatetime = table.Column<DateTime>(nullable: false),
                    FK_AirlineNo = table.Column<int>(nullable: false),
                    Fromplace = table.Column<string>(nullable: true),
                    NonBusinessSeats = table.Column<int>(nullable: false),
                    NumberOfRows = table.Column<int>(nullable: false),
                    Toplace = table.Column<string>(nullable: true),
                    instrumentUsed = table.Column<int>(nullable: false),
                    meal = table.Column<int>(nullable: false),
                    startDatetime = table.Column<DateTime>(nullable: false),
                    ticketCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_Inventory_Airline_FK_AirlineNo",
                        column: x => x.FK_AirlineNo,
                        principalTable: "Airline",
                        principalColumn: "AirlineNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetailTbl_FlightNumber",
                table: "TicketDetailTbl",
                column: "FlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_FK_AirlineNo",
                table: "Inventory",
                column: "FK_AirlineNo");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetailTbl_Inventory_FlightNumber",
                table: "TicketDetailTbl",
                column: "FlightNumber",
                principalTable: "Inventory",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
