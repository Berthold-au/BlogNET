using Blog.DataAccess.Class.Interfaces;
using Blog.DataAccess.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogNET.Controllers
{
    [Area("App")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Article> listArticles = _unitOfWork.article.GetAll().ToList();
            return View(listArticles);
        }

        public IActionResult Show(int? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound("Cette article n'existe pas");
            }

            Article article = _unitOfWork.article.Get(u => u.Id == id);
            if(article == null)
            {
                return NotFound("Cette article n'existe pas");
            }
            return View(article);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}