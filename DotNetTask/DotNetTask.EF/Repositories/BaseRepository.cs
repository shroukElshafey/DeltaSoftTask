using DotNetTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTask.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
