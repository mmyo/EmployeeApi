using EmployeeApi.Models;

namespace EmployeeApi.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}