using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;

namespace RoomBooking.Web.Controllers
{
    public class RoomController : Controller
    {
        public RoomController(IRoomService roomService)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> Index()
        {
            throw new NotImplementedException();
        }
    }
}