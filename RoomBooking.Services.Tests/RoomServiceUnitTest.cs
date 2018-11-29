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
    }
}
