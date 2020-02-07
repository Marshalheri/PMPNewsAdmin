using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PMPAdmin.Models;
using  PMPAdmin.ViewModels;

namespace PMPAdmin.Controllers
{
    [Authorize]
    public class NewsCategoryController : Controller
    {
        private  PMPNewsDbContext _pmpNewsDbContext = new PMPNewsDbContext();

        // GET: NewsCategory
        public ActionResult Index()
        {
            ViewBag.Message = "News Category Page";
            var users = _pmpNewsDbContext.AspNetUsers.ToList();

            var manageNewsCategoryViewModel = new ManageNewsCategoryViewModel
            {
                NewsCategory = _pmpNewsDbContext.NewsCategories.Where(x => x.IsActive == true).ToList()
            };

            return View(manageNewsCategoryViewModel);
        }

        // GET: NewsCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCategory = _pmpNewsDbContext.NewsCategories.Find(id);
            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // GET: NewsCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TimeCreated,AddedBy")] ManageNewsCategoryViewModel manageNewsCategoryViewModel)
        {
            if (!ModelState.IsValid) return Json(new {status = "Not Successful"}, JsonRequestBehavior.AllowGet);
            var newsCategory = new NewsCategory()
            {
                Name = manageNewsCategoryViewModel.Name,
                AddedBy = User.Identity.GetUserName(),
                TimeCreated = DateTime.UtcNow.AddHours(1),
                IsActive = true
            };

            _pmpNewsDbContext.NewsCategories.Add(newsCategory);
            _pmpNewsDbContext.SaveChanges();

            var updatedNewsCategory = _pmpNewsDbContext.NewsCategories.ToList().Select(x => new
            {
                x.Name,
                x.AddedBy,
                TimeCreated = string.Format(("{0:G}"), x.TimeCreated.Value)
                //TimeCreated = x.TimeCreated.Value.ToString("f")
            });

            return Json(new { status = "Successful", data = updatedNewsCategory }, JsonRequestBehavior.AllowGet);

        }

        // GET: NewsCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategory newsCategory = _pmpNewsDbContext.NewsCategories.Find(id);
            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // POST: NewsCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TimeCreated,AddedBy")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                _pmpNewsDbContext.Entry(newsCategory).State = EntityState.Modified;
                _pmpNewsDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsCategory);
        }

        // GET: NewsCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCategory = _pmpNewsDbContext.NewsCategories.Find(id);
            if (newsCategory == null)
            {
                return HttpNotFound();
            }

            var categoryToBeDeleted = new
            {
                categoryId = newsCategory.Id,
                Name = newsCategory.Name,
                AddedBy = newsCategory.AddedBy,
                TimeCreated = string.Format(("{0:G}"), newsCategory.TimeCreated)
            };
            return Json(new { status = "Successful", data = categoryToBeDeleted }, JsonRequestBehavior.AllowGet);
        }

        // POST: NewsCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var newsCategory = _pmpNewsDbContext.NewsCategories.Find(id);
            newsCategory.IsActive = false;
            //_pmpNewsDbContext.Entry(newsCategory).State = EntityState.Modified;
            //_pmpNewsDbContext.NewsCategories.Remove(newsCategory);
            _pmpNewsDbContext.SaveChanges();
            return Json(new { status = "Successful"}, JsonRequestBehavior.AllowGet);
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
