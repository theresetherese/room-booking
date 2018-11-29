using RoomBooking.Core.Interfaces;
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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Room>> GetRoomsByLocation(int locationId)
        {
            if (locationId <= 0)
                throw new ArgumentOutOfRangeException(nameof(locationId));

            throw new NotImplementedException();
        }
    }
}
