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
    public class LocationControllerTest
    {
        [Fact]
        public void Constructor_WithLocationService()
        {
            var mockLocationService = new Mock<ILocationService>();
            var mockRoomService = new Mock<IRoomService>();
            new LocationController(mockLocationService.Object, mockRoomService.Object);
        }

        [Fact]
        public void Constructor_ThrowsException_EmptyLocationService()
        {
            var mockRoomService = new Mock<IRoomService>();
            Assert.Throws<ArgumentNullException>(() => 
                new LocationController(null, mockRoomService.Object)
            );
        }

        [Fact]
        public void Constructor_ThrowsException_EmptyRoomService()
        {
            var mockLocationService = new Mock<ILocationService>();
            Assert.Throws<ArgumentNullException>(() => 
                new LocationController(mockLocationService.Object, null)
            );
        }

        [Fact]
        public async Task Index_ReturnsView_WithSingleLocation()
        {
            int locationId = 1;
            // Setup service
            var mockService = new Mock<ILocationService>();
            mockService.Setup(service => service.GetLocation(locationId))
                .ReturnsAsync(GetTestLocation());

            var controller = new LocationController(mockService.Object, null);

            // Run action
            var result = await controller.Index(locationId);

            // Do we have the right view?
            var viewResult = Assert.IsType<ViewResult>(result);
            
            // Do we have the right model?
            var model = Assert.IsAssignableFrom<Location>(viewResult.ViewData.Model);
            
            // Do we have the correct item?
            Assert.Equal(locationId, model.ID);
        }

        [Fact]
        public async Task Index_ThrowsException_ForNullParameter()
        {
            var mockService = new Mock<ILocationService>();

            var controller = new LocationController(mockService.Object, null);

            await Assert.ThrowsAsync<ArgumentNullException>(() => controller.Index(null));
        }

        [Fact]
        public async Task Index_ThrowsException_ForNegativeNumber()
        {
            var mockService = new Mock<ILocationService>();

            var controller = new LocationController(mockService.Object, null);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => controller.Index(-1000));
        }

        private Location GetTestLocation()
        {
            return new Location()
            {
                ID = 1,
                Name = "Linköping"
            };
        }
    }
}
