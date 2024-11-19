using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioEntities2 context = new DbMyPortfolioEntities2();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.Where(x=>x.Status==true).ToList();
            return View(values);
        }

        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;

            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(values);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var degerler = context.SocialMedia.Find(socialMedia.SocialMediaId);
            degerler.Title = socialMedia.Title;
            degerler.Url = socialMedia.Url;
            degerler.Icon = socialMedia.Icon;
            degerler.Status= socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}