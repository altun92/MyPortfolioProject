using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public PartialViewResult PartialContactSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactDetail()
        {
            ViewBag.address = context.Profile.Select(x=>x.Adress).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x=>x.Description).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x=>x.Phone).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x=>x.Email).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialContactLocation()
        {
            return PartialView();
        }
    }
}