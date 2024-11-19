using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioEntities2 context = new DbMyPortfolioEntities2();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonial.Find(id);
            context.Testimonial.Remove(values);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var degerler = context.Testimonial.Find(testimonial.TestimonialId);
            degerler.NameSurname = testimonial.NameSurname;
            degerler.City = testimonial.City;
            degerler.Image = testimonial.Image;
            degerler.Description = testimonial.Description;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}