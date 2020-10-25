using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.EntityModels
{
    public class TakmicenjeUcesnik
    {
        public int ID { get; set; }
        public int TakmicenjeID { get; set; }
        public Takmicenje Takmicenje { get; set; }
        public int OdjeljenjeStavkaID { get; set; }
        public OdjeljenjeStavka odjeljenjeStavka { get; set; }
        public int BrojBodova { get; set; }
        public bool isPristupio { get; set; }
    }
}
