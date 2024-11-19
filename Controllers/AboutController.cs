using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioEntities2 context = new DbMyPortfolioEntities2();
        public ActionResult AboutList()
        {
            var values = context.About.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.About.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about) 
        {
            var degerler = context.About.Find(about.AboutId);
            degerler.Title = about.Title;
            degerler.Description = about.Description;
            degerler.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}