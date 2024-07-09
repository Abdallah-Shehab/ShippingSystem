using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialOffer_City",
                table: "MerchantAccounts");

            migrationBuilder.DropColumn(
                name: "SpecialOffer_DeliveryPrice",
                table: "MerchantAccounts");

            migrationBuilder.DropColumn(
                name: "SpecialOffer_Government",
                table: "MerchantAccounts");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialOffer_City",
                table: "MerchantAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SpecialOffer_DeliveryPrice",
                table: "MerchantAccounts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialOffer_Government",
                table: "MerchantAccounts",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
