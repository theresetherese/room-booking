using RoomBooking.Core.Interfaces;
using RoomBooking.TestHelpers;
using System;
using System.Linq;
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
        public async void GetLocationsShouldReturnObjects()
        {
            ILocationService sut = new LocationService(_fixture.MockContext.Object);

            var locations = await sut.GetLocations();

            Assert.NotNull(locations);
            Assert.True(locations.Any());
        }

        [Fact]
        public async void GetLocationShouldReturnObject()
        {
            ILocationService sut = new LocationService(_fixture.MockContext.Object);

            int expected = 1;
            int actual = (await sut.GetLocation(expected)).ID;

            Assert.Equal(expected, actual);
        }
    }
}
