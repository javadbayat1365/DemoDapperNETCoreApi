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
        /// <summary>
        /// Create Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<Company> CreateCompany(Company company)
        {
            var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";
            var parameters = new DynamicParameters();
            parameters.Add(nameof(Company.Name), company.Name, DbType.String);
            parameters.Add(nameof(Company.Address), company.Address, DbType.String);
            parameters.Add(nameof(Company.Country), company.Country, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                //var id = await connection.ExecuteAsync(query, parameters);

                //Insert & Select
                var id = await connection.QuerySingleOrDefaultAsync(query, parameters);
                var createdCompany = new Company
                {
                    Id = id ?? 0,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country
                };
                return createdCompany;
            }
        }
        /// <summary>
        /// Get All Companies
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
        /// <summary>
        /// Just For Automapper(with out service layer)
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<Company>> GetCompaniesQuery()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.AsQueryable();
            }
        }
        /// <summary>
        /// Get one row
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update Company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task UpdateCompany(int id, Company company)
        {
            var query = "UPDATE Companies SET Name = @Name, Address = @Address, Country = @Country WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        /// <summary>
        /// Delete Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCompany(int id)
        {
            var query = "DELETE FROM Companies WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        /// <summary>
        /// Call StoredProcedure
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Company> GetCompanyByEmployeeId(int Id)
        {
            var procedureName = "ShowCompanyByEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add(nameof(Id),Id, DbType.Int64, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var company =await connection.QueryFirstAsync<Company>(procedureName,parameters,commandType: CommandType.StoredProcedure);
                return company;
            }

        }
    }
}
