using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication.Models
{
    public class LigneCommande
    {

        public int id { get; set; }
        public int quantite { get; set; }
        public movies movies { get; set; }
        public ApplicationUser user { get; set; }
        public float Montant()
        {
            return quantite * movies.prix;
        }
    }
}