﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingTypes",
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
                    table.PrimaryKey("PK_ShippingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GovernmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    Governments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount_type = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Company_Percantage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAccounts_AspNetRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryAccounts_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Governments_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MerchantAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pickup_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Refund_Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantAccounts_AspNetRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MerchantAccounts_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    NormalShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickupShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GovernmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governments_GovernmentID",
                        column: x => x.GovernmentID,
                        principalTable: "Governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_SpecialOffer_MerchantAccounts_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "MerchantAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaiedMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeliverydDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StreetAndVillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffMemberID = table.Column<int>(type: "int", nullable: true),
                    MerchantID = table.Column<int>(type: "int", nullable: false),
                    DeliveryID = table.Column<int>(type: "int", nullable: true),
                    ShippingTypeID = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeID = table.Column<int>(type: "int", nullable: true),
                    DeliveryTypeID = table.Column<int>(type: "int", nullable: false),
                    GovernmentId = table.Column<int>(type: "int", nullable: true),
                    CitytId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_StaffMemberID",
                        column: x => x.StaffMemberID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CitytId",
                        column: x => x.CitytId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryAccounts_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "DeliveryAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryType_DeliveryTypeID",
                        column: x => x.DeliveryTypeID,
                        principalTable: "DeliveryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Governments_GovernmentId",
                        column: x => x.GovernmentId,
                        principalTable: "Governments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_MerchantAccounts_MerchantID",
                        column: x => x.MerchantID,
                        principalTable: "MerchantAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentTypes_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShippingTypes_ShippingTypeID",
                        column: x => x.ShippingTypeID,
                        principalTable: "ShippingTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    order_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, new DateOnly(2024, 7, 4), false, "Employee", null },
                    { 2, null, new DateOnly(2024, 7, 4), false, "Merchant", null },
                    { 3, null, new DateOnly(2024, 7, 4), false, "Delivery", null },
                    { 4, null, new DateOnly(2024, 7, 4), false, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "DeliveryType",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "التسليم في الفرع", 5.99m },
                    { 2, false, "التسليم من التاجر", 12.99m }
                });

            migrationBuilder.InsertData(
                table: "Entities",
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
                table: "Governments",
                columns: new[] { "Id", "BranchID", "IsDeleted", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, false, "Government1", false },
                    { 2, null, false, "Government2", false }
                });

            migrationBuilder.InsertData(
<<<<<<<< HEAD:ShippingSystem.DAL/Migrations/20240704220551_v1.cs
                table: "Orders",
                columns: new[] { "Id", "CitytId", "ClientName", "CreatedDate", "DeliveryID", "DeliveryPrice", "DeliveryTypeId", "DeliverydDate", "Email", "GovernmentId", "IsDeleted", "MerchantID", "Notes", "PaiedMoney", "PaymentTypeID", "PhoneOne", "PhoneTwo", "ReceivedMoney", "ShippingTypeID", "StaffMemberID", "Status", "StreetAndVillage", "TotalPrice", "TotalWeight" },
                values: new object[] { 1, null, "John Doe", new DateOnly(2024, 7, 4), null, 10.00m, null, null, "john.doe@example.com", null, false, null, "Handle with care", 40.00m, null, "1234567890", "0987654321", 50.00m, null, null, "Pending", "123 Main St", 100.00m, 5.00m });

            migrationBuilder.InsertData(
========
>>>>>>>> Mariem:ShippingSystem.DAL/Migrations/20240704135710_v1.cs
                table: "PaymentTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Cash" },
                    { 2, false, "Visa" }
                });

            migrationBuilder.InsertData(
                table: "ShippingTypes",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Normal", 30m },
                    { 2, false, "7 Days", 50m },
                    { 3, false, "24 Hour", 70m }
                });

            migrationBuilder.InsertData(
<<<<<<<< HEAD:ShippingSystem.DAL/Migrations/20240704220551_v1.cs
========
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "123 New Street", null, "2b85fbc7-255c-4da6-9792-ade89d174171", "newuser@example.com", false, false, false, null, "New User", null, null, "AQAAAAIAAYagAAAAEL74fjs16Wyi95vy8JjCUsN2jGfw8N7JCeSHo/ABITWucF+l8kI+haKYoO8/Scw+1w==", null, false, 1, null, true, false, "newuser" });

            migrationBuilder.InsertData(
>>>>>>>> Mariem:ShippingSystem.DAL/Migrations/20240704135710_v1.cs
                table: "Branches",
                columns: new[] { "Id", "CreatedDate", "GovernmentID", "IsDeleted", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 7, 4), 1, false, "Branch1", true },
                    { 2, new DateOnly(2024, 7, 4), 2, false, "Branch2", true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanWrite", "EntityId", "IsDeleted", "RoleId" },
                values: new object[,]
                {
                    { 1, false, false, false, false, 1, false, 1 },
                    { 2, false, false, false, false, 2, false, 1 },
                    { 3, false, false, false, false, 3, false, 1 },
                    { 4, false, false, false, false, 4, false, 1 },
                    { 5, false, false, false, false, 5, false, 1 },
                    { 6, false, false, false, false, 6, false, 1 },
                    { 7, false, false, false, false, 7, false, 1 },
                    { 8, false, false, false, false, 8, false, 1 },
                    { 9, false, false, false, false, 9, false, 1 },
                    { 10, false, false, false, false, 10, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
<<<<<<<< HEAD:ShippingSystem.DAL/Migrations/20240704220551_v1.cs
                    { 2, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "john.doe@example.com", true, false, true, null, "John Doe", "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEHR+i6B2o5nr+P2ozXdndFbYB9uEoer0e9AOslIz3/iJqjtoEie4QLXOC2ePqvG8+A==", "1234567890", true, 1, "HBLASJQKDKDKS", true, false, "johndoe" },
                    { 3, 0, "456 Oak St", 2, "87654321-dcba-4321-hgfe-0987654321ba", "jane.smith@example.com", true, false, true, null, "Jane Smith", "JANE.SMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAELfpYZ4FlVFTJRFnITtF+VfBgdx3FtRap/QLYO/9uO/cPTt77aX9iQ9zgijUXRSyWA==", "0987654321", true, 2, "HJSDKFHSDFHSD", true, false, "janesmith" },
                    { 4, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "ahmed.salah@example.com", true, false, true, null, "Ahmed Salah", "AHMED.SALAH@EXAMPLE.COM", "AHMED", "AQAAAAIAAYagAAAAEEk+xGZ4fH27kctrCRPkm2/3v0y8cCQ65ZX5sGktMDKOF/KCMNuO8tKFLk05X1PDKA==", "1234567890", true, 3, "HBLASJQKDKDKS", true, false, "ahmed" },
                    { 5, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "mona.magdy@example.com", true, false, true, null, "Mona Magdy", "MONA.MAGDY@EXAMPLE.COM", "MONA", "AQAAAAIAAYagAAAAEFFtyUx1s+D9ulB3BC9DDr6G6taEZ2anSXkopm76QskIhhl6TFQRVIfkY48rnvYTqw==", "1234567890", true, 4, "HBLASJQKDKDKS", true, false, "mona" }
========
                    { 2, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "john.doe@example.com", true, false, true, null, "John Doe", "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEMkWvyk8gco7emav7fukH4UV3CMAC5Kjzs8+Gsu6hrts6UtbHIF9t4U1glN1iCvhcg==", "1234567890", true, 1, "HBLASJQKDKDKS", true, false, "johndoe" },
                    { 3, 0, "456 Oak St", 2, "87654321-dcba-4321-hgfe-0987654321ba", "jane.smith@example.com", true, false, true, null, "Jane Smith", "JANE.SMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEI6/K6Ls1dyUJHl/rlB3YMnYxmKeQpquVY7ko092lGrEqfCtLNDg5+20kLm/khOcgw==", "0987654321", true, 2, "HJSDKFHSDFHSD", true, false, "janesmith" },
                    { 4, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "ahmed.salah@example.com", true, false, true, null, "Ahmed Salah", "AHMED.SALAH@EXAMPLE.COM", "AHMED", "AQAAAAIAAYagAAAAENfUErMfsV7UUlHEaAgZetTOhJqeDwghEDWSTj7yHbEAEHRN5vfHff1O1U/CgHzLKA==", "1234567890", true, 3, "HBLASJQKDKDKS", true, false, "ahmed" },
                    { 5, 0, "123 Main St", 1, "12345678-abcd-1234-efgh-1234567890ab", "mona.magdy@example.com", true, false, true, null, "Mona Magdy", "MONA.MAGDY@EXAMPLE.COM", "MONA", "AQAAAAIAAYagAAAAEDLOhGKMi+OcbqTf8qexuug94iOSVOtzAEuR2lp2ny1XIagIsXlcr7REvuXVL6Ew2Q==", "1234567890", true, 4, "HBLASJQKDKDKS", true, false, "mona" }
>>>>>>>> Mariem:ShippingSystem.DAL/Migrations/20240704135710_v1.cs
                });

            migrationBuilder.InsertData(
                table: "DeliveryAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "Company_Percantage", "ConcurrencyStamp", "Discount_type", "Email", "EmailConfirmed", "Governments", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleID", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
<<<<<<<< HEAD:ShippingSystem.DAL/Migrations/20240704220551_v1.cs
                values: new object[] { 1, 0, "123 Main St", 1, 0m, "12345678-abcd-1234-efgh-1234567890ab", 0m, "hamdy.doe@example.com", true, null, false, true, null, "John Doe", "HAMDY.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEL/6kxMLyDdV/8H5Y840Urdy8z+r33/PesMMRmyvJi7XQ+K778EvHH77zbzLmtgTXQ==", "1234567890", true, 3, "HBLASJQKDKDKS", true, false, "johndoe" });

            migrationBuilder.InsertData(
                table: "MerchantAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Government", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pickup_Price", "Refund_Percentage", "RoleID", "SecurityStamp", "Status", "StoreName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "123 Main St", 1, "City A", "12345678-abcd-1234-efgh-1234567890ab", "mariem.doe@example.com", true, "Government A", false, true, null, "John Doe", "MARIEM.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAELuuZQ68MfwdWx7NYIw26ZXZmw+Uc8PUo3sV6SXAptdTRRw0THT3RkrbHbCkn4gQeA==", "1234567890", true, 10.0m, 0.1m, 2, "HBLASJQKDKDKS", true, "Store A", false, "johndoe" });
