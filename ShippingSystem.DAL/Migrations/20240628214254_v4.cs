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
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Government_Branch_BranchID",
                table: "Government");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_AspNetUsers_user_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_Entity_entity_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_Permission_permission_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_order_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Government_BranchID",
                table: "Government");

            migrationBuilder.DropIndex(
                name: "IX_Branch_GovernmentID",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Government");

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentID",
                table: "Branch",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_GovernmentID",
                table: "Branch",
                column: "GovernmentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch",
                column: "GovernmentID",
                principalTable: "Government",
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
                name: "FK_Permission_User_Entities_Entity_entity_id",
                table: "Permission_User_Entities",
                column: "entity_id",
                principalTable: "Entity",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_AspNetUsers_user_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_Entity_entity_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_User_Entities_Permission_permission_id",
                table: "Permission_User_Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_order_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Branch_GovernmentID",
                table: "Branch");

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Government",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentID",
                table: "Branch",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Government_BranchID",
                table: "Government",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_GovernmentID",
                table: "Branch",
                column: "GovernmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch",
                column: "GovernmentID",
                principalTable: "Government",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Government_Branch_BranchID",
                table: "Government",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_Entities_AspNetUsers_user_id",
                table: "Permission_User_Entities",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_Entities_Entity_entity_id",
                table: "Permission_User_Entities",
                column: "entity_id",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_User_Entities_Permission_permission_id",
                table: "Permission_User_Entities",
                column: "permission_id",
                principalTable: "Permission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_order_Id",
                table: "Product",
                column: "order_Id",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
