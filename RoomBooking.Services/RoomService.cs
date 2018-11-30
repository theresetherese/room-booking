using Microsoft.EntityFrameworkCore;
using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Services
{
    public class RoomService : IRoomService
    {
        private DataContext _context;
        public RoomService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Room> GetRoom(int roomId)
        {
            if (roomId <= 0)
                throw new ArgumentOutOfRangeException(nameof(roomId));

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetRoomsByLocation(int locationId)
        {
            if (locationId <= 0)
                throw new ArgumentOutOfRangeException(nameof(locationId));

            return await _context
                .Rooms
                .Where(r => r.Location.ID == locationId)
                .ToListAsync();
        }
    }
}
