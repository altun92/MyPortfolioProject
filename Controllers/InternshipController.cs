using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class InternshipController : Controller
    {
        DbMyPortfolioEntities2 context = new DbMyPortfolioEntities2();
        public ActionResult InternshipList()
        {
            var values = context.Internship.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateInternship()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInternship(Internship ınternship)
        {
            context.Internship.Add(ınternship);
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }

        public ActionResult DeleteInternship(int id)
        {
            var values = context.Internship.Find(id);
            context.Internship.Remove(values);
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }
        [HttpGet]
        public ActionResult UpdateInternship(int id)
        {
            var value = context.Internship.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInternship(Internship ınternship)
        {
            var degerler = context.Internship.Find(ınternship.InternshipId);
            degerler.CompanyName = ınternship.CompanyName;
            degerler.StartDate = ınternship.StartDate;
            degerler.EndDate = ınternship.EndDate;
            degerler.Position = ınternship.Position;
            degerler.Description = ınternship.Description;
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }
    }
}