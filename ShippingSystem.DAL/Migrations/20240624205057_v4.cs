using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DeliveryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MerchantId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_DeliveryID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_MerchantID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DeliveryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MerchantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Company_Percantage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discount_type",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Government",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pickup_Price",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Refund_Percentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "DeliveryAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Discount_type = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Company_Percantage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAccounts_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MerchantAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pickup_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Refund_Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantAccounts_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryAccounts_DeliveryID",
                table: "Order",
                column: "DeliveryID",
                principalTable: "DeliveryAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_MerchantAccounts_MerchantID",
                table: "Order",
                column: "MerchantID",
                principalTable: "MerchantAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryAccounts_DeliveryID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_MerchantAccounts_MerchantID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "DeliveryAccounts");

            migrationBuilder.DropTable(
                name: "MerchantAccounts");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Company_Percantage",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount_type",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Government",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pickup_Price",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Refund_Percentage",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeliveryId",
                table: "AspNetUsers",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MerchantId",
                table: "AspNetUsers",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DeliveryId",
                table: "AspNetUsers",
                column: "DeliveryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MerchantId",
                table: "AspNetUsers",
                column: "MerchantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_DeliveryID",
                table: "Order",
                column: "DeliveryID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_MerchantID",
                table: "Order",
                column: "MerchantID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
