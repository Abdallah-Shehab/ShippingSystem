
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShippingSysem.BLL.Services;
using ShippingSysem.BLL.Services.Base;
using ShippingSystem.BLL.Services;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories;
using ShippingSystem.DAL.Repositories.Base;
using System.Text;

namespace ShippingSystem.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Services 
            builder.Services.AddDbContext<ShippingDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });

            builder.Services.AddIdentity<Account, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = false;
                // Adjust other password settings as necessary
                options.Password.RequiredLength = 6;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ShippingDBContext>();

            builder.Services.AddIdentityCore<DeliveryAccount>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = false;
                // Adjust other password settings as necessary
                options.Password.RequiredLength = 6;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ShippingDBContext>();

            builder.Services.AddIdentityCore<MerchantAccount>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = false;
                // Adjust other password settings as necessary
                options.Password.RequiredLength = 6;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ShippingDBContext>();



            //Register Emp Services 
            builder.Services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
            builder.Services.AddScoped<IGenericStatusRepository<Governorate>, GenericStatusRepository<Governorate>>();
            builder.Services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped<IGenericStatusRepository<Branch>, GenericStatusRepository<Branch>>();
            //builder.Services.AddScoped<IGenericStatusRepository<Government>, GenericStatusRepository<Government>>();
            builder.Services.AddScoped<IGenericRepository<ExistedEntities>, GenericRepository<ExistedEntities>>();
            //Delivery Accounts
            builder.Services.AddScoped<IGenericRepository<DeliveryAccount>, GenericRepository<DeliveryAccount>>();
            //Delivery Merchant
            builder.Services.AddScoped<IGenericRepository<MerchantAccount>, GenericRepository<MerchantAccount>>();

            builder.Services.AddScoped(typeof(GenericRepository<>));

            //Merchant Accounts
            builder.Services.AddScoped<IGenericRepository<MerchantAccount>, GenericRepository<MerchantAccount>>();
            //builder.Services.AddScoped<IGenericRepository<Permission_User_Entities>, GenericRepository<Permission_User_Entities>>();
            builder.Services.AddScoped<EmployeeService>();
            //builder.Services.AddScoped<PermissionsService>();




            // Delivery Accounts Service
            builder.Services.AddScoped<DeliveryAccountService>();

            // Delivery Merchant Service

            builder.Services.AddScoped<MerchantAccountService>();

            builder.Services.AddScoped<SpecialOfferService>();


            //Register Order Service
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<BranchService>();
            builder.Services.AddScoped<GovernmentService>();


            //Register City Service
            builder.Services.AddScoped<IGenericRepository<Governorate>, GenericRepository<Governorate>>();
            builder.Services.AddScoped<IGenericRepository<City>, GenericRepository<City>>();
            builder.Services.AddScoped<CityReposatry>();
            builder.Services.AddScoped<CityService>();

            //Register Login Service
            builder.Services.AddScoped<GenericLoginReposatry<Account>>();
            builder.Services.AddScoped<GenericLoginReposatry<MerchantAccount>>();
            builder.Services.AddScoped<GenericLoginReposatry<DeliveryAccount>>();
            builder.Services.AddScoped<GenericLoginService<Account>>();
            builder.Services.AddScoped<GenericLoginService<MerchantAccount>>();
            builder.Services.AddScoped<GenericLoginService<DeliveryAccount>>();
            builder.Services.AddScoped<UserManager<Account>>();
            builder.Services.AddScoped<UserManager<MerchantAccount>>();
            builder.Services.AddScoped<UserManager<DeliveryAccount>>();

            //Register ShippingType Service
            builder.Services.AddScoped<IGenericRepository<ShippingType>, GenericRepository<ShippingType>>();
            builder.Services.AddScoped<ShippingTypeService>();

            //Register PaymentType Service
            builder.Services.AddScoped<IGenericRepository<PaymentType>, GenericRepository<PaymentType>>();

            builder.Services.AddScoped<PaymentTypeService>();
            //Register DeliveryType Service
            builder.Services.AddScoped<IGenericRepository<DeliveryType>, GenericRepository<DeliveryType>>();

            builder.Services.AddScoped<DeliveryTpeService>();

            //builder.Services.AddScoped<IPasswordHasher<MerchantAccount>>();

            //  add  CORS configuration:

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });




            builder.Services.AddAuthentication(option =>
            {
                //option.DefaultAuthenticateScheme = "mySchema"; 
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }) //.AddJwtBearer("mySchema", op => {
                .AddJwtBearer(op =>
                {
                    var secrite = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Mohamed Hamdy and Abdallah Shafiq and Hala Mansour and Azza Gamel And Mariem Omran"));
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = secrite,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateActor = false,
                        RequireExpirationTime = false,
                        ValidateIssuerSigningKey = false

                    };
                });







            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}