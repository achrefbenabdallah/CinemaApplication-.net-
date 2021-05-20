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
    public class moviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: movies
        public ActionResult Index()
        {
            var nbPlace = 0;
            List<LigneCommande> ligneCommandes = db.ligneCommandes.ToList();
            List<movies> movies = db.movies.ToList();
            List<movies> listMovies = new List<movies>();
            foreach(var movie in movies){
                foreach (var item in ligneCommandes)
                {
                    if (item.movies.id == movie.id)
                    {
                        nbPlace += 1;
                    }
                }
                var salle = db.salles.Find(movie.salleId);
                if (salle.NbPlaces == nbPlace)
                {
                    movie.disponibilite = false;
                    db.Entry(movie).State = EntityState.Modified;
                    db.SaveChanges();
                    nbPlace = 0;
                }
                else
                    listMovies.Add(movie);
            }
            
            return View(listMovies);
        }

        // GET: movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movies movies = db.movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // GET: movies/Create
        public ActionResult Create()
        {
            ViewBag.salleId = new SelectList(db.salles, "id", "nom");
            return View();
        }

        // POST: movies/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,disponibilite,date,prix,pays,duree,underAge,annee,salleId")] movies movies)
        {
            if (ModelState.IsValid)
            {
                db.movies.Add(movies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.salleId = new SelectList(db.salles, "id", "nom", movies.salleId);
            return View(movies);
        }

        // GET: movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movies movies = db.movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            ViewBag.salleId = new SelectList(db.salles, "id", "nom", movies.salleId);
            return View(movies);
        }

        // POST: movies/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,disponibilite,date,prix,pays,duree,underAge,annee,salleId")] movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.salleId = new SelectList(db.salles, "id", "nom", movies.salleId);
            return View(movies);
        }

        // GET: movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movies movies = db.movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movies movies = db.movies.Find(id);
            db.movies.Remove(movies);
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

         public ActionResult add(int? id)
         {
             var user = User.Identity.GetUserId();
             var movie = db.movies.Find(id);
             LigneCommande ligneCommande = new LigneCommande();
             ligneCommande.user = db.Users.Find(user);
             ligneCommande.movies = db.movies.Find(id);
             ligneCommande.quantite = 1;
             db.ligneCommandes.Add(ligneCommande);
             db.SaveChanges();
             return RedirectToAction("Index");

         }
    }
}
