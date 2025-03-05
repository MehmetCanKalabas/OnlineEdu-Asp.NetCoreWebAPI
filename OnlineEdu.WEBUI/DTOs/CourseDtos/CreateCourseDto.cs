using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WEBUI.DTOs.CourseDtos
{
    public class CreateCourseDto
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public int CourseCategoryId { get; set; }
        public int AppUserId { get; set; }

    }
}
