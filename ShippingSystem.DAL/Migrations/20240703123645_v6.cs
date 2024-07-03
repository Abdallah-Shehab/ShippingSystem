using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTypeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 3));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 3));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 3));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 3));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e30824e6-639d-42ce-88dc-f065aeba75ec", "AQAAAAIAAYagAAAAEONHIFXR7b0XMJiHc6+LR/n/gTx0kpQvHWaWZJ7ttmjAWo4vgxIn9+pdnB9I8gHsYQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "john.doe@example.com", true, false, true, null, "John Doe", "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEKNwIueqiO6qYt3YXfM9Xp51ZvSb0/snHCL7zjl117xaAmlq5Ehzs/KC6NYIn62bFg==", "1234567890", true, 1, "HBLASJQKDKDKS", true, false, "johndoe" },
                    { 3, 0, "456 Oak St", 2, "87654321-dcba-4321-hgfe-0987654321ba", "jane.smith@example.com", true, false, true, null, "Jane Smith", "JANE.SMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEJ5pH1LWrZngMBtzB37xdsiUGjjbW/5ViY3uP+ox+/HwrMhxbtIdrO8Ri92OSvZPog==", "0987654321", true, 2, "HJSDKFHSDFHSD", true, false, "janesmith" }
                });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 3));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 3));

            migrationBuilder.InsertData(
                table: "DeliveryType",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "التسليم في الفرع", 5.99m },
                    { 2, false, "التسليم من التاجر", 12.99m }
                });

            migrationBuilder.UpdateData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BranchID", "Name", "Status" },
                values: new object[] { null, "Government2", false });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CitytId", "ClientName", "CreatedDate", "DeliveryID", "DeliveryPrice", "DeliveryTypeId", "DeliverydDate", "Email", "GovernmentId", "IsDeleted", "MerchantID", "Notes", "PaiedMoney", "PaymentTypeID", "PhoneOne", "PhoneTwo", "ReceivedMoney", "ShippingTypeID", "StaffMemberID", "Status", "StreetAndVillage", "TotalPrice", "TotalWeight" },
                values: new object[] { 1, null, "John Doe", new DateOnly(2024, 7, 3), null, 10.00m, null, null, "john.doe@example.com", null, false, null, "Handle with care", 40.00m, null, "1234567890", "0987654321", 50.00m, null, null, "Pending", "123 Main St", 100.00m, 5.00m });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryTypeId",
                table: "Orders",
                column: "DeliveryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryType_DeliveryTypeId",
                table: "Orders",
                column: "DeliveryTypeId",
                principalTable: "DeliveryType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryType_DeliveryTypeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryType");

            migrationBuilder.DropTable(
                name: "SpecialOffer");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryTypeId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DeliveryTypeId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 6, 30));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 6, 30));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2024, 6, 30));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2024, 6, 30));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3f52467-b2da-4962-ab35-ca11bbbfee61", "AQAAAAIAAYagAAAAEHuiaFw6bbdlceyuYHW8OMVx+1MLg63h1fjG33W2tKyR/xuZ21YDlZFYe8a4PSeeBg==" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 6, 30));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 6, 30));

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "GovernmentID", "IsDeleted", "Name", "NormalShippingCost", "PickupShippingCost", "Status" },
                values: new object[,]
                {
                    { 1, 1, false, "City1", 10.00m, 5.00m, true },
                    { 2, 2, false, "City2", 15.00m, 7.00m, true }
                });

            migrationBuilder.UpdateData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BranchID", "Name", "Status" },
                values: new object[] { 1, "Government3", true });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "BranchID", "IsDeleted", "Name", "Status" },
                values: new object[] { 3, 2, false, "Government2", true });

            migrationBuilder.InsertData(
                table: "MerchantAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Government", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pickup_Price", "Refund_Percentage", "RoleID", "SecurityStamp", "Status", "StoreName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "123 Main St", 1, "City1", "0f572bf5-59dd-421e-90e7-c5236cc2cf70", "merchant1@example.com", true, "Government1", false, true, null, "Merchant 1", "MERCHANT1@EXAMPLE.COM", "MERCHANT1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEH279ufesicbTxks51nnz6DpQY3W3gDP5rlhvdbOvQT7kcu2FWnh8DHu0e3QdjahFQ==", "1234567890", true, 5.00m, 10.00m, 2, "", true, "Merchant Store 1", false, "merchant1@example.com" },
                    { 2, 0, "456 Elm St", 2, "City2", "d5b8b13d-b84c-46ac-8c92-962cbf1443f0", "merchant2@example.com", true, "Government2", false, true, null, "Merchant 2", "MERCHANT2@EXAMPLE.COM", "MERCHANT2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEElHKlLs9fL/yDgjdxTecTYs8f3x/khgan8pvJ69ht2Wv1a6lONuUDUwEqdkYTsxCw==", "1234567890", true, 7.00m, 15.00m, 2, "", true, "Merchant Store 2", false, "merchant2@example.com" }
                });
        }
    }
}
