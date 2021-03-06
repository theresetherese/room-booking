﻿using Microsoft.EntityFrameworkCore;
using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}
