using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Authorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatronId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PatronId",
                table: "Books",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_PatronId",
                table: "Books",
                column: "PatronId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_PatronId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PatronId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "Books");
        }
    }
}
