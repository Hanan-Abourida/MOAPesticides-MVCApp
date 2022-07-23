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
    public class PestsController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: Pests
        public ActionResult Index()
        {
            return View(db.Pests.ToList());
        }

        // GET: Pests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pest pest = db.Pests.Find(id);
            if (pest == null)
            {
                return HttpNotFound();
            }
            return View(pest);
        }

        // GET: Pests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PestPk,PestNameAr")] Pest pest)
        {
            if (ModelState.IsValid)
            {
                db.Pests.Add(pest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pest);
        }

        // GET: Pests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pest pest = db.Pests.Find(id);
            if (pest == null)
            {
                return HttpNotFound();
            }
            return View(pest);
        }

        // POST: Pests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PestPk,PestNameAr")] Pest pest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pest);
        }

        // GET: Pests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pest pest = db.Pests.Find(id);
            if (pest == null)
            {
                return HttpNotFound();
            }
            return View(pest);
        }

        // POST: Pests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pest pest = db.Pests.Find(id);
            db.Pests.Remove(pest);
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
