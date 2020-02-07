using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMPAdmin.Models;
using PMPAdmin.ViewModels;

namespace PMPAdmin.Controllers
{
    public class NewsController : Controller
    {
        private PMPNewsDbContext _pmpNewsDbContext = new PMPNewsDbContext();

        // GET: News
        public ActionResult Index()
        {
            ViewBag.Message = "News Page";

            //Get all the active categories from database...
            var newsCategories = _pmpNewsDbContext.NewsCategories.Where(x => x.IsActive == true).ToList();

            //Generate a select list item for the news categories..
            var newsCategorySelectList = new List<SelectListItem>();

            //Generate a select list item for the news types...
            var newsTypesSelectList = new List<SelectListItem>();
            newsTypesSelectList.Add(new SelectListItem() {Text = "Text", Value = "Text"});
            newsTypesSelectList.Add(new SelectListItem() { Text = "Video", Value = "Video" });

            foreach (var item in newsCategories)
            {
                newsCategorySelectList.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                });
            }
            ManageNewsViewModel manageNewsViewModel = new ManageNewsViewModel()
            {
                News = _pmpNewsDbContext.News.ToList(),
                NewsCategoryList = newsCategorySelectList,
                NewsTypes = newsTypesSelectList
            };
            return View(manageNewsViewModel);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _pmpNewsDbContext.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Details,CategoryId,ImagePath,VideoPath,TimeCreated,TimeModified,Status,AddedById,Type,Trending,IsActive")] News news)
        {
            if (ModelState.IsValid)
            {
                _pmpNewsDbContext.News.Add(news);
                _pmpNewsDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _pmpNewsDbContext.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Details,CategoryId,ImagePath,VideoPath,TimeCreated,TimeModified,Status,AddedById,Type,Trending,IsActive")] News news)
        {
            if (ModelState.IsValid)
            {
                _pmpNewsDbContext.Entry(news).State = EntityState.Modified;
                _pmpNewsDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _pmpNewsDbContext.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _pmpNewsDbContext.News.Find(id);
            _pmpNewsDbContext.News.Remove(news);
            _pmpNewsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pmpNewsDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
