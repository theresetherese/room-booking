using RoomBooking.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RoomBooking.Core.Tests
{
    public class LocationUnitTest
    {
        [Fact]
        public void ShouldThrowErrorOnEmptyName()
        {
            Location sut = new Location();

            var validationContext = new ValidationContext(sut);

            Action action = () => Validator.ValidateObject(
                sut,
                validationContext,
                true);

            Assert.Throws<ValidationException>(action);
        }
    }
}
