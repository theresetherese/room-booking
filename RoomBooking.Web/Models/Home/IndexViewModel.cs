using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Web.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<LocationViewModel> Locations { get; set; }
    }

    public class LocationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
