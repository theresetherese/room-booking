using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Data;
using System;
using System.Collections.Generic;

namespace RoomBooking.Services
{
    public class LocationService : ILocationService
    {
        private DataContext _context;
        public LocationService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IEnumerable<Location> GetLocations()
        {
            throw new NotImplementedException();
        }
    }
}
