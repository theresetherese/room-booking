using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RoomBooking.TestHelpers
{
    public class UnitTestBase
    {
        public void ValidationShouldThrowError(object sut)
        {
            var validationContext = new ValidationContext(sut);

            Action action = () => Validator.ValidateObject(
                sut,
                validationContext,
                true);

            Assert.Throws<ValidationException>(action);
        }
    }
}
