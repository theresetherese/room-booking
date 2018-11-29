using System;
using Xunit;
using Moq;
using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RoomBooking.Web.Models.Home;

namespace RoomBooking.Web.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Constructor_WithLocationService()
        {
            var mockService = new Mock<ILocationService>();
            new HomeController(mockService.Object);
        }

        [Fact]
        public void Constructor_ThrowsException_EmptyLocationService()
        {
            Assert.Throws<ArgumentNullException>(() => new HomeController(null));
        }

        [Fact]
        public async Task Index_ReturnsView_WithLocations()
        {
            // Setup service
            var mockService = new Mock<ILocationService>();
            mockService.Setup(service => service.GetLocations())
                .ReturnsAsync(GetTestLocations());

            var controller = new HomeController(mockService.Object);

            // Run action
            var result = await controller.Index();

            // Do we have the right view?
            var viewResult = Assert.IsType<ViewResult>(result);
            
            // Do we have the right model?
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);
            
            // Do we have the correct number of locations?
            Assert.Equal(2, model.Locations.Count());

            //Have the locations been mapped accordingly?
            var expected = GetTestLocations().Select(l => new LocationViewModel()
            {
                ID = l.ID,
                Name = l.Name
            }).First();
            var actual = model.Locations.First();
            Assert.Equal(expected.ID, actual.ID);
        }

        private IEnumerable<Location> GetTestLocations()
        {
            return new List<Location>()
            {
                new Location()
                {
                    ID = 1,
                    Name = "Linköping"
                },
                new Location()
                {
                    ID = 2,
                    Name = "Norrköping"
                }
            };
        }
    }
}
