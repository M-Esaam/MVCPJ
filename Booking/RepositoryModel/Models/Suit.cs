using BookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModel.Models
{
    public class Suit
    {
        [Key]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room ?Room { get; set; }
        public int Num_Of_Rooms { get; set; }

    }
}
