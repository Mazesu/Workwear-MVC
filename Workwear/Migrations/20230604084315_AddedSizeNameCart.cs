using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workwear.Migrations
{
    /// <inheritdoc />
    public partial class AddedSizeNameCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "ShoppingCarts");
        }
    }
}
