using AutoMapper;
using Demo_Dapper_NETApi.DTOs;
using Entities;

namespace Demo_Dapper_NETApi.AutoMapperProfiles;

public class CompanyMapper : Profile
{
    public CompanyMapper()
    {
        CreateMap<Company, CompanyDTO>()
            .ReverseMap();
        //.ForMember(f => f.Employees,option => option.Ignore());
        CreateMap<Company, CompanyForCreationDTO>()
            .ReverseMap();
            //.ForMember(f => f.Employees, option => option.Ignore());
        CreateMap<Company, CompanyForUpdateDto>().ReverseMap();
    }
}
