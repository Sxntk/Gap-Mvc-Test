using SuperZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            ArticleModel article = new ArticleModel();
            article.Id = Guid.NewGuid();
            article.Name = "Zapatos";
            article.Price = 200000;
            article.GetAllArticles();

            return View(article);
        }

        public ActionResult Edit(Guid id)
        {
            ArticleModel article = new ArticleModel();
            article.Id = id;
            article.Name = "Zapatos";
            article.Price = 200000;
            return View(ArticleModel.GetArticle(id));
        }
    }
}