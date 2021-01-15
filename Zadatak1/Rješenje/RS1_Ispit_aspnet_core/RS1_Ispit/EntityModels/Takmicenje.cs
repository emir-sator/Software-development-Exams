﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class Takmicenje
    {
        public int TakmicenjeID { get; set; }
        public int PredmetID { get; set; }
        public Predmet Predmet { get; set; }
        public int SkolaID { get; set; }
        public Skola Skola { get; set; }
        public DateTime Datum { get; set; }
        public bool IsZakljucano { get; set; }
    }
}
