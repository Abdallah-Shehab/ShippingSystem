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
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 1));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 1));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 1));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 1));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75278094-2ddc-4a17-9587-dc00ff5a9e93", "AQAAAAIAAYagAAAAEL0zDNx+081plcvAMoIiogFGXukHYBSCsH6ZdfpmCk0MTOiBDhd7HFQ5OpX6LTPGFA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "john.doe@example.com", true, false, true, null, "John Doe", "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEG0e90GtAQCCaI+Fgy0y2EaDwBft3USf4SJqn2ALfpXCjx4hmOzBMJ1v1cPFAsDe5g==", "1234567890", true, 1, "HBLASJQKDKDKS", true, false, "johndoe" },
                    { 3, 0, "456 Oak St", 2, "87654321-dcba-4321-hgfe-0987654321ba", "jane.smith@example.com", true, false, true, null, "Jane Smith", "JANE.SMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEH6yD+ZBGyIHMTEhLgQJMa4pXb2Jq3fOxTlkOlJz61f88Atz9Z3UYRiYcQMewPzgvg==", "0987654321", true, 2, "HJSDKFHSDFHSD", true, false, "janesmith" }
                });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 1));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 7, 1));

            migrationBuilder.UpdateData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0854f1d-3065-4378-a617-aaaf26b43e86", "AQAAAAIAAYagAAAAEHlCUtHwgqUax/lUmeK/vQbKxjGg5B8gGGLk/kCi9gxGcAaOjZPW9adpscCIbMgLiQ==" });

            migrationBuilder.UpdateData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f373c585-013e-4f45-a972-4e436c25025c", "AQAAAAIAAYagAAAAEHZnWMiFkqU/bhmn85ZFCNAulo9ZDqq8pIMxyoDvA2wwgr1dj9dVH8FmG0FjHO4zRQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f572bf5-59dd-421e-90e7-c5236cc2cf70", "AQAAAAIAAYagAAAAEH279ufesicbTxks51nnz6DpQY3W3gDP5rlhvdbOvQT7kcu2FWnh8DHu0e3QdjahFQ==" });

            migrationBuilder.UpdateData(
                table: "MerchantAccounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5b8b13d-b84c-46ac-8c92-962cbf1443f0", "AQAAAAIAAYagAAAAEElHKlLs9fL/yDgjdxTecTYs8f3x/khgan8pvJ69ht2Wv1a6lONuUDUwEqdkYTsxCw==" });
        }
    }
}
