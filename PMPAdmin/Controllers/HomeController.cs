using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PMPAdmin.Models;
using PMPAdmin.ViewModels;

namespace PMPAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PMPNewsDbContext _pmpNewsDbContext = new PMPNewsDbContext();

        public ActionResult Index()
        {
            var users = new ManageNewsCategoryViewModel()
            {
                AspNetUser = _pmpNewsDbContext.AspNetUsers.ToList(),
                News = _pmpNewsDbContext.News.ToList(),
                NewsCategory = _pmpNewsDbContext.NewsCategories.ToList()

            };
            return View(users);
        }

        public ActionResult ManageAdvert()
        {
            ViewBag.Message = "Welcome to the advert page.";

            return View();
        }

        public ActionResult ManageNews()
        {
            ViewBag.Message = "Welcome to the news page.";

            return View();
        }

        public ActionResult ManageAdmin()
        {
            ViewBag.Message = "Welcome to the admin page.";

            return View();
        }

        public ActionResult ManageNewsCategory()
        {
            ViewBag.Message = "News Category Page";
            ManageNewsCategoryViewModel manageNewsCategoryViewModel = new ManageNewsCategoryViewModel()
            {
                NewsCategory = _pmpNewsDbContext.NewsCategories.ToList()
            };

            return View(manageNewsCategoryViewModel);
        }

        [HttpPost]
        public ActionResult ManageNewsCategory(string categoryName)
        {
            ViewBag.Message = "News Category Page";

            if (!string.IsNullOrEmpty(categoryName))
            {
                NewsCategory newsCategory = new NewsCategory()
                {
                    Name = categoryName,
                    AddedBy = "superadmin@pmpnews.com",
                    TimeCreated = DateTime.UtcNow.AddHours(1)
                };

                _pmpNewsDbContext.NewsCategories.Add(newsCategory);
                _pmpNewsDbContext.SaveChanges();
                var getAllCategory = _pmpNewsDbContext.NewsCategories.ToList().Select(x=> new
                {
                    x.Name,
                    x.AddedBy,
                    TimeCreated = x.TimeCreated.Value.ToString("f")
                });
                return Json(new { status = "Successful" , data = getAllCategory }, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "Not Successful"}, JsonRequestBehavior.AllowGet);
        }
    }
}