using Microsoft.EntityFrameworkCore;
using RoomBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Office> Offices { get; set; }
    }
}
