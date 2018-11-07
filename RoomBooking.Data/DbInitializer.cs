using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
