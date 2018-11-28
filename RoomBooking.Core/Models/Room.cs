using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Core.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
