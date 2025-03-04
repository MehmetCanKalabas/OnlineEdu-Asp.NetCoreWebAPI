using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WEBUI.DTOs.AboutDtos;
using OnlineEdu.WEBUI.DTOs.RoleDtos;

namespace OnlineEdu.WEBUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, ResultRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
        }
    }
}
