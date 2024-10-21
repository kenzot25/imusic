using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMusic.Migrations
{
    public partial class updateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PK_sUserId",
                table: "tbl_User",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PK_sUserId",
                table: "tbl_User");
        }
    }
}
