using Blog.DataAccess.Class.Interfaces;
using Blog.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Class
{
    public class CGlobalAction<T> : IGlobalAction<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> dbSet { get; set; }
        public CGlobalAction(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }
    }
}
