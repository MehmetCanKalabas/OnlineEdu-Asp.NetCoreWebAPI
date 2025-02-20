﻿using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var values = _context.Courses.Find(id);
            values.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var values = _context.Courses.Find(id);
            values.IsShown = true;
            _context.SaveChanges();
        }
    }
}
