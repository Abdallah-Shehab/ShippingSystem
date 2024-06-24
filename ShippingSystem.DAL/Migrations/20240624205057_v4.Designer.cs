﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingSystem.DAL.Models;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    [DbContext(typeof(ShippingDBContext))]
    [Migration("20240624205057_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("BranchID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleID");

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GovernmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentID");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GovernmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Government", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BranchID");

                    b.ToTable("Government");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DeliveryID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MerchantID")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneOne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShippingTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("StaffMemberID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAndVillage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalWeight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("DeliveryID");

                    b.HasIndex("MerchantID");

                    b.HasIndex("PaymentTypeID");

                    b.HasIndex("ShippingTypeID");

                    b.HasIndex("StaffMemberID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Permission_Role_Entities", b =>
                {
                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<int>("permission_id")
                        .HasColumnType("int");

                    b.Property<int>("entity_id")
                        .HasColumnType("int");

                    b.Property<int>("entityId")
                        .HasColumnType("int");

                    b.HasKey("role_id", "permission_id", "entity_id");

                    b.HasIndex("entityId");

                    b.HasIndex("permission_id");

                    b.ToTable("Permission_Role_Entities");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("order_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("order_Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.ShippingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShippingTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShippingTypeId");

                    b.ToTable("ShippingType");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.DeliveryAccount", b =>
                {
                    b.HasBaseType("ShippingSystem.DAL.Models.Account");

                    b.Property<decimal>("Company_Percantage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Discount_type")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("DeliveryAccounts", (string)null);
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.MerchantAccount", b =>
                {
                    b.HasBaseType("ShippingSystem.DAL.Models.Account");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Government")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pickup_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Refund_Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MerchantAccounts", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Account", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Branch", "Branch")
                        .WithMany("Accounts")
                        .HasForeignKey("BranchID");

                    b.HasOne("ShippingSystem.DAL.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID");

                    b.Navigation("Branch");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Branch", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Government", "Government")
                        .WithMany()
                        .HasForeignKey("GovernmentID");

                    b.Navigation("Government");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.City", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Government", "Government")
                        .WithMany("Cities")
                        .HasForeignKey("GovernmentID");

                    b.Navigation("Government");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Government", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Order", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithMany("Orders")
                        .HasForeignKey("AccountId");

                    b.HasOne("ShippingSystem.DAL.Models.DeliveryAccount", "DeliveryAccount")
                        .WithMany()
                        .HasForeignKey("DeliveryID");

                    b.HasOne("ShippingSystem.DAL.Models.MerchantAccount", "MerchantAccount")
                        .WithMany()
                        .HasForeignKey("MerchantID");

                    b.HasOne("ShippingSystem.DAL.Models.PaymentType", "paymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeID");

                    b.HasOne("ShippingSystem.DAL.Models.ShippingType", "ShippingType")
                        .WithMany()
                        .HasForeignKey("ShippingTypeID");

                    b.HasOne("ShippingSystem.DAL.Models.Account", "StaffMemberAccount")
                        .WithMany()
                        .HasForeignKey("StaffMemberID");

                    b.Navigation("DeliveryAccount");

                    b.Navigation("MerchantAccount");

                    b.Navigation("ShippingType");

                    b.Navigation("StaffMemberAccount");

                    b.Navigation("paymentType");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.PaymentType", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.PaymentType", null)
                        .WithMany("PaymentTypes")
                        .HasForeignKey("PaymentTypeId");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Permission_Role_Entities", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Entity", "entity")
                        .WithMany()
                        .HasForeignKey("entityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingSystem.DAL.Models.Permission", "permission")
                        .WithMany()
                        .HasForeignKey("permission_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingSystem.DAL.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entity");

                    b.Navigation("permission");

                    b.Navigation("role");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Product", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Order", "order")
                        .WithMany("Products")
                        .HasForeignKey("order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.ShippingType", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.ShippingType", null)
                        .WithMany("Shippers")
                        .HasForeignKey("ShippingTypeId");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.DeliveryAccount", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithOne()
                        .HasForeignKey("ShippingSystem.DAL.Models.DeliveryAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.MerchantAccount", b =>
                {
                    b.HasOne("ShippingSystem.DAL.Models.Account", null)
                        .WithOne()
                        .HasForeignKey("ShippingSystem.DAL.Models.MerchantAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Account", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Branch", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Government", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.PaymentType", b =>
                {
                    b.Navigation("PaymentTypes");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ShippingSystem.DAL.Models.ShippingType", b =>
                {
                    b.Navigation("Shippers");
                });
#pragma warning restore 612, 618
        }
    }
}
