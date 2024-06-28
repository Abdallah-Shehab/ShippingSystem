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
        public DbSet<Account> Accounts;
        public DbSet<Role> Roles;
        public DbSet<Permission> Permissions;
        public DbSet<Entity> Entities;
        public DbSet<Permission_User_Entities> Permission_Role_Entities;
        public DbSet<Branch> Branches;
        public DbSet<City> Cities;
        public DbSet<Government> Governments;
        public DbSet<Order> Orders;
        public DbSet<Product> Products;
        public DbSet<PaymentType> PaymentTypes;
        public DbSet<ShippingType> ShippingTypes;
        public DbSet<MerchantAccount> MerchantAccounts;
        public DbSet<DeliveryAccount> DeliveryAccounts;


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
            //builder.Entity<OrderDetails>().HasKey("OrderId", "ProductId");
            builder.Entity<Permission_User_Entities>().HasKey("user_id", "permission_id", "entity_id");


            builder.Entity<Account>()
            .ToTable("Accounts");

            builder.Entity<DeliveryAccount>()
                .ToTable("DeliveryAccounts");

            builder.Entity<MerchantAccount>()
                .ToTable("MerchantAccounts");

            base.OnModelCreating(builder);
        }
    }
}
