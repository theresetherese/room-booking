﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Models;
using RoomBooking.Web.Models.Home;

namespace RoomBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILocationService _locationService;
        public HomeController(ILocationService locationService)
        {
            if (locationService == null)
                throw new ArgumentNullException(nameof(locationService));

            _locationService = locationService;

            
        }
        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetLocations();

            IndexViewModel vm = new IndexViewModel();
            if (locations != null)
            {
                vm.Locations = locations.Select(l => new LocationViewModel()
                {
                    ID = l.ID,
                    Name = l.Name
                });
            }

            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
