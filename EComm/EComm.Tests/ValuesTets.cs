using EComm.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace EComm.Tests
{
    public class ValuesTests
    {
        [Fact]
        public void GetAllValues()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            IEnumerable<string> values = controller.Get().Value;

            // Assert
            Assert.Equal(2, values.Count());
        }
    }
}
