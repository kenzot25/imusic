using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMusic.Migrations
{
    public partial class UpdateSongModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenrePK_sGenreId",
                table: "tbl_Song",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Song_GenrePK_sGenreId",
                table: "tbl_Song",
                column: "GenrePK_sGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Song_tbl_Genre_GenrePK_sGenreId",
                table: "tbl_Song",
                column: "GenrePK_sGenreId",
                principalTable: "tbl_Genre",
                principalColumn: "PK_sGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Song_tbl_Genre_GenrePK_sGenreId",
                table: "tbl_Song");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Song_GenrePK_sGenreId",
                table: "tbl_Song");

            migrationBuilder.DropColumn(
                name: "GenrePK_sGenreId",
                table: "tbl_Song");
        }
    }
}
