using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Controllers
{
    public class StatisticsController : Controller
    {
        DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
        public ActionResult Index()
        {
            ViewBag.totalMessageCount = db.Contact.Count();
            ViewBag.messageIsReadTrueCount = db.Contact.Where(x=>x.IsRead==true).Count();
            ViewBag.messageIsReadFalseCount = db.Contact.Where(x => x.IsRead == false).Count();
            ViewBag.skillCount = db.Skill.Count();
            ViewBag.skillRateSum = db.Skill.Sum(x=>x.Rate);
            ViewBag.skillRateAvg = db.Skill.Average(x=>x.Rate);

            var maxRate = db.Skill.Max(x=>x.Rate);
            ViewBag.maxRateSkillName = db.Skill.Where(x => x.Rate == maxRate).Select(y => y.SkillName).FirstOrDefault();

            ViewBag.getMessageCountBySubjectReferances = db.Contact.Where(x => x.Subject == "Referans").Count();

            ViewBag.getMessageCountByEmailContainHAndIsReadTrue = db.Contact.Where(x => x.IsRead == true && x.Email.Contains("h")).Count();

            ViewBag.getSkillNameByRate90 = db.Skill.Where(x=>x.Rate==90).Select(y => y.SkillName).FirstOrDefault();
            return View();

        }
    }
}