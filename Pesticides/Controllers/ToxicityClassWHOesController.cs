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
    public class ToxicityClassWHOesController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: ToxicityClassWHOes
        public ActionResult Index()
        {
            return View(db.ToxicityClassWHOes.ToList());
        }

        // GET: ToxicityClassWHOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityClassWHO toxicityClassWHO = db.ToxicityClassWHOes.Find(id);
            if (toxicityClassWHO == null)
            {
                return HttpNotFound();
            }
            return View(toxicityClassWHO);
        }

        // GET: ToxicityClassWHOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToxicityClassWHOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassWHOPK,ClassWHO")] ToxicityClassWHO toxicityClassWHO)
        {
            if (ModelState.IsValid)
            {
                db.ToxicityClassWHOes.Add(toxicityClassWHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toxicityClassWHO);
        }

        // GET: ToxicityClassWHOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityClassWHO toxicityClassWHO = db.ToxicityClassWHOes.Find(id);
            if (toxicityClassWHO == null)
            {
                return HttpNotFound();
            }
            return View(toxicityClassWHO);
        }

        // POST: ToxicityClassWHOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassWHOPK,ClassWHO")] ToxicityClassWHO toxicityClassWHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toxicityClassWHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toxicityClassWHO);
        }

        // GET: ToxicityClassWHOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToxicityClassWHO toxicityClassWHO = db.ToxicityClassWHOes.Find(id);
            if (toxicityClassWHO == null)
            {
                return HttpNotFound();
            }
            return View(toxicityClassWHO);
        }

        // POST: ToxicityClassWHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToxicityClassWHO toxicityClassWHO = db.ToxicityClassWHOes.Find(id);
            db.ToxicityClassWHOes.Remove(toxicityClassWHO);
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
