using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsThatGoodDecision.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Users_UserId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WishListId",
                table: "Users",
                column: "WishListId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WishLists_WishListId",
                table: "Users",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WishLists_WishListId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WishListId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Users_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
