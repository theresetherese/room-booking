using RoomBooking.Core.Interfaces;
using RoomBooking.TestHelpers;
using System;
using Xunit;

namespace RoomBooking.Services.Tests
{
    public class LocationServiceUnitTest : IClassFixture<DataContextFixture>
    {
        DataContextFixture fixture;

        public LocationServiceUnitTest(DataContextFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ServiceCreationWithContextShouldBeOk()
        {
            ILocationService sut = new LocationService(fixture.MockContext.Object);
        }
    }
}
