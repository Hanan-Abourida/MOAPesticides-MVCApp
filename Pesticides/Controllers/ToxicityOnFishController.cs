using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pesticides.Models;

namespace Pesticides.Controllers
{
    [Authorize]
    public class ToxicityOnFishController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: ToxicityOnFish
        public ActionResult Index()
        {
            return View(db.ToxicityOnFish.ToList());
        }

        // GET: ToxicityOnFish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnFish toxicityOnFish = db.ToxicityOnFish.Find(id);
            if (toxicityOnFish == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnFish);
        }

        // GET: ToxicityOnFish/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToxicityOnFish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToxicityFishPk,ToxicityAr")] ToxicityOnFish toxicityOnFish)
        {
            if (ModelState.IsValid)
            {
                db.ToxicityOnFish.Add(toxicityOnFish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toxicityOnFish);
        }

        // GET: ToxicityOnFish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnFish toxicityOnFish = db.ToxicityOnFish.Find(id);
            if (toxicityOnFish == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnFish);
        }

        // POST: ToxicityOnFish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToxicityFishPk,ToxicityAr")] ToxicityOnFish toxicityOnFish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toxicityOnFish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toxicityOnFish);
        }

        // GET: ToxicityOnFish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnFish toxicityOnFish = db.ToxicityOnFish.Find(id);
            if (toxicityOnFish == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnFish);
        }

        // POST: ToxicityOnFish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToxicityOnFish toxicityOnFish = db.ToxicityOnFish.Find(id);
            db.ToxicityOnFish.Remove(toxicityOnFish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public ActionResult VisitMOASite()
        {
            return Redirect("http://www.agriculture.gov.lb");
        }
    }
}
