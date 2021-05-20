using CinemaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApplication.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult AdminLayout()
        {
            var users = db.Users.Count();
            var movies = db.movies.Count();
            var commande = db.ligneCommandes.Count();
            var factures = db.factures.Count();
            var salle = db.salles.Count();
            ViewBag.users = users;
            ViewBag.movies = movies;
            ViewBag.commande = commande;
            ViewBag.factures = factures;
            ViewBag.salle = salle;
           
            return View();
        }
    }
}