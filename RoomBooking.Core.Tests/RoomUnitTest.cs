using RoomBooking.Core.Models;
using RoomBooking.TestHelpers;
using Xunit;

namespace RoomBooking.Core.Tests
{
    public class RoomUnitTest : UnitTestBase
    {
        [Fact]
        public void ShouldThrowErrorOnEmptyName()
        {
            Room sut = new Room();

            ValidationShouldThrowError(sut);
        }

        [Fact]
        public void ShouldThrowErrorOnMissingLocation()
        {
            Room sut = new Room();
            sut.Name = "RoomName";

            ValidationShouldThrowError(sut);
        }
    }
}
