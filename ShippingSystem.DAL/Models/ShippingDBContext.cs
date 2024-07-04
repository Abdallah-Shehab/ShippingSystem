using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class ShippingDBContext : IdentityDbContext<Account, Role, int>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ExistedEntities> Entities { get; set; }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<MerchantAccount> MerchantAccounts { get; set; }
        public DbSet<DeliveryAccount> DeliveryAccounts { get; set; }


        public ShippingDBContext(DbContextOptions<ShippingDBContext> options) : base(options)
        {
        }

        public ShippingDBContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
            // Seed initial account
            var hasher = new PasswordHasher<Account>();
            builder.Entity<Government>().HasData(
			  new Government { Id = 1, Name = "Government1" },
			  new Government { Id = 2, Name = "Government2" }
		  );

			// Seed data for Branches
			builder.Entity<Branch>().HasData(
				new Branch { Id = 1, Name = "Branch1", IsDeleted = false, Status = true, GovernmentID = 1, CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow) },
				new Branch { Id = 2, Name = "Branch2", IsDeleted = false, Status = true, GovernmentID = 2, CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow) }
			);


			builder.Entity<Account>()
			.ToTable("Accounts");

			builder.Entity<DeliveryAccount>()
				.ToTable("DeliveryAccounts");

			builder.Entity<MerchantAccount>()
				.ToTable("MerchantAccounts");

			//builder.Entity<SpecialOffer>()
			//.HasOne<MerchantAccount>()
			//.WithMany()
			//.HasForeignKey(so => so.MerchantId)
			//.OnDelete(DeleteBehavior.Cascade);
			builder.Entity<SpecialOffer>().HasKey(so => so.Id);
			//add data 


			builder.Entity<PaymentType>(entity => entity.HasData(
				new PaymentType { Id = 1, Name = "Cash" },
				new PaymentType { Id = 2, Name = "Visa" }

				));

			builder.Entity<ShippingType>(entity => entity.HasData(
			  new ShippingType { Id = 1, Name = "Normal", Price = 30 },
			  new ShippingType { Id = 2, Name = "7 Days", Price = 50 },
			  new ShippingType { Id = 3, Name = "24 Hour", Price = 70 }


			  ));

			builder.Entity<DeliveryType>(entity => entity.HasData(
			 new DeliveryType { Id = 1, Name = "التسليم في الفرع", Price = 5.99m },
			 new DeliveryType { Id = 2, Name = "التسليم من التاجر", Price = 12.99m }
		 ));
            builder.Entity<MerchantAccount>().HasData(
               new MerchantAccount
               {
                   Id = 1,
                   Name = "John Doe",
                   Address = "123 Main St",
                   Status = true,
                   RoleID = 2,
                   BranchID = 1,
                   IsDeleted = false,
                   UserName = "johndoe",
                   NormalizedUserName = "JOHNDOE",
                   Email = "mariem.doe@example.com",
                   NormalizedEmail = "MARIEM.DOE@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = hasher.HashPassword(null, "passssword"),
                   SecurityStamp = "HBLASJQKDKDKS",
                   ConcurrencyStamp = "12345678-abcd-1234-efgh-1234567890ab",
                   PhoneNumber = "1234567890",
                   PhoneNumberConfirmed = true,
                   TwoFactorEnabled = false,
                   LockoutEnd = null,
                   LockoutEnabled = true,
                   AccessFailedCount = 0,
                   Phone = "1234567890", // Required property
                   StoreName = "Store A",
                   Government = "Government A",
                   City = "City A",
                   Pickup_Price = 10.0m,
                   Refund_Percentage = 0.1m
               });

            builder.Entity<Order>(entity => entity.HasData(
				new Order
				{
					Id = 1,
					ClientName = "John Doe",
					Status = "Pending",
					TotalPrice = 100.00m,
					TotalWeight = 5.00m,
					PhoneOne = "1234567890",
					PhoneTwo = "0987654321",
					Email = "john.doe@example.com",
					Notes = "Handle with care",
					ReceivedMoney = 50.00m,
					DeliveryPrice = 10.00m,
					PaiedMoney = 40.00m,
					CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
					DeliverydDate = null,
					StreetAndVillage = "123 Main St",
					StaffMemberID = null,
					MerchantID = 1,
					DeliveryID = null,
					ShippingTypeID = null,
					PaymentTypeID = null,
					//DeliveryTypeID = 1,
					GovernmentId = null,
					CitytId = null
				}
			));


			builder.Entity<Account>()
			.ToTable("Accounts");

			builder.Entity<DeliveryAccount>()
				.ToTable("DeliveryAccounts");

			builder.Entity<MerchantAccount>()
				.ToTable("MerchantAccounts");

			//builder.Entity<SpecialOffer>()
			//.HasOne<MerchantAccount>()
			//.WithMany()
			//.HasForeignKey(so => so.MerchantId)
			//.OnDelete(DeleteBehavior.Cascade);
			builder.Entity<SpecialOffer>().HasKey(so => so.Id);
			//add data 

			builder.Entity<Role>(entity => entity.HasData(
			  new Role { Id = 1, Name = "Employee" },
			  new Role { Id = 2, Name = "Merchant" },
			  new Role { Id = 3, Name = "Delivery" },
			  new Role { Id = 4, Name = "Admin" }
			  ));

			builder.Entity<ExistedEntities>(entity => entity.HasData(
			new ExistedEntities { Id = 1, Name = "Settings" },
			new ExistedEntities { Id = 2, Name = "Branches" },
			new ExistedEntities { Id = 3, Name = "Employees" },
			new ExistedEntities { Id = 4, Name = "Merchants" },
			new ExistedEntities { Id = 5, Name = "Deliveries" },
			new ExistedEntities { Id = 6, Name = "Governorates" },
			new ExistedEntities { Id = 7, Name = "Cities" },
			new ExistedEntities { Id = 8, Name = "Orders" },
			new ExistedEntities { Id = 9, Name = "Financials" },
			new ExistedEntities { Id = 10, Name = "Reports" }
			 ));
			
			var newAccount = new Account
			{
				Id = 1,
				UserName = "newuser",
				Email = "newuser@example.com",
				Name = "New User",
				Address = "123 New Street",
				Status = true,
				RoleID = 1,
				PasswordHash = hasher.HashPassword(null, "password") // Set a default password
			};
			builder.Entity<Account>().HasData(
			   new Account
			   {
				   Id = 2,
				   Name = "John Doe",
				   Address = "123 Main St",
				   Status = true,
				   RoleID = 1,
				   BranchID = 1,
				   IsDeleted = false,
				   UserName = "johndoe",
				   NormalizedUserName = "JOHNDOE",
				   Email = "john.doe@example.com",
				   NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
				   EmailConfirmed = true,
				   PasswordHash = hasher.HashPassword(null, "passssword"),
				   SecurityStamp = "HBLASJQKDKDKS",
				   ConcurrencyStamp = "12345678-abcd-1234-efgh-1234567890ab",
				   PhoneNumber = "1234567890",
				   PhoneNumberConfirmed = true,
				   TwoFactorEnabled = false,
				   LockoutEnd = null,
				   LockoutEnabled = true,
				   AccessFailedCount = 0
			   },
			   new Account
			   {
				   Id = 3,
				   Name = "Jane Smith",
				   Address = "456 Oak St",
				   Status = true,
				   RoleID = 2,
				   BranchID = 2,
				   IsDeleted = false,
				   UserName = "janesmith",
				   NormalizedUserName = "JANESMITH",
				   Email = "jane.smith@example.com",
				   NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
				   EmailConfirmed = true,
				   PasswordHash = hasher.HashPassword(null, "passwooord"),
				   SecurityStamp = "HJSDKFHSDFHSD",
				   ConcurrencyStamp = "87654321-dcba-4321-hgfe-0987654321ba",
				   PhoneNumber = "0987654321",
				   PhoneNumberConfirmed = true,
				   TwoFactorEnabled = false,
				   LockoutEnd = null,
				   LockoutEnabled = true,
				   AccessFailedCount = 0
			   },
			   new Account
			   {
				   Id = 4,
				   Name = "Ahmed Salah",
				   Address = "123 Main St",
				   Status = true,
				   RoleID = 3,
				   BranchID = 1,
				   IsDeleted = false,
				   UserName = "ahmed",
				   NormalizedUserName = "AHMED",
				   Email = "ahmed.salah@example.com",
				   NormalizedEmail = "AHMED.SALAH@EXAMPLE.COM",
				   EmailConfirmed = true,
				   PasswordHash = hasher.HashPassword(null, "password"),
				   SecurityStamp = "HBLASJQKDKDKS",
				   ConcurrencyStamp = "12345678-abcd-1234-efgh-1234567890ab",
				   PhoneNumber = "1234567890",
				   PhoneNumberConfirmed = true,
				   TwoFactorEnabled = false,
				   LockoutEnd = null,
				   LockoutEnabled = true,
				   AccessFailedCount = 0
			   },
			   new Account
			   {
				   Id = 5,
				   Name = "Mona Magdy",
				   Address = "123 Main St",
				   Status = true,
				   RoleID = 4,
				   BranchID = 1,
				   IsDeleted = false,
				   UserName = "mona",
				   NormalizedUserName = "MONA",
				   Email = "mona.magdy@example.com",
				   NormalizedEmail = "MONA.MAGDY@EXAMPLE.COM",
				   EmailConfirmed = true,
				   PasswordHash = hasher.HashPassword(null, "password"),
				   SecurityStamp = "HBLASJQKDKDKS",
				   ConcurrencyStamp = "12345678-abcd-1234-efgh-1234567890ab",
				   PhoneNumber = "1234567890",
				   PhoneNumberConfirmed = true,
				   TwoFactorEnabled = false,
				   LockoutEnd = null,
				   LockoutEnabled = true,
				   AccessFailedCount = 0
			   }
		   );
			builder.Entity<Account>().HasData(newAccount);

           

           

            builder.Entity<DeliveryAccount>().HasData(
                new DeliveryAccount
                {
                    Id = 1,
                    Name = "John Doe",
                    Address = "123 Main St",
                    Status = true,
                    RoleID = 3,
                    BranchID = 1,
                    IsDeleted = false,
                    UserName = "johndoe",
                    NormalizedUserName = "JOHNDOE",
                    Email = "hamdy.doe@example.com",
                    NormalizedEmail = "HAMDY.DOE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "passssword"),
                    SecurityStamp = "HBLASJQKDKDKS",
                    ConcurrencyStamp = "12345678-abcd-1234-efgh-1234567890ab",
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });

            // Seed permissions for the new account
            builder.Entity<Permission>().HasData(
				new Permission
				{
					Id = 1,
					RoleId = 1,
					EntityId = 1, // Settings
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				},
				new Permission
				{
					Id = 2,
					RoleId = 1,
					EntityId = 2, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 3,
					RoleId = 1,
					EntityId = 3, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 4,
					RoleId = 1,
					EntityId = 4, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 5,
					RoleId = 1,
					EntityId = 5, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 6,
					RoleId = 1,
					EntityId = 6, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 7,
					RoleId = 1,
					EntityId = 7, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 8,
					RoleId = 1,
					EntityId = 8, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 9,
					RoleId = 1,
					EntityId = 9, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}, new Permission
				{
					Id = 10,
					RoleId = 1,
					EntityId = 10, // Branches
					CanRead = false,
					CanWrite = false,
					CanDelete = false,
					CanCreate = false
				}


			);
			base.OnModelCreating(builder);
		}
	}
}
