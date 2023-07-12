using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workwear.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCarts",
                newName: "ProductSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_ProductSizes_ProductSizeId",
                table: "ShoppingCarts",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_ProductSizes_ProductSizeId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "ProductSizeId",
                table: "ShoppingCarts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ProductSizeId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
