using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WEBUI.DTOs.CourseCategoryDtos
{
    public class CreateCourseCategoryDtos
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }
    }
}
