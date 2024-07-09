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
        public DbSet<SpecialOffer> SpecialOffer { get; set; }


        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Governorate> Governments { get; set; }
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
            //  builder.Entity<Government>().HasData(
            //    new Government { Id = 1, Name = "Government1" },
            //    new Government { Id = 2, Name = "Government2" }
            //);

            // Seed data for Branches
            //builder.Entity<Branch>().HasData(
            //    new Branch { Id = 1, Name = "Branch1", IsDeleted = false, Status = true, GovernmentID = 1, CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow) },
            //    new Branch { Id = 2, Name = "Branch2", IsDeleted = false, Status = true, GovernmentID = 2, CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow) }
            //);


            builder.Entity<Account>()
            .ToTable("Accounts");

            builder.Entity<DeliveryAccount>()
                .ToTable("DeliveryAccounts");

            builder.Entity<MerchantAccount>()
                .ToTable("MerchantAccounts");


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




            builder.Entity<Account>()
            .ToTable("Accounts");

            builder.Entity<DeliveryAccount>()
                .ToTable("DeliveryAccounts");

            builder.Entity<MerchantAccount>()
                .ToTable("MerchantAccounts");

            builder.Entity<SpecialOffer>().HasKey(so => so.Id);
            //add data 

            builder.Entity<Role>(entity => entity.HasData(

              new Role { Id = 1, Name = "Admin" }
              ));

            builder.Entity<ExistedEntities>(entity => entity.HasData(
            new ExistedEntities { Id = 1, Name = "الإعدادات" },
            new ExistedEntities { Id = 2, Name = "الفروع" },
            new ExistedEntities { Id = 3, Name = "الموظفين" },
            new ExistedEntities { Id = 4, Name = "التجار" },
            new ExistedEntities { Id = 5, Name = "المندوبين" },
            new ExistedEntities { Id = 6, Name = "المحافظات" },
            new ExistedEntities { Id = 7, Name = "المدن" },
            new ExistedEntities { Id = 8, Name = "الطلبات" },
            new ExistedEntities { Id = 9, Name = "الحسابات" },
            new ExistedEntities { Id = 10, Name = "التقارير" }
             ));
            // Seed initial account
            builder.Entity<Account>().HasData(
               new Account
               {
                   Id = 1,
                   Name = "Admin",
                   Address = "123 Main St",
                   Status = true,
                   RoleID = 1,
                   BranchID = null,
                   IsDeleted = false,
                   UserName = "Admin",
                   NormalizedUserName = "JOHNDOE",
                   Email = "Admin@Admin.com",
                   NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = hasher.HashPassword(null, "Admin"),
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



            // Seed permissions for the new account
            builder.Entity<Permission>().HasData(
    new Permission
    {
        Id = 1,
        RoleId = 1,
        EntityId = 1, // Settings
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    },
    new Permission
    {
        Id = 2,
        RoleId = 1,
        EntityId = 2,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 3,
        RoleId = 1,
        EntityId = 3,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 4,
        RoleId = 1,
        EntityId = 4,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 5,
        RoleId = 1,
        EntityId = 5,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 6,
        RoleId = 1,
        EntityId = 6,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 7,
        RoleId = 1,
        EntityId = 7,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 8,
        RoleId = 1,
        EntityId = 8,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 9,
        RoleId = 1,
        EntityId = 9,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }, new Permission
    {
        Id = 10,
        RoleId = 1,
        EntityId = 10,
        CanRead = true,
        CanWrite = true,
        CanDelete = true,
        CanCreate = true
    }
);

            base.OnModelCreating(builder);
        }
    }
}
