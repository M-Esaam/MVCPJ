using BookingLibrary.Models;
using Microsoft.AspNetCore.SignalR;
using RepositoryEF;

namespace Booking.Hubs
{
    public class ReviewHub:Hub
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public void NewComment(string Name, string Comment, int HotelID)
        {
            Customer customer = Context.Customers.FirstOrDefault(x => x.AppUser.UserName== Name);
            Clients.All.SendAsync("AddNewComment", customer.AppUserId, Comment, HotelID);//nameof Client method,data 
            Context.Reviews.Add(new Review { CustomerId = customer.AppUserId, Text = Comment, HotelId = HotelID });
            Context.SaveChanges();
        }
    }
}
