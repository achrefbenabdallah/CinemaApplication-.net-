using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication.Models
{
    public class Salle
    {
        public int id { get; set; }
        public string nom { get; set; }
        public int NbPlaces { get; set; }
        public IEnumerable<Salle> movies { get; set; }
    }
}