using OnlineEdu.WEBUI.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WEBUI.DTOs.BlogCategoryDtos
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<ResultBlogDto> Blog { get; set; }
    }
}
