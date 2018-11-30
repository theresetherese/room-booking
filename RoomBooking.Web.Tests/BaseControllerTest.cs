using Microsoft.AspNetCore.Mvc;
using RoomBooking.Web.Controllers;
using RoomBooking.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RoomBooking.Web.Tests
{
    public class BaseControllerTest
    {
        [Fact]
        public void ErrorView()
        {
            var controller = new BaseController();

            var result = controller.Error();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ErrorViewModel>(viewResult.ViewData.Model);
        }
    }
}
