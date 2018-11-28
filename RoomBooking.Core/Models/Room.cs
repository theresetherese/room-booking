﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoomBooking.Core.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}