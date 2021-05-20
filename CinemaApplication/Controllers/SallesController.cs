using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaApplication.Models;

namespace CinemaApplication.Controllers
{
    public class SallesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Salles
        public ActionResult Index()
        {
            return View(db.salles.ToList());
        }

        // GET: Salles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // GET: Salles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,NbPlaces")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                db.salles.Add(salle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salle);
        }

        // GET: Salles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // POST: Salles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,NbPlaces")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salle);
        }

        // GET: Salles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salle salle = db.salles.Find(id);
            db.salles.Remove(salle);
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
    }
}
