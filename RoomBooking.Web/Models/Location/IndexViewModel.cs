using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Web.Models.Location
{
    public class IndexViewModel
    {
        public string Location { get; set; }
        public IEnumerable<RoomViewModel> Rooms { get; set; }
    }

    public class RoomViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
