using BookingLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryModel.Interfaces;
using RepositoryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEF
{
    public class ApplicationDbContext :IdentityDbContext<AppUser>
    {
        //private UserManager<AppUser> userManager;
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) :base(options) //UserManager<AppUser> userManager
        {
            //this.userManager = userManager;
        }

        public ApplicationDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QG04GD4\\INTAKE43;Initial Catalog=Booking_System;Integrated Security=True; trust server certificate = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //AppUser userModel = new AppUser();

            //userModel.UserName = "Youstina";
            //userModel.PasswordHash = "Y10002000#";
            //userModel.Email = "shagon288@gmail.com";
            //userModel.gender = Gender.Female;
            //userManager.AddToRoleAsync(userModel, "Admin");
            //userManager.CreateAsync(userModel);


            //Admin admin = new Admin();
            //admin.AppUserId = userModel.Id;

            //var modelsCreating = new List<IOnModelCreate>();
            //modelsCreating.Add(userModel);
            //modelsCreating.Add(admin);



            //modelBuilder.Entity<AppUser>().HasData(new AppUser()
            //{
            //    UserName = "Youstina",
            //    PasswordHash = "Y10002000#",
            //    Email = "shagon288@gmail.com",
            //    gender = Gender.Female,

            //});

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.NoAction;
            }

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel_Manager> Hotel_Managers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Booking> Bookings { get; set; }
       
    }
}
