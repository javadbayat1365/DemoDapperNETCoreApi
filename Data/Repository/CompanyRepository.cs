using Dapper;
using Data.Contracts;
using Entities;
using System.Data;

namespace Data.Repository
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";
            var parameters = new DynamicParameters();
            parameters.Add(nameof(Company.Name), company.Name, DbType.String);
            parameters.Add(nameof(Company.Address), company.Address, DbType.String);
            parameters.Add(nameof(Company.Country), company.Country, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteScalarAsync<int>(query, parameters);
                var createdCompany = new Company
                {
                    Id = id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country
                };
                return createdCompany;
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async Task<IQueryable<Company>> GetCompaniesQuery()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.AsQueryable();
            }
        }

        public async Task<Company> GetCompany(int Id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var Parameter = new DynamicParameters();
                Parameter.Add(nameof(Id),Id,DbType.Int64);
                var company =  connection.QuerySingleOrDefaultAsync<Company>(query, Parameter);
                return company.Result;
            }
        }
    }
}
