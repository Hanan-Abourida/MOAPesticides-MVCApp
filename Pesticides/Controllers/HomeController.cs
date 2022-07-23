using Pesticides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pesticides.Controllers
{
    public class HomeController : Controller
    {

        private PesticidesDBEntities db = new PesticidesDBEntities();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Index()
        //{
        //    populateCombos();

        //    var pesticidesInfoes = db.SearchPesticides(null,null,null,null);
        //    return View(pesticidesInfoes.ToList());
        //}

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Search");
        }

        [Authorize]
        public ActionResult EditMainData()
        {
            return View();
        }

        private void populateCombos()
        {

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult VisitMOASite()
        {
            return Redirect("http://www.agriculture.gov.lb");
        }
    }
}