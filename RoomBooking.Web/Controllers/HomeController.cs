using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Models;

namespace RoomBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILocationService _locationService;
        public HomeController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetLocations();
            return View(locations);
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
