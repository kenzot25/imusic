using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMusic.Migrations
{
    public partial class modifyfksongmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FK_sPlaylistId",
                table: "tbl_Song",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sImageUrl",
                table: "tbl_Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Song_FK_sPlaylistId",
                table: "tbl_Song",
                column: "FK_sPlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Song_tbl_Playlist_FK_sPlaylistId",
                table: "tbl_Song",
                column: "FK_sPlaylistId",
                principalTable: "tbl_Playlist",
                principalColumn: "PK_sPlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Song_tbl_Playlist_FK_sPlaylistId",
                table: "tbl_Song");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Song_FK_sPlaylistId",
                table: "tbl_Song");

            migrationBuilder.DropColumn(
                name: "sImageUrl",
                table: "tbl_Playlist");

            migrationBuilder.AlterColumn<string>(
                name: "FK_sPlaylistId",
                table: "tbl_Song",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
