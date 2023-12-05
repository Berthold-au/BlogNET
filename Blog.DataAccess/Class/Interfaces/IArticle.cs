using Blog.DataAccess.Class.Interfaces;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Class.Interfaces
{
    public interface IArticle : IGlobalAction<Models.Article>
    {
        void Update(Models.Article obj);
    }
}
