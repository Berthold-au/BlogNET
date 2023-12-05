using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Class.Interfaces
{
    public interface IUnitOfWork
    {
        public CArticle article { get; }
        void Save();
    }
}
