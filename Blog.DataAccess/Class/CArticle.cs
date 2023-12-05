using Blog.DataAccess.Class.Interfaces;
using Blog.DataAccess.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Class
{
    public class CArticle : CGlobalAction<Models.Article>, IArticle
    {
        public readonly ApplicationDbContext _db;
        public CArticle(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Models.Article obj)
        {
            _db.Articles.Update(obj);
        }
    }
}
