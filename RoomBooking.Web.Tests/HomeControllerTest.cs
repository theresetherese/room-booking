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

namespace RoomBooking.Web.Tests
{
    public class HomeControllerTest
    {
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
            var model = Assert.IsAssignableFrom<IEnumerable<Location>>(viewResult.ViewData.Model);
            
            // Do we have the correct number of items?
            Assert.Equal(2, model.Count());
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
