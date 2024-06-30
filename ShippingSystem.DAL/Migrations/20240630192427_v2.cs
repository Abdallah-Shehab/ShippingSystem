using System;
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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09956f46-9979-4f89-834d-f649c38f1feb", "AQAAAAIAAYagAAAAEALyEQktKh0wSPKo/Fici4pIS+W4pxO4ZoNsJbywq0gGyVpEmK4xM02Uht4+MBoRHQ==" });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "BranchID", "IsDeleted", "Name", "Status" },
                values: new object[] { 1, null, false, "Government1", true });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "CreatedDate", "GovernmentID", "IsDeleted", "Name", "Status" },
                values: new object[] { 1, new DateOnly(2024, 6, 30), 1, false, "Branch1", true });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "GovernmentID", "IsDeleted", "Name", "NormalShippingCost", "PickupShippingCost", "Status" },
                values: new object[] { 1, 1, false, "City1", 10.00m, 5.00m, true });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "BranchID", "IsDeleted", "Name", "Status" },
                values: new object[] { 2, 1, false, "Government3", true });

            migrationBuilder.InsertData(
                table: "MerchantAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Government", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pickup_Price", "Refund_Percentage", "RoleID", "SecurityStamp", "Status", "StoreName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "123 Main St", 1, "City1", "4cdaf41f-4788-4dfd-b1ec-5e0ee1e608d3", "merchant1@example.com", true, "Government1", false, true, null, "Merchant 1", "MERCHANT1@EXAMPLE.COM", "MERCHANT1@EXAMPLE.COM", "AQAAAAIAAYagAAAAENiMSKClp/RpuauxJgmcf/QZrObn4wQlt9WxHXsBWGTnYCoZGJ+ShFMMB8aENlOjrg==", "1234567890", true, 5.00m, 10.00m, 2, "", true, "Merchant Store 1", false, "merchant1@example.com" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "CreatedDate", "GovernmentID", "IsDeleted", "Name", "Status" },
                values: new object[] { 2, new DateOnly(2024, 6, 30), 2, false, "Branch2", true });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "GovernmentID", "IsDeleted", "Name", "NormalShippingCost", "PickupShippingCost", "Status" },
                values: new object[] { 2, 2, false, "City2", 15.00m, 7.00m, true });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "BranchID", "IsDeleted", "Name", "Status" },
                values: new object[] { 3, 2, false, "Government2", true });

            migrationBuilder.InsertData(
                table: "MerchantAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Government", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pickup_Price", "Refund_Percentage", "RoleID", "SecurityStamp", "Status", "StoreName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "456 Elm St", 2, "City2", "765703cd-0553-49da-b9be-6cd988d4181c", "merchant2@example.com", true, "Government2", false, true, null, "Merchant 2", "MERCHANT2@EXAMPLE.COM", "MERCHANT2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKjtOpHg2IS8VwiPOa+Mx6VXm9XtNZZG/helC3t1JToFBfeFFIoBoNnPah7/f4EWSw==", "1234567890", true, 7.00m, 15.00m, 2, "", true, "Merchant Store 2", false, "merchant2@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27dbba3c-00cb-445d-add1-e3ef363e049c", "AQAAAAIAAYagAAAAEOBOb8jgNB9IP0+e8HesBEHIUQyRXuOZ+YJa3b49axmqsGGMjzPNa/acYaqA1QnTig==" });
        }
    }
}
