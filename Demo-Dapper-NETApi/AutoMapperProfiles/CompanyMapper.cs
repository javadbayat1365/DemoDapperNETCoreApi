using AutoMapper;
using Demo_Dapper_NETApi.Dtos;
using Entities;

namespace Demo_Dapper_NETApi.AutoMapperProfiles;

public class CompanyMapper : Profile
{
    public CompanyMapper()
    {
        CreateMap<Company, CompanyDto>()
            .ReverseMap()
            .ForMember(f => f.Employees,option => option.Ignore());
        CreateMap<Company, CompanyForCreationDto>()
            .ReverseMap()
            .ForMember(f => f.Employees, option => option.Ignore());
    }
}
