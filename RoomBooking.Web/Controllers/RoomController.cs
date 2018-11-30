using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Models.Room;
using System;
using System.Threading.Tasks;

namespace RoomBooking.Web.Controllers
{
    public class RoomController : BaseController
    {
        private IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        }
        public async Task<IActionResult> Index(int id)
        {
            var room = await _roomService.GetRoom(id);

            if (room == null)
                return Error();

            IndexViewModel vm = new IndexViewModel();
            vm.Room = room.Name;

            return View(vm);
        }
    }
}