﻿using System;
using RoomBooking.Core.Interfaces;
using RoomBooking.Data;

namespace RoomBooking.Services
{
    public class LocationService : ILocationService
    {
        private DataContext _context;
        public LocationService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
    }
}
