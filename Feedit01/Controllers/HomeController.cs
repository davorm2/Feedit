using Feedit01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Feedit01.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.VoteSortParam = string.IsNullOrEmpty(sortOrder) ? "vote" : "";
            ViewBag.HeadlineSortParam = sortOrder == "headline" ? "headline_desc" : "headline";
            ViewBag.AuthorSortParam = sortOrder == "author" ? "author_desc" : "author";
                       
            IQueryable<Article> articleSort = ArticleSort(currentFilter, searchString);

            switch (sortOrder)
            {
                case "headline":
                    articleSort = articleSort.OrderBy(a => a.Headline);
                    break;
                case "headline_desc":
                    articleSort = articleSort.OrderByDescending(a => a.Headline);
                    break;
                case "author":
                    articleSort = articleSort.OrderBy(a => a.Author);
                    break;
                case "author_desc":
                    articleSort = articleSort.OrderByDescending(a => a.Author);
                    break;
                case "vote":
                    articleSort = articleSort.OrderBy(a => a.Votes);
                    break;
                default:
                    articleSort = articleSort.OrderByDescending(a => a.Votes);
                    break;
            }

            return View(articleSort.ToList());
        }
        
        [Authorize]
        public ActionResult Create()
        {

            ViewBag.DateNow = DateTime.Now.ToString();
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.UserName = User.Identity.GetUserName();

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Article newArticle)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(newArticle);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult VoteUp(int id)
        {
            Article article = db.Articles.Find(id);
            article.Votes += 1;
            voteState(article, true);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult VoteDown(int id)
        {
            Article article = db.Articles.Find(id);
            article.Votes -= 1;
            voteState(article, false);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private static void voteState(Article article, bool upVote)
        {
            if (article.voteState == 0)
            {
                if (upVote)
                    article.voteState = 1;
                else
                    article.voteState = 2;
            }
            else
            {
                article.voteState = 0;
            }
        }

        private IQueryable<Article> ArticleSort(string currentFilter, string searchString)
        {
            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var articleSort = from a in db.Articles
                              select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                articleSort = articleSort.Where(a => a.Headline.Contains(searchString));
            }

            return articleSort;
        }
    }
}