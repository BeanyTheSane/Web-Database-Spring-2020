using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingListManager.Migrations
{
    public partial class UpdateBookValues2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Book_BookID",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Book_BookID",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_BookID",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Genre_BookID",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Genre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Genre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_BookID",
                table: "Series",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_BookID",
                table: "Genre",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Book_BookID",
                table: "Genre",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Book_BookID",
                table: "Series",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
