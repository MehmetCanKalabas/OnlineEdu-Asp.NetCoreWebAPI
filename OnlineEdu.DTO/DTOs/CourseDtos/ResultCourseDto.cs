using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.CourseDtos
{
    public class ResultCourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public ResultCourseCategoryDto resultCourseCategoryDto { get; set; }
        public int CategoryId { get; set; }
    }
}
