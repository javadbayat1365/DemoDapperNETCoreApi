using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Demo_Dapper_NETApi.Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Dapper_NETApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyRepository _companyRepo;
    private readonly IMapper _mapper;
    private readonly AutoMapper.IConfigurationProvider _configurationProvider;

    public CompaniesController(ICompanyRepository companyRepo,IMapper mapper,AutoMapper.IConfigurationProvider configurationProvider)
    {
        _companyRepo = companyRepo;
        this._mapper = mapper;
        this._configurationProvider = configurationProvider;
    }
    [HttpGet]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies()
    {
        try
        {
            var companies = await _companyRepo.GetCompaniesQuery();
            var dtos = companies.ProjectTo<CompanyDto>(_configurationProvider).ToList();
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "CompanyById")]
    public async Task<ActionResult<CompanyDto>> GetCompany(int id)
    {
        try
        {
            var company = await _companyRepo.GetCompaniesQuery();
            var dto = company
                      .ProjectTo<CompanyDto>(_configurationProvider)
                      .SingleOrDefault(s => s.Id == id);
            
            if (company == null)
                return NotFound();

            return Ok(dto);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateCompany(CompanyForCreationDto company)
    {
        try
        {
            var entity = _mapper.Map<Company>(company);
            var createdCompany = await _companyRepo.CreateCompany(entity);
            return Ok();
            //return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}
