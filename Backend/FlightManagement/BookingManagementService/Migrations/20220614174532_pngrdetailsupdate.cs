using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementService.Migrations
{
    public partial class pngrdetailsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ticketClass",
                table: "TicketDetailTbl",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketClass",
                table: "TicketDetailTbl");
        }
    }
}
