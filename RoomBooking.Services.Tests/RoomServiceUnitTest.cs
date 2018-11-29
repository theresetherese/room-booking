using RoomBooking.Core.Interfaces;
using RoomBooking.TestHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RoomBooking.Services.Tests
{
    public class RoomServiceUnitTest : IClassFixture<DataContextFixture>
    {
        private DataContextFixture _fixture;

        public RoomServiceUnitTest(DataContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ServiceCreationWithContextShouldBeOk()
        {
            IRoomService sut = new RoomService(_fixture.MockContext.Object);
        }

        [Fact]
        public void ServiceCreationWithNullContextShouldFail()
        {
            Action action = () => new RoomService(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetRoomsByLocationShouldThrowExceptionOnNegativeNumber()
        {
            // Also covers int overflow
            IRoomService sut = new RoomService(_fixture.MockContext.Object);
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetRoomsByLocation(-1000));
        }

        [Fact]
        public async Task GetRoomsByLocationShouldReturnObjects()
        {
            IRoomService sut = new RoomService(_fixture.MockContext.Object);

            int locationId = 1;
            var rooms = await sut.GetRoomsByLocation(locationId);

            Assert.NotNull(rooms);
            Assert.True(rooms.Any());
        }
    }
}
