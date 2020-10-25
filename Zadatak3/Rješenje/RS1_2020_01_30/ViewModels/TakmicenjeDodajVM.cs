using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_2020_01_30.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class TakmicenjeDodajVM
    {
        public int SkolaID { get; set; }
        public string Skola { get; set; }
        public int PredmetID { get; set; }
        public List<SelectListItem> Predmeti { get; set; }
        public int Razred { get; set; }
        public List<SelectListItem> Razredi { get; set; }
        public DateTime Datum { get; set; }
    }
}
