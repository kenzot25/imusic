using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMusic.Migrations
{
    public partial class addnavigationsonguser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FK_sUserId",
                table: "tbl_Song",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Song_FK_sUserId",
                table: "tbl_Song",
                column: "FK_sUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Song_tbl_User_FK_sUserId",
                table: "tbl_Song",
                column: "FK_sUserId",
                principalTable: "tbl_User",
                principalColumn: "PK_sUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Song_tbl_User_FK_sUserId",
                table: "tbl_Song");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Song_FK_sUserId",
                table: "tbl_Song");

            migrationBuilder.AlterColumn<string>(
                name: "FK_sUserId",
                table: "tbl_Song",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
