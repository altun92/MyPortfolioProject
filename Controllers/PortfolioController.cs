using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class PortfolioController : Controller
    {
        DbMyPortfolioEntities2 context = new DbMyPortfolioEntities2();
        public ActionResult PortfolioList()
        {
            var values = context.Portfolio.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            context.Portfolio.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public ActionResult DeletePortfolio(int id)
        {
            var values = context.Portfolio.Find(id);
            context.Portfolio.Remove(values);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
        [HttpGet]
        public ActionResult UpdatePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var degerler = context.Portfolio.Find(portfolio.PortfolioId);
            degerler.Title = portfolio.Title;
            degerler.SubTitle = portfolio.SubTitle;
            degerler.Image = portfolio.Image;
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}