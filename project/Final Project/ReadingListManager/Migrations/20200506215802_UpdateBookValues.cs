using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingListManager.Migrations
{
    public partial class UpdateBookValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesInfoSeriesID",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreID",
                table: "Book",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SeriesInfoSeriesID",
                table: "Book",
                column: "SeriesInfoSeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Genre_GenreID",
                table: "Book",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Series_SeriesInfoSeriesID",
                table: "Book",
                column: "SeriesInfoSeriesID",
                principalTable: "Series",
                principalColumn: "SeriesID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Genre_GenreID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Series_SeriesInfoSeriesID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_GenreID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_SeriesInfoSeriesID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SeriesInfoSeriesID",
                table: "Book");
        }
    }
}
