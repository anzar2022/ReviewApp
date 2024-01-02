using Microsoft.AspNetCore.Mvc;
using Moq;
using ReviewApp.IServices;
using ReviewApp.Model;
using ReviewApp.ReviewTaskApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.UnitTest
{
    public class QuarterControllerTests
    {
        [Fact]
        public async Task GetAllQuarters_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IQuarterService>();
            var controller = new QuarterController(mockService.Object);
            var expectedQuarters = new List<Quarter>(); // Set up expected quarters

            mockService.Setup(service => service.GetAllQuartersAsync()).ReturnsAsync(expectedQuarters);

            // Act
            var result = await controller.GetAllQuarters();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;
            Assert.Equal(expectedQuarters, okObjectResult?.Value);
        }

        [Fact]
        public async Task GetQuarterById_ExistingId_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IQuarterService>();
            var controller = new QuarterController(mockService.Object);
            var expectedQuarter = new Quarter { Id = 1,  QuarterCode = "Q1" }; // Provide a sample quarter for testing
            const int existingId = 1;

            mockService.Setup(service => service.GetQuarterByIdAsync(existingId)).ReturnsAsync(expectedQuarter);

            // Act
            var result = await controller.GetQuarterById(existingId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;
            Assert.Equal(expectedQuarter, okObjectResult?.Value);
        }

        // Write similar test methods for other actions like CreateQuarter, UpdateQuarter, DeleteQuarter...
    }
}
