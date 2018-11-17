﻿using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocations();
    }
}
