using Blog.DataAccess.Class.Interfaces;
using Blog.DataAccess.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Class
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _db;
        public CArticle article { get; private set;  }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            article = new CArticle(db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
