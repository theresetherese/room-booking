using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Models.Home;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ILocationService _locationService;
        public HomeController(ILocationService locationService)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
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
    }
}
