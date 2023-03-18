using BookingLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) :base(options)
        {

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
            modelBuilder.Entity<AppUser>().HasData(new[]
              {
                 new AppUser
                     {
                            Id="22",
                            UserName="sara",
                            NormalizedUserName="SARA",
                            NID="12345678901234",
                            gender=Gender.Male,
                            City="sowhag",
                            Country="Egypt",
                            Street="jijdijdied",
                            IsDeleted=false,
                            PasswordHash="Ag1234#"
                     },

                 new AppUser
                     {
                            Id="1",
                            UserName="ahmed",
                            NormalizedUserName="AHMED",
                            NID="12345678901234",
                            gender=Gender.Male,
                            City="sowhag",
                            Country="Egypt",
                            Street="jijdijdied",
                            IsDeleted=false,
                            PasswordHash="Ag1234#"
                     },

                 new AppUser
                     {
                            Id="2",
                            UserName="Mahmod",
                            NormalizedUserName="MAHMOD",
                            NID="12345678901234",
                            gender=Gender.Male,
                            City="sowhag",
                            Country="Egypt",
                            Street="jijdijdied",
                            IsDeleted=false,
                            PasswordHash="Ag1234#"
                     }

            });
            modelBuilder.Entity<Admin>().HasData(new[]
            {
                 new Admin
                     {
                        AppUserId="22",
                        TotalProfit=0,

                     }

            });
            modelBuilder.Entity<Hotel_Manager>().HasData(new[]
            {
                 new Hotel_Manager
                     {
                        AppUserId="1",
                        HotelId=null

                     },

                 new Hotel_Manager
                     {
                        AppUserId="2",
                        HotelId=null

                     }

            });

            modelBuilder.Entity<Hotel>().HasData(new[]
            {
                 new Hotel
                     {
                        Id=3,
                        Name="holy",
                        Description="vhmvhhbhggjhjklmkl",
                        Rate=Hotel_Rate_Star.FiveStars,
                        City="hurgada",
                        Country="egypt",
                        Street="ghghg",
                        Hotel_ManagerId="1",
                        IsConfermed=true,
                        IsDeleted=false,

                     },

                 new Hotel
                     {
                        Id=6,
                        Name="holy",
                        Description="vhmvhhbhggjhjklmkl",
                        Rate=Hotel_Rate_Star.FiveStars,
                        City="hurgada",
                        Country="egypt",
                        Street="ghghg",
                        Hotel_ManagerId="2",
                        IsConfermed=true,
                        IsDeleted=false,

                     }

            });


            modelBuilder.Entity<Room>().HasData(new[]
            {
                 new Room
                     {
                        Id=1,
                        Description="hhuehuehuhdjhskcsndvjvjnjjjjhhduewyromknzvbmxb",
                        Room_Num=200,
                        NumOfAdults=3,
                        Cost_Per_Night=900,
                        ISavailable=true,
                        HotelId=3,
                        IsDeleted=false,

                     },
                 new Room
                     {
                        Id=2,
                        Description="hhuehuehuhdjhskcsndvjvjnjjjjhhduewyromknzvbmxb",
                        Room_Num=210,
                        NumOfAdults=2,
                        Cost_Per_Night=700,
                        ISavailable=true,
                        HotelId=3,
                        IsDeleted=false,

                     },
                 new Room
                     {
                        Id=3,
                        Description="hhuehuehuhdjhskcsndvjvjnjjjjhhduewyromknzvbmxb",
                        Room_Num=100,
                        NumOfAdults=6,
                        Cost_Per_Night=1500,
                        ISavailable=true,
                        HotelId=3,
                        IsDeleted=false,

                     },
                 new Room
                     {
                        Id=4,
                        Description="hhuehuehuhdjhskcsndvjvjnjjjjhhduewyromknzvbmxb",
                        Room_Num=110,
                        NumOfAdults=2,
                        Cost_Per_Night=700,
                        ISavailable=true,
                        HotelId=6,
                        IsDeleted=false,

                     },
                 new Room
                     {
                        Id=5,
                        Description="hhuehuehuhdjhskcsndvjvjnjjjjhhduewyromknzvbmxb",
                        Room_Num=180,
                        NumOfAdults=1,
                        Cost_Per_Night=600,
                        ISavailable=true,
                        HotelId=6,
                        IsDeleted=false,

                     },
                 new Room
                     {
                        Id=6,
                        Description="hhuehuehuhdjhskcsndvjvjnjjjjhhduewyromknzvbmxb",
                        Room_Num=200,
                        NumOfAdults=7,
                        Cost_Per_Night=2000,
                        ISavailable=true,
                        HotelId=6,
                        IsDeleted=false,

                     }

            });
            modelBuilder.Entity<Normal_Room>().HasData(new[]
            {
                 new Normal_Room
                     {
                        RoomId=1,
                        Type_Of_Room=Type_Of_Room.Triple

                     },
               new Normal_Room
                     {
                        RoomId=2,
                        Type_Of_Room=Type_Of_Room.Double

                     },
               new Normal_Room
                     {
                        RoomId=4,
                        Type_Of_Room=Type_Of_Room.Double

                     },
               new Normal_Room
                     {
                        RoomId=5,
                        Type_Of_Room=Type_Of_Room.Single

                     },

            });
            modelBuilder.Entity<Suit>().HasData(new[]
            {
                 new Suit
                     {
                        RoomId=3,
                        Num_Of_Rooms=3,

                     },
               new Suit
                     {
                       RoomId=6,
                       Num_Of_Rooms=3,

                     }

            });
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
        public DbSet<image> images { get; set; }
        public DbSet<Suit> Suits { get; set; }
        public DbSet<Normal_Room> Normals { get; set; }

    }

}
