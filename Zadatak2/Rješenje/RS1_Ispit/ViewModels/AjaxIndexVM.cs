using RS1_Ispit_asp.net_core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxIndexVM
    {
        public int TakmicenjeID { get; set; }
        public bool Zakljucaj { get; set; }
        public List<Red> Redovi { get; set; }
        public class Red
        {
            public int TakmicenjeUcesnikID { get; set; }
            public string Odjelenje { get; set; }
            public int BrojUDnevniku { get; set; }
            public bool Pristupio { get; set; }
            public int? Bodovi { get; set; }
        }
    }
}
