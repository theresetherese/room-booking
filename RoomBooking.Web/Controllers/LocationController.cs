using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Models.Location;

namespace RoomBooking.Web.Controllers
{
    public class LocationController : Controller
    {
        private ILocationService _locationService;
        private IRoomService _roomService;
        public LocationController(
            ILocationService locationService,
            IRoomService roomService)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException(nameof(id), "Id must have a value");

            if(id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be larger than zero");

            var location = await _locationService.GetLocation(id.Value);
            var rooms = await _roomService.GetRoomsByLocation(id.Value);

            IndexViewModel vm = new IndexViewModel();
            vm.Location = location.Name;
            vm.Rooms = rooms.Select(r => new RoomViewModel()
            {
                ID = r.ID,
                Name = r.Name
            });

            return View(vm);
        }
    }
}