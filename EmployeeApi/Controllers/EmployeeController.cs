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
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByQuery([FromQuery] SearchQuery searchQuery)
        {
            var employees = _employeeRepository.GetEmployeesByQuery(searchQuery);

            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            _employeeRepository.InsertEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employeeUpdate)
        {
            _employeeRepository.UpdateEmployee(employeeUpdate);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
