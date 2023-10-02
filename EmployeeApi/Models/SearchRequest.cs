using System.Diagnostics.CodeAnalysis;

namespace EmployeeApi.Models
{
    [ExcludeFromCodeCoverage]
    public class SearchRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? SalaryMax { get; set; }
        public int? SalaryMin { get; set; }
        public string? Title { get; set; }
        public string? Department { get; set; }
        public string? SortBy { get; set; }
    }
}
