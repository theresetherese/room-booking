using Microsoft.EntityFrameworkCore;
using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Services
{
    public class LocationService : ILocationService
    {
        private DataContext _context;
        public LocationService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context
                .Locations
                .ToListAsync();
        }
    }
}
