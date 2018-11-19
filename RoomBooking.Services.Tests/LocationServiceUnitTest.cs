using RoomBooking.Core.Interfaces;
using RoomBooking.TestHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RoomBooking.Services.Tests
{
    public class LocationServiceUnitTest : IClassFixture<DataContextFixture>
    {
        private DataContextFixture _fixture;

        public LocationServiceUnitTest(DataContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ServiceCreationWithContextShouldBeOk()
        {
            ILocationService sut = new LocationService(_fixture.MockContext.Object);
        }

        [Fact]
        public void ServiceCreationWithNullContextShouldFail()
        {
            Action action = () => new LocationService(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetLocationsShouldReturnObjects()
        {
            ILocationService sut = new LocationService(_fixture.MockContext.Object);

            var locations = await sut.GetLocations();

            Assert.NotNull(locations);
            Assert.True(locations.Any());
        }

        [Fact]
        public async Task GetLocationShouldReturnObject()
        {
            ILocationService sut = new LocationService(_fixture.MockContext.Object);

            int expected = 2;
            var location = await sut.GetLocation(expected);
            int actual = location.ID;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetLocationShouldThrowExceptionOnNegativeNumber()
        {
            // Also covers int overflow
            await GetLocationShouldThrowArgumentOutOfRangeException(-5);
        }

        private async Task GetLocationShouldThrowArgumentOutOfRangeException(int input)
        {
            ILocationService sut = new LocationService(_fixture.MockContext.Object);
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetLocation(input));
        }
    }
}
