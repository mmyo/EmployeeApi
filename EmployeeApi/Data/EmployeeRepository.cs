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

        public IEnumerable<Employee> GetEmployeesByQuery(SearchQuery searchQuery)
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
                        break;
                }
            }

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

    }
}
