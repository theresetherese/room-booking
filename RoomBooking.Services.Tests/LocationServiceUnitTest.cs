using RoomBooking.Core.Interfaces;
using RoomBooking.TestHelpers;
using System;
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
    }
}
