using Microsoft.EntityFrameworkCore;
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
            IQueryable<Location> locations = new List<Location>
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
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Returns(locations.Provider);
            mockSet.As<IQueryable<Location>>().Setup(m => m.Expression).Returns(locations.Expression);
            mockSet.As<IQueryable<Location>>().Setup(m => m.ElementType).Returns(locations.ElementType);
            mockSet.As<IQueryable<Location>>().Setup(m => m.GetEnumerator()).Returns(locations.GetEnumerator());

            MockContext.Setup(c => c.Locations).Returns(mockSet.Object);
        }
    }
}
