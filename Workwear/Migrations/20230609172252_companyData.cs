using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workwear.Migrations
{
    /// <inheritdoc />
    public partial class companyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "ActualAddress", "City", "FullName", "INN", "KPP", "LegalAddress", "OGRN", "PhoneNumber", "PostalCode", "ShortName" },
                values: new object[] { 4, " ghfghgf", "Набережные Челны", "ООО Компания", 323123, 666666, "авыпывп", 4325432, "898888", "dsadas", "Компания" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
