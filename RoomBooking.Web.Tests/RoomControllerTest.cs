using Microsoft.AspNetCore.Mvc;
using Moq;
using RoomBooking.Core.Interfaces;
using RoomBooking.Core.Models;
using RoomBooking.Web.Controllers;
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
            int roomId = 2;

            var mockRoomService = new Mock<IRoomService>();

            var controller = new RoomController(
                mockRoomService.Object
            );

            // Run action
            var result = await controller.Index(roomId);

            // Do we have the right view?
            var viewResult = Assert.IsType<ViewResult>(result);

            // Do we have the right model?
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);
        }

        private Room GetTestRoom()
        {
            return new Room()
            {
                ID = 1,
                Name = "Room 1"
            };
        }
    }
}
