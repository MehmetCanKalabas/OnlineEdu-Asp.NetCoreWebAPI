using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseCategoryMapping : Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<CreateCourseCategoryDtos, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoryDto, CourseCategory>().ReverseMap();
        }
    }
}
