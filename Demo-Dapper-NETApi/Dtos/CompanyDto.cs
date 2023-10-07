using Entities;

namespace Demo_Dapper_NETApi.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
