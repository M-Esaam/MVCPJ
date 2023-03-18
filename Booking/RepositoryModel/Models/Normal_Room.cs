using BookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModel.Models
{
    public enum Type_Of_Room
    {
        Single,
        Double,
        Triple,
        Fourth
    }
    public class Normal_Room
    {
        [Key]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public Type_Of_Room Type_Of_Room { get; set; }
        


    }
}
