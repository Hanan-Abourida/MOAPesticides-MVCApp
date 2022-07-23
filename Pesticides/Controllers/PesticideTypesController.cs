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
    public class PesticideTypesController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: PesticideTypes
        public ActionResult Index()
        {
            return View(db.PesticideTypes.ToList());
        }

        // GET: PesticideTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticideType pesticideType = db.PesticideTypes.Find(id);
            if (pesticideType == null)
            {
                return HttpNotFound();
            }
            return View(pesticideType);
        }

        // GET: PesticideTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PesticideTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PesticideTypePk,PesticideTypeAR")] PesticideType pesticideType)
        {
            if (ModelState.IsValid)
            {
                db.PesticideTypes.Add(pesticideType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pesticideType);
        }

        // GET: PesticideTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticideType pesticideType = db.PesticideTypes.Find(id);
            if (pesticideType == null)
            {
                return HttpNotFound();
            }
            return View(pesticideType);
        }

        // POST: PesticideTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PesticideTypePk,PesticideTypeAR")] PesticideType pesticideType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesticideType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pesticideType);
        }

        // GET: PesticideTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticideType pesticideType = db.PesticideTypes.Find(id);
            if (pesticideType == null)
            {
                return HttpNotFound();
            }
            return View(pesticideType);
        }

        // POST: PesticideTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PesticideType pesticideType = db.PesticideTypes.Find(id);
            db.PesticideTypes.Remove(pesticideType);
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
