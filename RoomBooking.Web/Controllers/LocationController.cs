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
            throw new NotImplementedException();
        }
        public async Task<IActionResult> Index(int? locationId)
        {
            throw new NotImplementedException();
        }
    }
}