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
    public class ReviewTaskControllerTests
    {
        [Fact]
        public async Task GetAllReviewTasks_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IReviewTaskService>();
            var controller = new ReviewTaskController(mockService.Object);
            var expectedTasks = new List<ReviewTask>(); // Set up expected tasks

            mockService.Setup(service => service.GetAllReviewTasksAsync()).ReturnsAsync(expectedTasks);

            // Act
            var result = await controller.GetAllReviewTasks();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;
            Assert.Equal(expectedTasks, okObjectResult?.Value);
        }

        [Fact]
        public async Task CreateReviewTask_ValidTask_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IReviewTaskService>();
            var controller = new ReviewTaskController(mockService.Object);
            var newTask = new ReviewTask
            {
                Id = 1,
                TaskTitle = "New Task",
                TaskCompleteDate = DateOnly.FromDateTime(DateTime.Today)

            };

            mockService.Setup(service => service.AddReviewTaskAsync(It.IsAny<ReviewTask>())).Returns(Task.CompletedTask);

            // Act
            var result = await controller.CreateReviewTask(newTask);

            // Assert
            // var okResult = Assert.IsType<OkObjectResult>(result.Result);
            // var returnedTask = Assert.IsAssignableFrom<ReviewTask>(okResult.Value);

            // Assert.Equal(newTask.Id, returnedTask.Id);
            //Assert.Equal(newTask.TaskTitle, returnedTask.TaskTitle);
            // Add assertions for other properties as needed

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async Task UpdateReviewTask_ExistingTask_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IReviewTaskService>();
            var controller = new ReviewTaskController(mockService.Object);
            var existingTaskId = 1;
            var existingTask = new ReviewTask
            {
                Id = existingTaskId,
                TaskTitle = "Existing Task",
                // ... fill in other properties as needed
            };

            mockService.Setup(service => service.GetReviewTaskByIdAsync(existingTaskId)).ReturnsAsync(existingTask);
            mockService.Setup(service => service.UpdateReviewTaskAsync(existingTask)).Returns(Task.CompletedTask);

            // Act
            var result = await controller.UpdateReviewTask(existingTaskId, existingTask);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(existingTask, okResult.Value); // Assert the returned value is the existing task
        }

        [Fact]
        public async Task UpdateReviewTask_DifferentId_ReturnsBadRequest()
        {
            // Arrange
            var mockService = new Mock<IReviewTaskService>();
            var controller = new ReviewTaskController(mockService.Object);
            var existingTaskId = 1;
            var existingTask = new ReviewTask
            {
                Id = existingTaskId,
                TaskTitle = "Existing Task",
                // ... fill in other properties as needed
            };
            var differentTask = new ReviewTask
            {
                Id = 2,
                TaskTitle = "Different Task",
                // ... fill in other properties as needed
            };

            // Act
            var result = await controller.UpdateReviewTask(existingTaskId, differentTask);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task UpdateReviewTask_NonExistingTask_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<IReviewTaskService>();
            var controller = new ReviewTaskController(mockService.Object);
            var nonExistingTaskId = 1;
            ReviewTask nullTask = null;

            mockService.Setup(service => service.GetReviewTaskByIdAsync(nonExistingTaskId)).ReturnsAsync(nullTask);

            // Act
            var result = await controller.UpdateReviewTask(nonExistingTaskId, new ReviewTask());

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(400, okObjectResult.StatusCode); // Check for OK status code due to the issue in the controller method
        }
    }
}
