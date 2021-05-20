using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaApplication.Models;
using Microsoft.AspNet.Identity;

namespace CinemaApplication.Controllers
{
    public class LigneCommandesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LigneCommandes
        public ActionResult Index()
        {
            List<LigneCommande> ligneCommandes = db.ligneCommandes.Include(l => l.movies).Include(m=>m.user).ToList();
            List<LigneCommande> ligneCommandesResult = new List<LigneCommande>();
            var userId = User.Identity.GetUserId();
            foreach(var item in ligneCommandes)
            {
                if (item.user.Id == userId)
                {
                    ligneCommandesResult.Add(item);
                }
            }
            return View(ligneCommandesResult);
        }

        // GET: LigneCommandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.ligneCommandes.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LigneCommandes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,quantite")] LigneCommande ligneCommande)
        {
            if (ModelState.IsValid)
            {
                db.ligneCommandes.Add(ligneCommande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ligneCommande);
        }

        // GET: LigneCommandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.ligneCommandes.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // POST: LigneCommandes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,quantite")] LigneCommande ligneCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligneCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.ligneCommandes.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // POST: LigneCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LigneCommande ligneCommande = db.ligneCommandes.Find(id);
            db.ligneCommandes.Remove(ligneCommande);
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
        public ActionResult payer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.ligneCommandes.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }
    }
}