========
                values: new object[] { 1, 0, "123 Main St", 1, 0m, "12345678-abcd-1234-efgh-1234567890ab", 0m, "hamdy.doe@example.com", true, null, false, true, null, "John Doe", "HAMDY.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEPU3CJYcaHq+94/e2msAti3UHgsvKo6oOen6/FYIAoLj5fnTQDwligsZyjKwCMHOGg==", "1234567890", true, 3, "HBLASJQKDKDKS", true, false, "johndoe" });

            migrationBuilder.InsertData(
                table: "MerchantAccounts",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BranchID", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Government", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Pickup_Price", "Refund_Percentage", "RoleID", "SecurityStamp", "Status", "StoreName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "123 Main St", 1, "City A", "12345678-abcd-1234-efgh-1234567890ab", "mariem.doe@example.com", true, "Government A", false, true, null, "John Doe", "MARIEM.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEO2iy1xMS07sB47lP+czv95WQ9MVuZNojK5spOUD2yJ0c9DZ3om/gEwDZNTNShvYIQ==", "1234567890", "1234567890", true, 10.0m, 0.1m, 2, "HBLASJQKDKDKS", true, "Store A", false, "johndoe" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CitytId", "ClientName", "CreatedDate", "DeliveryID", "DeliveryPrice", "DeliveryTypeID", "DeliverydDate", "Email", "GovernmentId", "IsDeleted", "MerchantID", "Notes", "PaiedMoney", "PaymentTypeID", "PhoneOne", "PhoneTwo", "ReceivedMoney", "ShippingTypeID", "StaffMemberID", "Status", "StreetAndVillage", "TotalPrice", "TotalWeight" },
                values: new object[] { 1, null, "John Doe", new DateOnly(2024, 7, 4), null, 10.00m, 1, null, "john.doe@example.com", null, false, 1, "Handle with care", 40.00m, null, "1234567890", "0987654321", 50.00m, null, null, "Pending", "123 Main St", 100.00m, 5.00m });
