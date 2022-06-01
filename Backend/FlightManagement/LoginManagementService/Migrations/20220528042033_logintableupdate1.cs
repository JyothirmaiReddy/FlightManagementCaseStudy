using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginManagementService.Migrations
{
    public partial class logintableupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userlogin",
                table: "userlogin");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "userlogin");

            migrationBuilder.AlterColumn<string>(
                name: "EmailID",
                table: "userlogin",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_userlogin",
                table: "userlogin",
                column: "EmailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userlogin",
                table: "userlogin");

            migrationBuilder.AlterColumn<string>(
                name: "EmailID",
                table: "userlogin",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "userlogin",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userlogin",
                table: "userlogin",
                column: "UserID");
        }
    }
}
