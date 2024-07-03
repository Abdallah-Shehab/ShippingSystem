using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11cb9f98-3d7a-492e-829d-6a084c94373c", "AQAAAAIAAYagAAAAEEgPLaP2lOEElbn6L6ML8v1VxI0ZtRoekNVksfCIna/UYVKuPCKMYnK3iwQozzrecQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELlw0S9SZy2+WFm4r37FStaHACrHpggfRxr2ywHE4yfyjM89m67oMtx+amK4/v5a6A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM6U0V5JiQZ7Hn4MJnx+3M4fh+KBrvXa2gELdObsoz3wyMZQ/Zzh3ZGnfmhJbEYDyA==");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 4, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "ahmed.salah@example.com", true, false, true, null, "Ahmed Salah", "AHMED.SALAH@EXAMPLE.COM", "AHMED", "AQAAAAIAAYagAAAAEKRibQJBNXi0zddWPvjLCxUAkLIgq+/t009NnxTS1szstqb7z/Nizo6rPjhuycr9DA==", "1234567890", true, 3, "HBLASJQKDKDKS", true, false, "ahmed" },
                    { 5, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "mona.magdy@example.com", true, false, true, null, "Mona Magdy", "MONA.MAGDY@EXAMPLE.COM", "MONA", "AQAAAAIAAYagAAAAEPVmGuZNIztz9MdHJHQKtsCOsJERuegFI3v5qKVvfzIAKisWIcjZ2HmM6VQrqzUKqg==", "1234567890", true, 4, "HBLASJQKDKDKS", true, false, "mona" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e30824e6-639d-42ce-88dc-f065aeba75ec", "AQAAAAIAAYagAAAAEONHIFXR7b0XMJiHc6+LR/n/gTx0kpQvHWaWZJ7ttmjAWo4vgxIn9+pdnB9I8gHsYQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKNwIueqiO6qYt3YXfM9Xp51ZvSb0/snHCL7zjl117xaAmlq5Ehzs/KC6NYIn62bFg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJ5pH1LWrZngMBtzB37xdsiUGjjbW/5ViY3uP+ox+/HwrMhxbtIdrO8Ri92OSvZPog==");
        }
    }
}
