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
        public async Task<IActionResult> Index(int? locationId)
        {
            if (!locationId.HasValue)
                throw new ArgumentNullException(nameof(locationId), "LocationId must have a value");

            var location = _locationService.GetLocation(locationId.Value);
            return View(await location);
        }
    }
}