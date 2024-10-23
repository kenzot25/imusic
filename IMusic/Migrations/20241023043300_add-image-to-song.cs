using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMusic.Migrations
{
    public partial class addimagetosong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "tbl_Song",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sImageUrl",
                table: "tbl_Song");
        }
    }
}
