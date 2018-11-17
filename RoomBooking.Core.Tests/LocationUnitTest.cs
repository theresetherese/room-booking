using RoomBooking.Core.Models;
using RoomBooking.TestHelpers;
using Xunit;

namespace RoomBooking.Core.Tests
{
    public class LocationUnitTest : UnitTestBase
    {
        [Fact]
        public void ShouldThrowErrorOnEmptyName()
        {
            Location sut = new Location();

            ValidationShouldThrowError(sut);
        }
    }
}
