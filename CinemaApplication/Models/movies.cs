using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication.Models
{
    public class movies
    {
        public int id { get; set; }
        public string nom { get; set; }
        public Boolean disponibilite { get; set; }
        public DateTime date { get; set; }
        public float prix { get; set; }
        public string pays { get; set; }
        public float duree { get; set; }
        public int underAge { get; set; }
        public int annee { get; set; }
        public int salleId { get; set; }
        public Salle salle { get; set; }
        


    }
}