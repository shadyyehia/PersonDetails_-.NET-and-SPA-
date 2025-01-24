using idealrating.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PersonDetails.Models;
using PersonDetails.Services;

namespace PersonDetails.Tests
{
    public class PersonDetailsControllerTests
    {
        private readonly Mock<ILogger<PersonDetailsController>> _mockLogger;
        private readonly Mock<IPersonService> _mockPersonService;
        private readonly PersonDetailsController _controller;

        public PersonDetailsControllerTests()
        {
            _mockLogger = new Mock<ILogger<PersonDetailsController>>();
            _mockPersonService = new Mock<IPersonService>();
            _controller = new PersonDetailsController(_mockLogger.Object, _mockPersonService.Object);
        }

        [Fact]
        public void GetPersons_ReturnsOkResult_WhenValidFilterIsPassed()
        {
            // Arrange
            var filter = "John";
            var mockPersons = new List<Person> { new Person { first_name = "John", last_name = "Doe" } };
            _mockPersonService.Setup(s => s.GetPersons(filter)).ReturnsAsync(mockPersons);

            // Act
            var result = _controller.GetPersons(filter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockPersons, okResult.Value);
        }

        [Fact]
        public void GetPersons_ReturnsOkResult_WhenNoFilterIsPassed()
        {
            // Arrange
            var mockPersons = new List<Person> { new Person { first_name = "Jane", last_name = "Doe" } };
            _mockPersonService.Setup(s => s.GetPersons(null)).ReturnsAsync(mockPersons);

            // Act
            var result =  _controller.GetPersons(null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockPersons, okResult.Value);
        }

        [Fact]
        public void GetPersons_ReturnsServerErrorResult_WhenExceptionIsThrown()
        {
            // Arrange
            var filter = "John";
            _mockPersonService.Setup(s => s.GetPersons(filter)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = _controller.GetPersons(filter);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public void GetPersons_ReturnsEmptyList_WhenNoPersonsFound()
        {
            // Arrange
            var filter = "Unknown";
            var mockPersons = new List<Person>();
            _mockPersonService.Setup(s => s.GetPersons(filter)).ReturnsAsync(mockPersons);

            // Act
            var result =  _controller.GetPersons(filter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        
            Assert.Empty((List<Person>)okResult.Value);
        }

        [Fact]
        public void GetPersons_ReturnsOkResult_WhenFilterReturnsMixedSources()
        {
            // Arrange
            var filter = "John";
            var mockPersons = new List<Person>
            {
                new Person {first_name = "John", last_name = "Doe"},
                new Person {first_name = "John", last_name = "Smith"}
            };
            _mockPersonService.Setup(s => s.GetPersons(filter)).ReturnsAsync(mockPersons);

            // Act
            var result =  _controller.GetPersons(filter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockPersons, okResult.Value);
        }
    }
}
