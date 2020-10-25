using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class TakmicenjeOdaberiVM
    {
        public int SkolaID { get; set; }
        public string Skola { get; set; }
        public string Razred { get; set; }
        public List<Red> redovi { get; set; }
        public class Red
        {
            public int TakmicenjeID { get; set; }
            public string Predmet { get; set; }
            public int Razred { get; set; }
            public string Datum { get; set; }
            public int BrojUcenikaKojiNisuPristupili { get; set; }
            public string Najbolji { get; set; }
        }
    }
}
