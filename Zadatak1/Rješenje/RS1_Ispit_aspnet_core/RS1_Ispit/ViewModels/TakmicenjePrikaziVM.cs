using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class TakmicenjePrikaziVM
    {
        public int SkolaID { get; set; }
        public int Razred { get; set; }
        public List<Red> Redovi { get; set; }
        public class Red
        {
            public int TakmicenjeID { get; set; }
            public string Skola { get; set; }
            public string Razred { get; set; }
            public string Predmet { get; set; }
            public string Datum { get; set; }
            public string NajboljiUcenik { get; set; }

        }
    }
}
