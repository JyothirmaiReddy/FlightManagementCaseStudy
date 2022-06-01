using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementService.Migrations
{
    public partial class bookingtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TicketDetailTbl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TicketDetailTbl");
        }
    }
}
