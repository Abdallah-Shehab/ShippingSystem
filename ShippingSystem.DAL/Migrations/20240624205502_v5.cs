using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Account_id",
                table: "MerchantAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Account_id",
                table: "DeliveryAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantAccounts_Account_id",
                table: "MerchantAccounts",
                column: "Account_id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAccounts_Account_id",
                table: "DeliveryAccounts",
                column: "Account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccounts_AspNetUsers_Account_id",
                table: "DeliveryAccounts",
                column: "Account_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccounts_AspNetUsers_Account_id",
                table: "MerchantAccounts",
                column: "Account_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccounts_AspNetUsers_Account_id",
                table: "DeliveryAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccounts_AspNetUsers_Account_id",
                table: "MerchantAccounts");

            migrationBuilder.DropIndex(
                name: "IX_MerchantAccounts_Account_id",
                table: "MerchantAccounts");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryAccounts_Account_id",
                table: "DeliveryAccounts");

            migrationBuilder.DropColumn(
                name: "Account_id",
                table: "MerchantAccounts");

            migrationBuilder.DropColumn(
                name: "Account_id",
                table: "DeliveryAccounts");
        }
    }
}
