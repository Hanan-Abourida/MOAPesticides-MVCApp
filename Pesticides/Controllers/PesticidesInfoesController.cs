using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using Pesticides.Models;

namespace Pesticides.Controllers
{
    [Authorize]
    public class PesticidesInfoesController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: PesticidesInfoes
        public ActionResult Index()
        {
            var pesticidesInfoes = db.PesticidesInfoes.Include(p => p.ActiveIngredient).Include(p => p.Crop).Include(p => p.Formulation).Include(p => p.Pest).Include(p => p.ToxicityClassWHO).Include(p => p.PesticideType).Include(p => p.ToxicityOnFish).Include(p => p.ToxicityOnBee).Include(p => p.ToxicityOnBird);
            return View(pesticidesInfoes.ToList());
        }

        // GET: PesticidesInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticidesInfo pesticidesInfo = db.PesticidesInfoes.Find(id);
            if (pesticidesInfo == null)
            {
                return HttpNotFound();
            }
            return View(pesticidesInfo);
        }

        // GET: PesticidesInfoes/Create
        public ActionResult Create()
        {
            ViewBag.fkActiveIngredient = new SelectList(db.ActiveIngredients, "ActiveIngredientPk", "IngredientAr");
            ViewBag.fkCrop = new SelectList(db.Crops, "CropPk", "CropNameAr");
            ViewBag.fkFormulation = new SelectList(db.Formulations, "FormulationPk", "FormulationDescAr");
            ViewBag.fkPest = new SelectList(db.Pests, "PestPk", "PestNameAr");
            ViewBag.fkClassWHO = new SelectList(db.ToxicityClassWHOes, "ClassWHOPK", "ClassWHO");
            ViewBag.fkPesticideType = new SelectList(db.PesticideTypes, "PesticideTypePk", "PesticideTypeAR");
            ViewBag.fkToxicityFish = new SelectList(db.ToxicityOnFish, "ToxicityFishPk", "ToxicityAr");
            ViewBag.fkToxicityBees = new SelectList(db.ToxicityOnBees, "ToxicityBeePk", "ToxicityAr");
            ViewBag.fkToxicityBirds = new SelectList(db.ToxicityOnBirds, "ToxicityBirdPk", "ToxicityAr");
            return View();
        }

        // POST: PesticidesInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PesticidesInfoPk,fkPesticideType,fkActiveIngredient,fkFormulation,fkToxicityFish,fkToxicityBees,fkToxicityBirds,fkClassWHO,ModeOfAction,fkCrop,fkPest,RatePerLiters,RatePerHectar,PreharvestInterval,ModeOfUse")] PesticidesInfo pesticidesInfo)
        {
            if (ModelState.IsValid)
            {
                db.PesticidesInfoes.Add(pesticidesInfo);
                db.SaveChanges();
                saveLastModifiedDate();
                return RedirectToAction("Index");
            }

            ViewBag.fkActiveIngredient = new SelectList(db.ActiveIngredients, "ActiveIngredientPk", "IngredientAr", pesticidesInfo.fkActiveIngredient);
            ViewBag.fkCrop = new SelectList(db.Crops, "CropPk", "CropNameAr", pesticidesInfo.fkCrop);
            ViewBag.fkFormulation = new SelectList(db.Formulations, "FormulationPk", "FormulationDescAr", pesticidesInfo.fkFormulation);
            ViewBag.fkPest = new SelectList(db.Pests, "PestPk", "PestNameAr", pesticidesInfo.fkPest);
            ViewBag.fkClassWHO = new SelectList(db.ToxicityClassWHOes, "ClassWHOPK", "ClassWHO", pesticidesInfo.fkClassWHO);
            ViewBag.fkPesticideType = new SelectList(db.PesticideTypes, "PesticideTypePk", "PesticideTypeAR", pesticidesInfo.fkPesticideType);
            ViewBag.fkToxicityFish = new SelectList(db.ToxicityOnFish, "ToxicityFishPk", "ToxicityAr", pesticidesInfo.fkToxicityFish);
            ViewBag.fkToxicityBees = new SelectList(db.ToxicityOnBees, "ToxicityBeePk", "ToxicityAr", pesticidesInfo.fkToxicityBees);
            ViewBag.fkToxicityBirds = new SelectList(db.ToxicityOnBirds, "ToxicityBirdPk", "ToxicityAr", pesticidesInfo.fkToxicityBirds);
            return View(pesticidesInfo);
        }

        // GET: PesticidesInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticidesInfo pesticidesInfo = db.PesticidesInfoes.Find(id);
            if (pesticidesInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkActiveIngredient = new SelectList(db.ActiveIngredients, "ActiveIngredientPk", "IngredientAr", pesticidesInfo.fkActiveIngredient);
            ViewBag.fkCrop = new SelectList(db.Crops, "CropPk", "CropNameAr", pesticidesInfo.fkCrop);
            ViewBag.fkFormulation = new SelectList(db.Formulations, "FormulationPk", "FormulationDescAr", pesticidesInfo.fkFormulation);
            ViewBag.fkPest = new SelectList(db.Pests, "PestPk", "PestNameAr", pesticidesInfo.fkPest);
            ViewBag.fkClassWHO = new SelectList(db.ToxicityClassWHOes, "ClassWHOPK", "ClassWHO", pesticidesInfo.fkClassWHO);
            ViewBag.fkPesticideType = new SelectList(db.PesticideTypes, "PesticideTypePk", "PesticideTypeAR", pesticidesInfo.fkPesticideType);
            ViewBag.fkToxicityFish = new SelectList(db.ToxicityOnFish, "ToxicityFishPk", "ToxicityAr", pesticidesInfo.fkToxicityFish);
            ViewBag.fkToxicityBees = new SelectList(db.ToxicityOnBees, "ToxicityBeePk", "ToxicityAr", pesticidesInfo.fkToxicityBees);
            ViewBag.fkToxicityBirds = new SelectList(db.ToxicityOnBirds, "ToxicityBirdPk", "ToxicityAr", pesticidesInfo.fkToxicityBirds);
            return View(pesticidesInfo);
        }

        // POST: PesticidesInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PesticidesInfoPk,fkPesticideType,fkActiveIngredient,fkFormulation,fkToxicityFish,fkToxicityBees,fkToxicityBirds,fkClassWHO,ModeOfAction,fkCrop,fkPest,RatePerLiters,RatePerHectar,PreharvestInterval,ModeOfUse")] PesticidesInfo pesticidesInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesticidesInfo).State = EntityState.Modified;
                db.SaveChanges();
                saveLastModifiedDate();
                return RedirectToAction("Index");
            }
            ViewBag.fkActiveIngredient = new SelectList(db.ActiveIngredients, "ActiveIngredientPk", "IngredientAr", pesticidesInfo.fkActiveIngredient);
            ViewBag.fkCrop = new SelectList(db.Crops, "CropPk", "CropNameAr", pesticidesInfo.fkCrop);
            ViewBag.fkFormulation = new SelectList(db.Formulations, "FormulationPk", "FormulationDescAr", pesticidesInfo.fkFormulation);
            ViewBag.fkPest = new SelectList(db.Pests, "PestPk", "PestNameAr", pesticidesInfo.fkPest);
            ViewBag.fkClassWHO = new SelectList(db.ToxicityClassWHOes, "ClassWHOPK", "ClassWHO", pesticidesInfo.fkClassWHO);
            ViewBag.fkPesticideType = new SelectList(db.PesticideTypes, "PesticideTypePk", "PesticideTypeAR", pesticidesInfo.fkPesticideType);
            ViewBag.fkToxicityFish = new SelectList(db.ToxicityOnFish, "ToxicityFishPk", "ToxicityAr", pesticidesInfo.fkToxicityFish);
            ViewBag.fkToxicityBees = new SelectList(db.ToxicityOnBees, "ToxicityBeePk", "ToxicityAr", pesticidesInfo.fkToxicityBees);
            ViewBag.fkToxicityBirds = new SelectList(db.ToxicityOnBirds, "ToxicityBirdPk", "ToxicityAr", pesticidesInfo.fkToxicityBirds);
            return View(pesticidesInfo);
        }

        // GET: PesticidesInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticidesInfo pesticidesInfo = db.PesticidesInfoes.Find(id);
            if (pesticidesInfo == null)
            {
                return HttpNotFound();
            }
            return View(pesticidesInfo);
        }

        // POST: PesticidesInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PesticidesInfo pesticidesInfo = db.PesticidesInfoes.Find(id);
            db.PesticidesInfoes.Remove(pesticidesInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: PesticidesInfoes/Delete/5
        [HttpPost, ActionName("DeleteMultiple")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteMultiple(FormCollection formCollection)
        {
            string[] ids = formCollection["pesticideInfoID"].Split(new char[] { ',' });
            foreach(string id in ids)
            {
                var pesticideInfo = this.db.PesticidesInfoes.Find(int.Parse(id));
                this.db.PesticidesInfoes.Remove(pesticideInfo);
                this.db.SaveChanges();
            }
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

        private void saveLastModifiedDate()
        {
            string _date = DateTime.Now.ToShortDateString();
            string _path = Server.MapPath("~/App_Data/DataFile.txt");
            System.IO.File.WriteAllText(_path, _date);
        }

        // GET: PesticidesInfoes/Edit/5
        public ActionResult AddToPesticide(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesticidesInfo pesticidesInfo = db.PesticidesInfoes.Find(id);
            if (pesticidesInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkActiveIngredient = new SelectList(db.ActiveIngredients, "ActiveIngredientPk", "IngredientAr", pesticidesInfo.fkActiveIngredient);
            ViewBag.fkCrop = new SelectList(db.Crops, "CropPk", "CropNameAr", pesticidesInfo.fkCrop);
            ViewBag.fkFormulation = new SelectList(db.Formulations, "FormulationPk", "FormulationDescAr", pesticidesInfo.fkFormulation);
            ViewBag.fkPest = new SelectList(db.Pests, "PestPk", "PestNameAr", pesticidesInfo.fkPest);
            ViewBag.fkClassWHO = new SelectList(db.ToxicityClassWHOes, "ClassWHOPK", "ClassWHO", pesticidesInfo.fkClassWHO);
            ViewBag.fkPesticideType = new SelectList(db.PesticideTypes, "PesticideTypePk", "PesticideTypeAR", pesticidesInfo.fkPesticideType);
            ViewBag.fkToxicityFish = new SelectList(db.ToxicityOnFish, "ToxicityFishPk", "ToxicityAr", pesticidesInfo.fkToxicityFish);
            ViewBag.fkToxicityBees = new SelectList(db.ToxicityOnBees, "ToxicityBeePk", "ToxicityAr", pesticidesInfo.fkToxicityBees);
            ViewBag.fkToxicityBirds = new SelectList(db.ToxicityOnBirds, "ToxicityBirdPk", "ToxicityAr", pesticidesInfo.fkToxicityBirds);
            return View(pesticidesInfo);
        }

        // POST: PesticidesInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToPesticide([Bind(Include = "PesticidesInfoPk,fkPesticideType,fkActiveIngredient,fkFormulation,fkToxicityFish,fkToxicityBees,fkToxicityBirds,fkClassWHO,ModeOfAction,fkCrop,fkPest,RatePerLiters,RatePerHectar,PreharvestInterval,ModeOfUse")] PesticidesInfo pesticidesInfo)
        {
            if (ModelState.IsValid)
            {
                db.PesticidesInfoes.Add(pesticidesInfo);
                db.SaveChanges();
                saveLastModifiedDate();
                return RedirectToAction("Index");
            }
            ViewBag.fkActiveIngredient = new SelectList(db.ActiveIngredients, "ActiveIngredientPk", "IngredientAr", pesticidesInfo.fkActiveIngredient);
            ViewBag.fkCrop = new SelectList(db.Crops, "CropPk", "CropNameAr", pesticidesInfo.fkCrop);
            ViewBag.fkFormulation = new SelectList(db.Formulations, "FormulationPk", "FormulationDescAr", pesticidesInfo.fkFormulation);
            ViewBag.fkPest = new SelectList(db.Pests, "PestPk", "PestNameAr", pesticidesInfo.fkPest);
            ViewBag.fkClassWHO = new SelectList(db.ToxicityClassWHOes, "ClassWHOPK", "ClassWHO", pesticidesInfo.fkClassWHO);
            ViewBag.fkPesticideType = new SelectList(db.PesticideTypes, "PesticideTypePk", "PesticideTypeAR", pesticidesInfo.fkPesticideType);
            ViewBag.fkToxicityFish = new SelectList(db.ToxicityOnFish, "ToxicityFishPk", "ToxicityAr", pesticidesInfo.fkToxicityFish);
            ViewBag.fkToxicityBees = new SelectList(db.ToxicityOnBees, "ToxicityBeePk", "ToxicityAr", pesticidesInfo.fkToxicityBees);
            ViewBag.fkToxicityBirds = new SelectList(db.ToxicityOnBirds, "ToxicityBirdPk", "ToxicityAr", pesticidesInfo.fkToxicityBirds);
            return View(pesticidesInfo);
        }

        [AllowAnonymous]
        public ActionResult VisitMOASite()
        {
            return Redirect("http://www.agriculture.gov.lb");
        }
    }
}
