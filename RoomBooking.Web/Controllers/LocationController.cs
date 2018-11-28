using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;

namespace RoomBooking.Web.Controllers
{
    public class LocationController : Controller
    {
        private ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException(nameof(id), "Id must have a value");

            if(id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be larger than zero");

            var location = _locationService.GetLocation(id.Value);
            return View(await location);
        }
    }
}