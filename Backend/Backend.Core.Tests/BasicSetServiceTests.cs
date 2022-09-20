using Backend.Core.Models;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Core.Tests
{
    public class BasicSetServiceTests
    {
        [Fact]
        public void GetBasicalSetsSmallInfoBySection_ExistingSection_ReturnListOfExercises()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new BasicSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var list = service.GetBasicalSetsSmallInfoBySection(1);

            // Assert
            Assert.NotNull(list);
        }

        [Fact]
        public void GetBasicalSetsSmallInfoBySection_NonExistingSection_ReturnNull()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new BasicSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var list = service.GetBasicalSetsSmallInfoBySection(10);

            // Assert
            Assert.Null(list);
        }

        [Fact]
        public void GetBasicalSetFullDescById_ExistingId_ReturnBasicalSet()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new BasicSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var set = service.GetBasicalSetFullDescById(1);

            // Assert
            Assert.Equal(1, set.Id);
        }

        [Fact]
        public void GetBasicalSetFullDescById_NonExistingId_ReturnNull()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new BasicSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var set = service.GetBasicalSetsSmallInfoBySection(10000);

            // Assert
            Assert.Null(set);
        }
    }
}
