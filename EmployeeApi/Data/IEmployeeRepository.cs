using EmployeeApi.Models;

namespace EmployeeApi.Data
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeesByQuery(SearchQuery searchQuery);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employeeUpdate);
    }
}