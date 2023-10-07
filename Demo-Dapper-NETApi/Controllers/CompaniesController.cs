using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Demo_Dapper_NETApi.DTOs;
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
    public async Task<ActionResult<List<CompanyDTO>>> GetCompanies()
    {
        try
        {
            var companies = await _companyRepo.GetCompaniesQuery();
            var dtos = companies.ProjectTo<CompanyDTO>(_configurationProvider).ToList();
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "CompanyById")]
    public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
    {
        try
        {
            var company = await _companyRepo.GetCompaniesQuery();
            var dto = company
                      .ProjectTo<CompanyDTO>(_configurationProvider)
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
    public async Task<ActionResult> CreateCompany(CompanyForCreationDTO company)
    {
        try
        {
            var entity = _mapper.Map<Company>(company);
            var createdCompany = await _companyRepo.CreateCompany(entity);
            var DTO = _mapper.Map<CompanyDTO>(createdCompany);
            return Ok(createdCompany);
            //return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto company)
    {
        try
        {
            var dbCompany = await _companyRepo.GetCompany(id);
            if (dbCompany == null)
                return NotFound();
            var companyEntity = _mapper.Map(company, dbCompany);
            await _companyRepo.UpdateCompany(id, companyEntity);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        try
        {
            var dbCompany = await _companyRepo.GetCompany(id);
            if (dbCompany == null)
                return NotFound();
            await _companyRepo.DeleteCompany(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetCompanyByEmployeeId(int Id)
    {
        var company =await _companyRepo.GetCompanyByEmployeeId(Id);
        var Dto = _mapper.Map<CompanyDTO>(company);
        return Ok(Dto);
    }
}
