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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa370fd2-c1df-4410-ba9f-2e3bbaed7b2d", "AQAAAAIAAYagAAAAEDkYZHybKfphY8PEvZWACW2eBcfIVzekc30WCGNBBtTEVeLGbwgIQ8qIAC9jpb7STg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIrHA5WEpIcV1qs6XIuINp71u4bn7Ezmf6pLTzTgqWdMwCzytY0cPS00sQdpTXYOig==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO3gpOUpcSV05pZrfYlScTDqnvrbcHre2byw8ZlhOa7XbrgqHf1oK1rYR8NTco3Ltg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPjXpAvYkHC9SYMHGSuG9zr8D6m4foOKFAWRKPka0PN8x+dbt9zEUtXMSF5xANXPpg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFMVQgm+M5KKQyG3IDomaMsWGFrSbAIUujbvxnPRwdLQC+3EfoB5jN0IBXi+4XaGGA==");

            migrationBuilder.InsertData(
                table: "DeliveryAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "Company_Percantage", "ConcurrencyStamp", "Discount_type", "Email", "EmailConfirmed", "Governments", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "123 Main St", 1, 0m, "12345678-abcd-1234-efgh-1234567890ab", 0m, "hamdy.doe@example.com", true, null, false, true, null, "John Doe", "HAMDY.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEDMAeRmDWiSM/PesQpGarU3gws8+Xo89A+m+LWUAmr+2moInnEvvdHoXnMRccnNgqg==", "1234567890", true, 3, "HBLASJQKDKDKS", true, false, "johndoe" });

            migrationBuilder.InsertData(
                table: "MerchantAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Government", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Pickup_Price", "Refund_Percentage", "RoleID", "SecurityStamp", "Status", "StoreName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "123 Main St", 1, "City A", "12345678-abcd-1234-efgh-1234567890ab", "mariem.doe@example.com", true, "Government A", false, true, null, "John Doe", "MARIEM.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEHSc9W+M2g1UHg1sffmlfy1tFsyCvMishnNnBKli6pUD+MdS1NCoNVo9Nkachp7Uow==", "1234567890", "1234567890", true, 10.0m, 0.1m, 2, "HBLASJQKDKDKS", true, "Store A", false, "johndoe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2775d5e3-a1a8-4dff-a3d2-2d72fd1cd336", "AQAAAAIAAYagAAAAEPzCmjwnCV5MmYOEILpwCMj14f79gFBKJjHKg8OY+xutiDraNIx+HTiH81AqbHkjoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOLN0qtJi4n7QzXGHPD05WvNUhsTTIBA79umuJJyQcmmhm3wyiwMnmLbDnP9tATH1w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECjLNua9yiXvMVyXP+041aMJ58AcGfx4hpQsjQwE2hwqF2vaoE1zohGqxZ2MGkorWg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEKP7C44QfG6ELTPiwtZoQGQjSK/oGy3JqXN/UKhXIal4zoQauYx/xuLk28Qpn/xWg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELjgwpTdHhN2463IWk5UGv8BcJye+m344P+w2sCRkGRkRg7cjcP1xHcgOmK5jrsD7Q==");
        }
    }
}
