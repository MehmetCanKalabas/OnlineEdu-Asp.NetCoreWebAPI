﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public int Star { get; set; }
    }
}