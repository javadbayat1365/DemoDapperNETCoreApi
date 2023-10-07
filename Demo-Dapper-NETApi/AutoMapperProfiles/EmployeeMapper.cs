using AutoMapper;
using Demo_Dapper_NETApi.DTOs;
using Entities;

namespace Demo_Dapper_NETApi.AutoMapperProfiles
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();
        }
    }
}
