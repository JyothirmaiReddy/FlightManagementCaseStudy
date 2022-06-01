using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementService.Migrations
{
    public partial class bookingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
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
                    table.PrimaryKey("PK_Airline", x => x.AirlineNo);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
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
                    table.PrimaryKey("PK_Inventory", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_Inventory_Airline_FK_AirlineNo",
                        column: x => x.FK_AirlineNo,
                        principalTable: "Airline",
                        principalColumn: "AirlineNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketDetailTbl",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNumber = table.Column<int>(nullable: false),
                    passengerName = table.Column<string>(nullable: true),
                    passengerAge = table.Column<int>(nullable: false),
                    passengerGender = table.Column<int>(nullable: false),
                    PNR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetailTbl", x => x.userid);
                    table.ForeignKey(
                        name: "FK_TicketDetailTbl_Inventory_FlightNumber",
                        column: x => x.FlightNumber,
                        principalTable: "Inventory",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_FK_AirlineNo",
                table: "Inventory",
                column: "FK_AirlineNo");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetailTbl_FlightNumber",
                table: "TicketDetailTbl",
                column: "FlightNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketDetailTbl");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Airline");
        }
    }
}
