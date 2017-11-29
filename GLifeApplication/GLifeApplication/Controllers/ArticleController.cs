using GLifeApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLifeApplication.ViewModels;
using GLifeApplication.Services;
using GLifeApplication.Models;

namespace GLifeApplication.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService articleService = new ArticleService();
        private AccountService accountService = new AccountService();

        // GET: Article
        [Authorize]
        public ActionResult Index(String Date)
        {
            ArticleView article = new ArticleView();
            if (!String.IsNullOrEmpty(Date))
            {
                DateTime convertDatetime = Convert.ToDateTime(Date);
                article.Date = new ForDateTime(convertDatetime);
            }
            else
            {
                article.Date = new ForDateTime();
            }

            article.ArticleList = articleService.GetArticleRecordList(article.Date);

            return View(article);
        }

        [Authorize]
        public ActionResult CreateArticle()
        {
            return PartialView();
        }


        [Authorize]
        [HttpPost]
        public ActionResult AddArticle([Bind(Include = "Content, CreateDate")]Article article, FormCollection form)
        {

            article.Username = User.Identity.Name;
            article.Watch = 1;
            articleService.Insert(article);

            // return JavaScript("location.reload(true)");
            return RedirectToAction("Index");
        }
    }
}