using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WEBUI.DTOs.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public int Star { get; set; }
    }
}
