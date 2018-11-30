using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Models.Room;

namespace RoomBooking.Web.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        }
        public async Task<IActionResult> Index(int id)
        {
            var room = await _roomService.GetRoom(id);

            IndexViewModel vm = new IndexViewModel();
            vm.Room = room.Name;

            return View(vm);
        }
    }
}