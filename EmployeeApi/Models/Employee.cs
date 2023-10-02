using System.Diagnostics.CodeAnalysis;

namespace EmployeeApi.Models
{
    [ExcludeFromCodeCoverage]
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
    }
}
