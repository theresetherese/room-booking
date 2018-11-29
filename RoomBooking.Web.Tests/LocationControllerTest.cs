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
using RoomBooking.Web.Models.Location;

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
        public async Task Index_ReturnsView_WithSingleLocationAndRooms()
        {
            int locationId = 1;
            // Setup service
            var mockLocationService = new Mock<ILocationService>();
            mockLocationService.Setup(service => service.GetLocation(locationId))
                .ReturnsAsync(GetTestLocation());

            var mockRoomService = new Mock<IRoomService>();
            mockRoomService.Setup(service => service.GetRoomsByLocation(locationId))
                .ReturnsAsync(GetTestRooms());

            var controller = new LocationController(
                mockLocationService.Object, 
                mockRoomService.Object
            );

            // Run action
            var result = await controller.Index(locationId);

            // Do we have the right view?
            var viewResult = Assert.IsType<ViewResult>(result);

            // Do we have the right model?
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            // Do we have the right location?
            Assert.Equal(GetTestLocation().Name, model.Location);

            // Do we have the correct number of rooms?
            Assert.Equal(GetTestRooms().Count(), model.Rooms.Count());

            //Have the rooms been mapped accordingly?
            var expected = GetTestRooms().Select(r => new RoomViewModel()
            {
                ID = r.ID,
                Name = r.Name
            }).First();
            var actual = model.Rooms.First();
            Assert.Equal(expected, actual);
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

        private IEnumerable<Room> GetTestRooms()
        {
            return new List<Room>()
            {
                new Room()
                {
                    ID = 1,
                    Name = "Room 1"
                },
                new Room()
                {
                    ID = 2,
                    Name = "Room 2"
                },
                new Room()
                {
                    ID = 3,
                    Name = "Room 3"
                }
            };
        }
    }
}
