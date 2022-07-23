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
    public class ToxicityOnBirdsController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: ToxicityOnBirds
        public ActionResult Index()
        {
            return View(db.ToxicityOnBirds.ToList());
        }

        // GET: ToxicityOnBirds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnBird toxicityOnBird = db.ToxicityOnBirds.Find(id);
            if (toxicityOnBird == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnBird);
        }

        // GET: ToxicityOnBirds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToxicityOnBirds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToxicityBirdPk,ToxicityAr")] ToxicityOnBird toxicityOnBird)
        {
            if (ModelState.IsValid)
            {
                db.ToxicityOnBirds.Add(toxicityOnBird);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toxicityOnBird);
        }

        // GET: ToxicityOnBirds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnBird toxicityOnBird = db.ToxicityOnBirds.Find(id);
            if (toxicityOnBird == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnBird);
        }

        // POST: ToxicityOnBirds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToxicityBirdPk,ToxicityAr")] ToxicityOnBird toxicityOnBird)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toxicityOnBird).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toxicityOnBird);
        }

        // GET: ToxicityOnBirds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityOnBird toxicityOnBird = db.ToxicityOnBirds.Find(id);
            if (toxicityOnBird == null)
            {
                return HttpNotFound();
            }
            return View(toxicityOnBird);
        }

        // POST: ToxicityOnBirds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToxicityOnBird toxicityOnBird = db.ToxicityOnBirds.Find(id);
            db.ToxicityOnBirds.Remove(toxicityOnBird);
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
