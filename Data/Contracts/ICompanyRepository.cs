using Entities;

namespace Data.Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<IQueryable<Company>> GetCompaniesQuery();
        Task<Company> GetCompany(int id);
        Task<Company> CreateCompany(Company company);
    }
}
