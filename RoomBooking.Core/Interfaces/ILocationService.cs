using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Core.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocations();
    }
}
