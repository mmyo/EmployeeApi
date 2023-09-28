namespace EmployeeApi.Models
{
    public class SearchQuery
    {
        public int? SalaryMax { get; set; }
        public int? SalaryMin { get; set; }
        public string? Title { get; set; }
        public string? Department { get; set; }
        public string? SortBy { get; set; }
    }
}
