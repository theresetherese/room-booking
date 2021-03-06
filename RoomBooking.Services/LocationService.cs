﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Location> GetLocation(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            return await _context
                .Locations
                .FirstOrDefaultAsync(l => l.ID == id);
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context
                .Locations
                .ToListAsync();
        }
    }
}
