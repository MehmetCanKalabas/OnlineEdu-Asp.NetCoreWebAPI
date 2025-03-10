﻿using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
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

        public List<Course> GetAllCoursesWithCategories()
        {
            return _context.Courses.Include(x => x.CourseCategory).ToList();
        }

        public List<Course> GetCoursesByTeacherId(int id)
        {
            return _context.Courses.Include(x=>x.CourseCategoryId).Where(x => x.AppUserId == id).ToList();
        }

        public void ShowOnHome(int id)
        {
            var values = _context.Courses.Find(id);
            values.IsShown = true;
            _context.SaveChanges();
        }
    }
}
