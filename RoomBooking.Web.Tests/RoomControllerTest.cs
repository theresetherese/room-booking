using Moq;
using RoomBooking.Core.Interfaces;
using RoomBooking.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
