using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKI+YmepVa2x28hDfpaqwQCVUFkcksPx8l3nzq33FF04FH7cmdDHTtsEQRJO8Mq2XA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "JOHN.DOE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEO8RqOTXYrkGqQI5/QFz3J1doHCReVl/vbj5HSNBRQJI7v0+sJuFybnXBciPNqLDMQ==" });
        }
    }
}
