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
        DbSet<Account> Accounts;
        DbSet<Role> Roles;
        DbSet<Permission> Permissions;
        DbSet<Entity> Entities;
        DbSet<Permission_Role_Entities> Permission_Role_Entities;

        DbSet<Branch> Branches;
        DbSet<City> Cities;
        DbSet<Government> Governments;

        DbSet<Order> Orders;
        DbSet<Product> Products;
        DbSet<PaymentType> PaymentTypes;
        DbSet<ShippingType> ShippingTypes;
        DbSet<MerchantAccount> MerchantAccounts;
        DbSet<DeliveryAccount> DeliveryAccounts;


        public ShippingDBContext(DbContextOptions<ShippingDBContext> options) : base(options)
        {
        }

        public ShippingDBContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<OrderDetails>().HasKey("OrderId", "ProductId");
            builder.Entity<Permission_Role_Entities>().HasKey("role_id", "permission_id", "entity_id");
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
