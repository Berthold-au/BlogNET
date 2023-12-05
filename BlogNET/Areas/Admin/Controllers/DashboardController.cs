using Blog.DataAccess.Class;
using Blog.DataAccess.Class.Interfaces;
using Blog.DataAccess.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogNET.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Blog.Models.Article> listArticles = _unitOfWork.article.GetAll().ToList();
            return View(listArticles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Blog.Models.Article article)
        {
            var articleExiste = _unitOfWork.article.Get(u => u.Title == article.Title);
            if(articleExiste != null)
            {
                ModelState.AddModelError("title", "Desole mais cette article existe deja.");
            }

            if (ModelState.IsValid)
            {
                article.CreatedAt = DateTime.Now;
                _unitOfWork.article.Add(article);
                _unitOfWork.Save();
                TempData["success"] = "L'article a bien ete ajouter.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound("Desoler mais cette article n'existe pas.");
            }
            Blog.Models.Article? article = _unitOfWork.article.Get(u => u.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog.Models.Article article)
        {
            if (ModelState.IsValid)
            {
                article.CreatedAt = DateTime.Now;
                _unitOfWork.article.Update(article);
                _unitOfWork.Save();
                TempData["success"] = "L'article a bien ete mis a jour.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound("Cette article n'existe pas.");
            }
            Blog.Models.Article? article = _unitOfWork.article.Get(u => u.Id == id);
            if(article == null)
            {
                return NotFound("Desoler mais cette article n'existe pas.");
            }
            _unitOfWork.article.Remove(article);
            _unitOfWork.Save();
            TempData["success"] = "L'article a bien ete supprimer.";
            return RedirectToAction("Index");
        }


    }
}