>>>>>>>> Mariem:ShippingSystem.DAL/Migrations/20240704135710_v1.cs

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BranchID",
                table: "AspNetUsers",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleID",
                table: "AspNetUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_GovernmentID",
                table: "Branches",
                column: "GovernmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernmentID",
                table: "Cities",
                column: "GovernmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAccounts_BranchID",
                table: "DeliveryAccounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAccounts_RoleID",
                table: "DeliveryAccounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Governments_BranchID",
                table: "Governments",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantAccounts_BranchID",
                table: "MerchantAccounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantAccounts_RoleID",
                table: "MerchantAccounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CitytId",
                table: "Orders",
                column: "CitytId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryID",
                table: "Orders",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryTypeID",
                table: "Orders",
                column: "DeliveryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GovernmentId",
                table: "Orders",
                column: "GovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MerchantID",
                table: "Orders",
                column: "MerchantID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentTypeID",
                table: "Orders",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingTypeID",
                table: "Orders",
                column: "ShippingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffMemberID",
                table: "Orders",
                column: "StaffMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EntityId",
                table: "Permissions",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_order_Id",
                table: "Products",
                column: "order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffer_MerchantId",
                table: "SpecialOffer",
                column: "MerchantId");

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
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Governments_Branches_BranchID",
                table: "Governments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpecialOffer");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "DeliveryAccounts");

            migrationBuilder.DropTable(
                name: "DeliveryType");

            migrationBuilder.DropTable(
                name: "MerchantAccounts");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "ShippingTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Governments");
        }
    }
}
