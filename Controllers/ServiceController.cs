using MyPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioEntities2 context = new DbMyPortfolioEntities2();
        public ActionResult ServiceList()
        {
            var values = context.Service.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var values = context.Service.Find(id);
            context.Service.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Service.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var degerler = context.Service.Find(service.ServiceId);
            degerler.Title = service.Title;
            degerler.Icon = service.Icon;
            degerler.Description = service.Description;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}