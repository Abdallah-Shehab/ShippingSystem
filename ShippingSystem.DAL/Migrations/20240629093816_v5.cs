using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccounts_AspNetRoles_RoleID",
                table: "DeliveryAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccounts_Branch_BranchID",
                table: "DeliveryAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccounts_AspNetRoles_RoleID",
                table: "MerchantAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccounts_Branch_BranchID",
                table: "MerchantAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryAccounts_DeliveryID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_MerchantAccounts_MerchantID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Permission_User_Entities");

            migrationBuilder.DropTable(
                name: "AccessedEntity");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MerchantAccounts",
                table: "MerchantAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryAccounts",
                table: "DeliveryAccounts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "MerchantAccounts",
                newName: "MerchantAccount");

            migrationBuilder.RenameTable(
                name: "DeliveryAccounts",
                newName: "DeliveryAccount");

            migrationBuilder.RenameIndex(
                name: "IX_MerchantAccounts_RoleID",
                table: "MerchantAccount",
                newName: "IX_MerchantAccount_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_MerchantAccounts_BranchID",
                table: "MerchantAccount",
                newName: "IX_MerchantAccount_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryAccounts_RoleID",
                table: "DeliveryAccount",
                newName: "IX_DeliveryAccount_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryAccounts_BranchID",
                table: "DeliveryAccount",
                newName: "IX_DeliveryAccount_BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MerchantAccount",
                table: "MerchantAccount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryAccount",
                table: "DeliveryAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccount_AspNetRoles_RoleID",
                table: "DeliveryAccount",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccount_Branch_BranchID",
                table: "DeliveryAccount",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccount_AspNetRoles_RoleID",
                table: "MerchantAccount",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccount_Branch_BranchID",
                table: "MerchantAccount",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryAccount_DeliveryID",
                table: "Order",
                column: "DeliveryID",
                principalTable: "DeliveryAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_MerchantAccount_MerchantID",
                table: "Order",
                column: "MerchantID",
                principalTable: "MerchantAccount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccount_AspNetRoles_RoleID",
                table: "DeliveryAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccount_Branch_BranchID",
                table: "DeliveryAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccount_AspNetRoles_RoleID",
                table: "MerchantAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccount_Branch_BranchID",
                table: "MerchantAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryAccount_DeliveryID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_MerchantAccount_MerchantID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MerchantAccount",
                table: "MerchantAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryAccount",
                table: "DeliveryAccount");

            migrationBuilder.RenameTable(
                name: "MerchantAccount",
                newName: "MerchantAccounts");

            migrationBuilder.RenameTable(
                name: "DeliveryAccount",
                newName: "DeliveryAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_MerchantAccount_RoleID",
                table: "MerchantAccounts",
                newName: "IX_MerchantAccounts_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_MerchantAccount_BranchID",
                table: "MerchantAccounts",
                newName: "IX_MerchantAccounts_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryAccount_RoleID",
                table: "DeliveryAccounts",
                newName: "IX_DeliveryAccounts_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryAccount_BranchID",
                table: "DeliveryAccounts",
                newName: "IX_DeliveryAccounts_BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MerchantAccounts",
                table: "MerchantAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryAccounts",
                table: "DeliveryAccounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccessedEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessedEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission_User_Entities",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false),
                    entity_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_User_Entities", x => new { x.user_id, x.permission_id, x.entity_id });
                    table.ForeignKey(
                        name: "FK_Permission_User_Entities_AccessedEntity_entity_id",
                        column: x => x.entity_id,
                        principalTable: "AccessedEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_User_Entities_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_User_Entities_Permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessedEntity",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Settings" },
                    { 2, false, "Branches" },
                    { 3, false, "Employees" },
                    { 4, false, "Merchants" },
                    { 5, false, "Deliveries" },
                    { 6, false, "Governorates" },
                    { 7, false, "Cities" },
                    { 8, false, "Orders" },
                    { 9, false, "Financials" },
                    { 10, false, "Reports" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, false, "Merchant", null },
                    { 2, null, false, "Employee", null },
                    { 3, null, false, "Delivery", null },
                    { 4, null, false, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Cash" },
                    { 2, false, "Visa" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Create" },
                    { 2, false, "Update" },
                    { 3, false, "Delete" },
                    { 4, false, "Read" }
                });

            migrationBuilder.InsertData(
                table: "ShippingType",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Normal", 30m },
                    { 2, false, "7 Days", 50m },
                    { 3, false, "24 Hour", 70m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_User_Entities_entity_id",
                table: "Permission_User_Entities",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_User_Entities_permission_id",
                table: "Permission_User_Entities",
                column: "permission_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccounts_AspNetRoles_RoleID",
                table: "DeliveryAccounts",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccounts_Branch_BranchID",
                table: "DeliveryAccounts",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccounts_AspNetRoles_RoleID",
                table: "MerchantAccounts",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccounts_Branch_BranchID",
                table: "MerchantAccounts",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

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
    }
}
