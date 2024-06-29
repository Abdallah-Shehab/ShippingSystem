﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branch_BranchID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Government_GovernmentID",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccounts_Branch_BranchID",
                table: "DeliveryAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Government_Branch_BranchID",
                table: "Government");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccounts_Branch_BranchID",
                table: "MerchantAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_StaffMemberID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_City_CitytId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryAccounts_DeliveryID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Government_GovernmentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_MerchantAccounts_MerchantID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentType_PaymentTypeID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingType_ShippingTypeID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_AccessedEntity_entity_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_AspNetUsers_user_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_Permission_permission_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_order_Id",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingType",
                table: "ShippingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission_User_Entities",
                table: "Permission_User_Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Government",
                table: "Government");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessedEntity",
                table: "AccessedEntity");

            migrationBuilder.RenameTable(
                name: "ShippingType",
                newName: "ShippingTypes");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Permission_User_Entities",
                newName: "Permissions_User_Entities");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                newName: "PaymentTypes");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Government",
                newName: "Governments");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameTable(
                name: "AccessedEntity",
                newName: "Entities");

            migrationBuilder.RenameIndex(
                name: "IX_Product_order_Id",
                table: "Products",
                newName: "IX_Products_order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_User_Entities_permission_id",
                table: "Permissions_User_Entities",
                newName: "IX_Permissions_User_Entities_permission_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_User_Entities_entity_id",
                table: "Permissions_User_Entities",
                newName: "IX_Permissions_User_Entities_entity_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StaffMemberID",
                table: "Orders",
                newName: "IX_Orders_StaffMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ShippingTypeID",
                table: "Orders",
                newName: "IX_Orders_ShippingTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PaymentTypeID",
                table: "Orders",
                newName: "IX_Orders_PaymentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_MerchantID",
                table: "Orders",
                newName: "IX_Orders_MerchantID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_GovernmentId",
                table: "Orders",
                newName: "IX_Orders_GovernmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeliveryID",
                table: "Orders",
                newName: "IX_Orders_DeliveryID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CitytId",
                table: "Orders",
                newName: "IX_Orders_CitytId");

            migrationBuilder.RenameIndex(
                name: "IX_Government_BranchID",
                table: "Governments",
                newName: "IX_Governments_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_City_GovernmentID",
                table: "Cities",
                newName: "IX_Cities_GovernmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_GovernmentID",
                table: "Branches",
                newName: "IX_Branches_GovernmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingTypes",
                table: "ShippingTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions_User_Entities",
                table: "Permissions_User_Entities",
                columns: new[] { "user_id", "permission_id", "entity_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Governments",
                table: "Governments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_BranchID",
                table: "AspNetUsers",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Governments_GovernmentID",
                table: "Branches",
                column: "GovernmentID",
                principalTable: "Governments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Governments_GovernmentID",
                table: "Cities",
                column: "GovernmentID",
                principalTable: "Governments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccounts_Branches_BranchID",
                table: "DeliveryAccounts",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Governments_Branches_BranchID",
                table: "Governments",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccounts_Branches_BranchID",
                table: "MerchantAccounts",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_StaffMemberID",
                table: "Orders",
                column: "StaffMemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cities_CitytId",
                table: "Orders",
                column: "CitytId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryAccounts_DeliveryID",
                table: "Orders",
                column: "DeliveryID",
                principalTable: "DeliveryAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Governments_GovernmentId",
                table: "Orders",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MerchantAccounts_MerchantID",
                table: "Orders",
                column: "MerchantID",
                principalTable: "MerchantAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeID",
                table: "Orders",
                column: "PaymentTypeID",
                principalTable: "PaymentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingTypes_ShippingTypeID",
                table: "Orders",
                column: "ShippingTypeID",
                principalTable: "ShippingTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_User_Entities_AspNetUsers_user_id",
                table: "Permissions_User_Entities",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_User_Entities_Entities_entity_id",
                table: "Permissions_User_Entities",
                column: "entity_id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_User_Entities_Permissions_permission_id",
                table: "Permissions_User_Entities",
                column: "permission_id",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_order_Id",
                table: "Products",
                column: "order_Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_BranchID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Governments_GovernmentID",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Governments_GovernmentID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAccounts_Branches_BranchID",
                table: "DeliveryAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Governments_Branches_BranchID",
                table: "Governments");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantAccounts_Branches_BranchID",
                table: "MerchantAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_StaffMemberID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cities_CitytId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryAccounts_DeliveryID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Governments_GovernmentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MerchantAccounts_MerchantID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingTypes_ShippingTypeID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_User_Entities_AspNetUsers_user_id",
                table: "Permissions_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_User_Entities_Entities_entity_id",
                table: "Permissions_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_User_Entities_Permissions_permission_id",
                table: "Permissions_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_order_Id",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingTypes",
                table: "ShippingTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions_User_Entities",
                table: "Permissions_User_Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Governments",
                table: "Governments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "ShippingTypes",
                newName: "ShippingType");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Permissions_User_Entities",
                newName: "Permission_User_Entities");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "PaymentTypes",
                newName: "PaymentType");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Governments",
                newName: "Government");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "AccessedEntity");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameIndex(
                name: "IX_Products_order_Id",
                table: "Product",
                newName: "IX_Product_order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_User_Entities_permission_id",
                table: "Permission_User_Entities",
                newName: "IX_Permission_User_Entities_permission_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_User_Entities_entity_id",
                table: "Permission_User_Entities",
                newName: "IX_Permission_User_Entities_entity_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StaffMemberID",
                table: "Order",
                newName: "IX_Order_StaffMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShippingTypeID",
                table: "Order",
                newName: "IX_Order_ShippingTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentTypeID",
                table: "Order",
                newName: "IX_Order_PaymentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_MerchantID",
                table: "Order",
                newName: "IX_Order_MerchantID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_GovernmentId",
                table: "Order",
                newName: "IX_Order_GovernmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryID",
                table: "Order",
                newName: "IX_Order_DeliveryID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CitytId",
                table: "Order",
                newName: "IX_Order_CitytId");

            migrationBuilder.RenameIndex(
                name: "IX_Governments_BranchID",
                table: "Government",
                newName: "IX_Government_BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_GovernmentID",
                table: "City",
                newName: "IX_City_GovernmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_GovernmentID",
                table: "Branch",
                newName: "IX_Branch_GovernmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingType",
                table: "ShippingType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission_User_Entities",
                table: "Permission_User_Entities",
                columns: new[] { "user_id", "permission_id", "entity_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Government",
                table: "Government",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessedEntity",
                table: "AccessedEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branch_BranchID",
                table: "AspNetUsers",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch",
                column: "GovernmentID",
                principalTable: "Government",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Government_GovernmentID",
                table: "City",
                column: "GovernmentID",
                principalTable: "Government",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAccounts_Branch_BranchID",
                table: "DeliveryAccounts",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Government_Branch_BranchID",
                table: "Government",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantAccounts_Branch_BranchID",
                table: "MerchantAccounts",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_StaffMemberID",
                table: "Order",
                column: "StaffMemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_City_CitytId",
                table: "Order",
                column: "CitytId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryAccounts_DeliveryID",
                table: "Order",
                column: "DeliveryID",
                principalTable: "DeliveryAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Government_GovernmentId",
                table: "Order",
                column: "GovernmentId",
                principalTable: "Government",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_MerchantAccounts_MerchantID",
                table: "Order",
                column: "MerchantID",
                principalTable: "MerchantAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentType_PaymentTypeID",
                table: "Order",
                column: "PaymentTypeID",
                principalTable: "PaymentType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingType_ShippingTypeID",
                table: "Order",
                column: "ShippingTypeID",
                principalTable: "ShippingType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_Entities_AccessedEntity_entity_id",
                table: "Permission_User_Entities",
                column: "entity_id",
                principalTable: "AccessedEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_Entities_AspNetUsers_user_id",
                table: "Permission_User_Entities",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_Entities_Permission_permission_id",
                table: "Permission_User_Entities",
                column: "permission_id",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_order_Id",
                table: "Product",
                column: "order_Id",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
