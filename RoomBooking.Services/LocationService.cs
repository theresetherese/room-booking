using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _context
                .Locations
                .ToList();
        }
    }
}
