using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Patrons2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatronId",
                table: "Copies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_PatronId",
                table: "Copies",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_AspNetUsers_PatronId",
                table: "Copies",
                column: "PatronId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_AspNetUsers_PatronId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_PatronId",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "Copies");
        }
    }
}
