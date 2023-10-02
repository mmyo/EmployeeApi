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

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public IEnumerable<Employee> GetEmployeesByQuery(SearchRequest searchRequest)
        {
            var query = GenerateSearchQuery(searchRequest);

            return query.ToList();
        }

        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
        }

        public void UpdateEmployee(Employee employeeUpdate)
        {
            var employee = _context.Employees.Where(x => x.Id == employeeUpdate.Id).FirstOrDefault();

            if (employee != null)
            {
                employee.FirstName = employeeUpdate.FirstName;
                employee.LastName = employeeUpdate.LastName;
                employee.JoinDate = employeeUpdate.JoinDate;
                employee.BirthDate = employeeUpdate.BirthDate;
                employee.Department = employeeUpdate.Department;
                employee.Title = employeeUpdate.Title;

                _context.SaveChangesAsync();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChangesAsync();
            }
        }

        private IQueryable<Employee> GenerateSearchQuery(SearchRequest searchRequest)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchRequest.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(searchRequest.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchRequest.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(searchRequest.LastName.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchRequest.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(searchRequest.Title.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchRequest.Department))
            {
                query = query.Where(x => x.Department.ToLower().Contains(searchRequest.Department.ToLower()));
            }
            if (searchRequest.SalaryMax != null)
            {
                query = query.Where(x => x.Salary < searchRequest.SalaryMax);
            }
            if (searchRequest.SalaryMin != null)
            {
                query = query.Where(x => x.Salary > searchRequest.SalaryMin);
            }

            if (searchRequest.SortBy != null)
            {
                switch (searchRequest.SortBy.ToLower())
                {
                    case "joindate":
                        query = query.OrderByDescending(x => x.JoinDate);
                        break;
                    case "salary":
                        query = query.OrderByDescending(x => x.Salary);
                        break;
                    default:
                        break;
                }
            }

            return query;
        }

    }
}
