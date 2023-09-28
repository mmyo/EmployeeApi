using EmployeeApi.Models;

namespace EmployeeApi.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult<IEnumerable<Employee>>(_context.Employees);
        }

    }
}
