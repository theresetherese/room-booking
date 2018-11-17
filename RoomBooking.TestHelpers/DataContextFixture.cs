using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using RoomBooking.Core.Models;
using RoomBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomBooking.TestHelpers
{
    public class DataContextFixture : IDisposable
    {
        public Mock<DataContext> MockContext { get; private set; }
        public DataContextFixture()
        {
            SetupMockDataContext();
        }
        public void Dispose()
        {
        }

        private void SetupMockDataContext()
        {
            MockContext = new Mock<DataContext>();
            SetupDataContextLocations();
        }

        private void SetupDataContextLocations()
        {
            var locations = new List<Location>
            {
                new Location
                {
                    ID = 1,
                    Name = "Location 1"
                },
                new Location
                {
                    ID = 2,
                    Name = "Location 2"
                }
            };

            var mock = locations.AsQueryable().BuildMockDbSet();
            MockContext.Setup(c => c.Locations).Returns(mock.Object);
        }
    }
}
