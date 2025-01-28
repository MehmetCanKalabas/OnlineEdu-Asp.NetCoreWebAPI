using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> db { get => _context.Set<T>(); }
        public int Count()
        {
            return db.Count();
        }

        public void Create(T entity)
        {
            db.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            db.Remove(entity);
            _context.SaveChanges();
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return db.Where(predicate).Count();
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return db.Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return db.Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return db.Where(predicate).ToList();
        }

        public List<T> GetList()
        {
            return db.ToList();
        }

        public void Update(T entity)
        {
            db.Update(entity);
            _context.SaveChanges();
        }
    }
}
