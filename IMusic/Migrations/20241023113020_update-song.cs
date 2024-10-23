using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMusic.Migrations
{
    public partial class updatesong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "tbl_Song",
                newName: "sImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sImageUrl",
                table: "tbl_Song",
                newName: "ImageUrl");
        }
    }
}
