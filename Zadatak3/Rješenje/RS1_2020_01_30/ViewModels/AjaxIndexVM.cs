using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class AjaxIndexVM
    {
       
        public int TakmicenjeId { get; set; }
        public bool Zakljucaj { get; set; }
        public List<Red> Redovi { get; set; }
        public class Red
        {
            public int TakmicenjeUcesnikID { get; set; }
            public string Odjeljenje { get; set; }
            public int BrojUDnevniku { get; set; }
            public bool Pristupio { get; set; }
            public int? Bodovi { get; set; }
        }
    }
}
