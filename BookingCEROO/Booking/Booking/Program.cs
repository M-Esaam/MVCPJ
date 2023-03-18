using Booking.Hubs;
using BookingLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RepositoryEF;
using RepositoryPatternWithUOW.Core.Repository;
using RepositoryPatternWithUOW.EF.Repository;

namespace Booking
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Booking.CS"));
            });
            builder.Services.AddIdentity<AppUser, IdentityRole>().
               AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication().AddGoogle(options =>
            {
              IConfiguration googleAuth= builder.Configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuth["ClientId"];
                options.ClientSecret = googleAuth["ClientSecret"];
            });


            builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapHub<ReviewHub>("/Review");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Home}/{id?}");

            app.Run();
        }
    }
}