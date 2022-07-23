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
    public class FormulationsController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: Formulations
        public ActionResult Index()
        {
            return View(db.Formulations.ToList());
        }

        // GET: Formulations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulation formulation = db.Formulations.Find(id);
            if (formulation == null)
            {
                return HttpNotFound();
            }
            return View(formulation);
        }

        // GET: Formulations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formulations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormulationPk,FormulationDescAr")] Formulation formulation)
        {
            if (ModelState.IsValid)
            {
                db.Formulations.Add(formulation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formulation);
        }

        // GET: Formulations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulation formulation = db.Formulations.Find(id);
            if (formulation == null)
            {
                return HttpNotFound();
            }
            return View(formulation);
        }

        // POST: Formulations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormulationPk,FormulationDescAr")] Formulation formulation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formulation);
        }

        // GET: Formulations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulation formulation = db.Formulations.Find(id);
            if (formulation == null)
            {
                return HttpNotFound();
            }
            return View(formulation);
        }

        // POST: Formulations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formulation formulation = db.Formulations.Find(id);
            db.Formulations.Remove(formulation);
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
