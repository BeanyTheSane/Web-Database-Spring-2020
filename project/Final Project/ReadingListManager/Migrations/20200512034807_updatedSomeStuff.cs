using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingListManager.Migrations
{
    public partial class updatedSomeStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookEntry_Book_BookID",
                table: "UserBookEntry");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "UserBookEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookEntry_Book_BookID",
                table: "UserBookEntry",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookEntry_Book_BookID",
                table: "UserBookEntry");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "UserBookEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookEntry_Book_BookID",
                table: "UserBookEntry",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
