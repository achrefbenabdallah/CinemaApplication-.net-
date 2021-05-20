using CinemaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var users = db.Users.Count();
            var produits = db.movies.Count();
            var commande = db.ligneCommandes.Count();
            //var factures = db.factures.Count();
            var gaint2020 = 20000;
            var gaint2021 = 22000;
            ViewBag.users = users;
            ViewBag.produits = produits;
            ViewBag.commande = commande;
            ViewBag.factures = 17000;
            ViewBag.gaitn2020 = gaint2020;
            ViewBag.gaint2021 = gaint2021;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}