using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = _context.Employees;
            return Ok(employees);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByQuery([FromQuery] SearchQuery searchQuery)
        {
            var query = _context.Employees.AsQueryable();

            if (searchQuery.Title != null)
            {
                query = query.Where(x => x.Title.ToLower().Contains(searchQuery.Title.ToLower()));
            }
            if (searchQuery.Department != null)
            {
                query = query.Where(x => x.Department.ToLower().Contains(searchQuery.Department.ToLower()));
            }
            if (searchQuery.SalaryMax != null)
            {
                query = query.Where(x => x.Salary < searchQuery.SalaryMax);
            }
            if (searchQuery.SalaryMin != null)
            {
                query = query.Where(x => x.Salary > searchQuery.SalaryMin);
            }

            if (searchQuery.SortBy != null)
            {
                switch (searchQuery.SortBy.ToLower())
                {
                    case "joindate":
                        query = query.OrderByDescending(x => x.JoinDate);
                        break;
                    case "salary":
                        query = query.OrderByDescending(x => x.Salary);
                        break;
                    default:
                        return BadRequest("Sort option not supported");
                }
            }

            var results = query.ToList();

            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employeeUpdate)
        {
            var employee = _context.Employees.Where(x => x.Id == employeeUpdate.Id).FirstOrDefault();

            if (employee == null) return BadRequest("Employee with id not found");

            employee.FirstName = employeeUpdate.FirstName;
            employee.LastName = employeeUpdate.LastName;
            employee.JoinDate = employeeUpdate.JoinDate;
            employee.BirthDate = employeeUpdate.BirthDate;
            employee.Department = employeeUpdate.Department;
            employee.Title = employeeUpdate.Title;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();

            if (employee == null) return BadRequest($"Id {id} not found");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
