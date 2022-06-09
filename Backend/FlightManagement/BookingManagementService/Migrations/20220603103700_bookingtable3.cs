using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementService.Migrations
{
    public partial class bookingtable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "endingTime",
                table: "TicketDetailTbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startingTime",
                table: "TicketDetailTbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endingTime",
                table: "TicketDetailTbl");

            migrationBuilder.DropColumn(
                name: "startingTime",
                table: "TicketDetailTbl");
        }
    }
}
