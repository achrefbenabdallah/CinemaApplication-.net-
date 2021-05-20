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
    public class facturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: factures
        public ActionResult Index()
        {
            List<factures> factures = db.factures.Include(f => f.user).ToList();
            var userId = User.Identity.GetUserId();
            List<factures> facturesUser = new List<factures>();
            foreach (var item in factures)
            {
                if (item.user != null && item.user.Id.Equals(userId))
                {
                    facturesUser.Add(item);
                }
            }
            return View(facturesUser);
           
        }

        // GET: factures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factures factures = db.factures.Find(id);
            if (factures == null)
            {
                return HttpNotFound();
            }
            return View(factures);
        }

        // GET: factures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: factures/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,somme")] factures factures)
        {
            if (ModelState.IsValid)
            {
                db.factures.Add(factures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factures);
        }

        // GET: factures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factures factures = db.factures.Find(id);
            if (factures == null)
            {
                return HttpNotFound();
            }
            return View(factures);
        }

        // POST: factures/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,somme")] factures factures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factures);
        }

        // GET: factures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factures factures = db.factures.Find(id);
            if (factures == null)
            {
                return HttpNotFound();
            }
            return View(factures);
        }

        // POST: factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factures factures = db.factures.Find(id);
            db.factures.Remove(factures);
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
        public ActionResult calculFacture()
        {
            factures facture = new factures();
            float somme = 0;
            var userId = User.Identity.GetUserId();
            List<LigneCommande> ligneCommandes = db.ligneCommandes.Include(l => l.movies).Include(l => l.user).ToList();
            List<LigneCommande> ligneCommandesUser = new List<LigneCommande>();
            foreach (var item in ligneCommandes)
            {
                if (item.user != null && item.user.Id.Equals(userId))
                {
                    ligneCommandesUser.Add(item);
                }
                else
                {



                }
            }
            if (userId != null)
            {

                facture.date = DateTime.Now;
                facture.user = db.Users.Find(userId);
                foreach (var item in ligneCommandesUser)
                {
                    somme += item.Montant() + somme;
                }
                facture.somme = somme;
                db.factures.Add(facture);
                db.SaveChanges();
            }



            return RedirectToAction("Index");
        }
        public ActionResult Pay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factures facture = db.factures.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            factures fact = db.factures.Find(id);
            db.factures.Remove(fact);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
