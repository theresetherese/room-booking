﻿using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Services
{
    public class RoomService : IRoomService
    {
        private DataContext _context;
        public RoomService(DataContext context)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Room>> GetRoomsByLocation(int locationId)
        {
            throw new NotImplementedException();
        }
    }
}
