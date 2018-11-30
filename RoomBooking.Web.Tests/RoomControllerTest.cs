using Microsoft.AspNetCore.Mvc;
using Moq;
using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Web.Controllers;
using RoomBooking.Web.Models;
using RoomBooking.Web.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RoomBooking.Web.Tests
{
    public class RoomControllerTest
    {
        [Fact]
        public void Constructor_OK()
        {
            var mockRoomService = new Mock<IRoomService>();
            new RoomController(mockRoomService.Object);
        }

        [Fact]
        public void Constructor_ThrowsException_EmptyServices()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new RoomController(null)
            );
        }

        [Fact]
        public async Task Index_ReturnsView_With_IndexViewModel()
        {
            int roomId = 1;

            var mockRoomService = new Mock<IRoomService>();
            mockRoomService.Setup(service => service.GetRoom(roomId))
                .ReturnsAsync(GetTestRoom());

            var controller = new RoomController(
                mockRoomService.Object
            );

            var result = await controller.Index(roomId);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            Assert.Equal(GetTestRoom().Name, model.Room);
            Assert.Equal(GetTestRoom().LocationId, model.LocationId);
        }

        [Fact]
        public async Task Index_ReturnError_RoomNotFound()
        {
            int roomId = 1;

            var mockRoomService = new Mock<IRoomService>();

            var controller = new RoomController(
                mockRoomService.Object
            );

            var result = await controller.Index(roomId);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<ErrorViewModel>(viewResult.ViewData.Model);
        }

        private Room GetTestRoom()
        {
            return new Room()
            {
                ID = 1,
                Name = "Room 1",
                LocationId = 1,
                Location = new Location()
                {
                    ID = 1,
                    Name = "Location 1"
                }
            };
        }
    }
}
