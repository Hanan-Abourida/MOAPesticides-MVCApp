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
    public class ToxicityOnBeesController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: ToxicityOnBees
        public ActionResult Index()
        {
            return View(db.ToxicityOnBees.ToList());
        }

        // GET: ToxicityOnBees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnBee toxicityOnBee = db.ToxicityOnBees.Find(id);
            if (toxicityOnBee == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnBee);
        }

        // GET: ToxicityOnBees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToxicityOnBees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToxicityBeePk,ToxicityAr")] ToxicityOnBee toxicityOnBee)
        {
            if (ModelState.IsValid)
            {
                db.ToxicityOnBees.Add(toxicityOnBee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toxicityOnBee);
        }

        // GET: ToxicityOnBees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnBee toxicityOnBee = db.ToxicityOnBees.Find(id);
            if (toxicityOnBee == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnBee);
        }

        // POST: ToxicityOnBees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToxicityBeePk,ToxicityAr")] ToxicityOnBee toxicityOnBee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toxicityOnBee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toxicityOnBee);
        }

        // GET: ToxicityOnBees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnBee toxicityOnBee = db.ToxicityOnBees.Find(id);
            if (toxicityOnBee == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnBee);
        }

        // POST: ToxicityOnBees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToxicityOnBee toxicityOnBee = db.ToxicityOnBees.Find(id);
            db.ToxicityOnBees.Remove(toxicityOnBee);
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
