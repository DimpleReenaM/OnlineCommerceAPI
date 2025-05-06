using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopcartItems_Shopcarts_CartId",
                table: "ShopcartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopcartItems_CartId",
                table: "ShopcartItems");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ShopcartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopcartItems_ShoppingCartId",
                table: "ShopcartItems",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopcartItems_Shopcarts_ShoppingCartId",
                table: "ShopcartItems",
                column: "ShoppingCartId",
                principalTable: "Shopcarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopcartItems_Shopcarts_ShoppingCartId",
                table: "ShopcartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopcartItems_ShoppingCartId",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShopcartItems");

            migrationBuilder.CreateIndex(
                name: "IX_ShopcartItems_CartId",
                table: "ShopcartItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopcartItems_Shopcarts_CartId",
                table: "ShopcartItems",
                column: "CartId",
                principalTable: "Shopcarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
