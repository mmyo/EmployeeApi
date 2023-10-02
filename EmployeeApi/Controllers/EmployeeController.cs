using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAllEmployees();

                return Ok(employees);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log this exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByQuery([FromQuery] SearchRequest searchRequest)
        {
            try
            {
                var employees = _employeeRepository.GetEmployeesByQuery(searchRequest);

                return Ok(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log this exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            try
            {
                _employeeRepository.InsertEmployee(employee);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log this exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employeeUpdate)
        {
            try
            {
                _employeeRepository.UpdateEmployee(employeeUpdate);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log this exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log this exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
    }
}
