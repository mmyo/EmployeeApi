using EmployeeApi.Controllers;
using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeApiTests.ControllerTests
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo = new();

        [Fact]
        public async Task GetAllEmployees_SuccessAsync()
        {
            _mockRepo.Setup(x => x.GetAllEmployees()).Returns(new List<Employee>());

            var controller = new EmployeeController(_mockRepo.Object);

            var result = await controller.GetAllEmployees();
            var okResult = result.Result as OkObjectResult;

            Assert.IsType<ActionResult<IEnumerable<Employee>>>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAllEmployees_Returns500()
        {
            _mockRepo.Setup(x => x.GetAllEmployees()).Throws(new Exception());

            var controller = new EmployeeController(_mockRepo.Object);

            var result = await controller.GetAllEmployees();
            var okResult = result.Result as ObjectResult;

            Assert.IsType<ActionResult<IEnumerable<Employee>>>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, okResult.StatusCode);
        }
    }
}
