using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityLabs.Migrations
{
    public partial class NewStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesRepID",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SalesRep",
                columns: table => new
                {
                    SalesRepID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRep", x => x.SalesRepID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SalesRepID",
                table: "Customer",
                column: "SalesRepID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_SalesRep_SalesRepID",
                table: "Customer",
                column: "SalesRepID",
                principalTable: "SalesRep",
                principalColumn: "SalesRepID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_SalesRep_SalesRepID",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "SalesRep");

            migrationBuilder.DropIndex(
                name: "IX_Customer_SalesRepID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SalesRepID",
                table: "Customer");
        }
    }
}
