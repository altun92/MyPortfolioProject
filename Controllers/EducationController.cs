using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;
using WebGrease.Css.Extensions;

namespace MyPortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult EducationList()
        {
            var values = context.Education.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var values = context.Education.Find(id);
            context.Education.Remove(values);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values = context.Education.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var degerler = context.Education.Find(education.EducationId);
            degerler.Title = education.Title;
            degerler.Description = education.Description;
            degerler.SubTitle = education.SubTitle;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

    }
}