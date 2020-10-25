using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class TakmicenjeIndexVM
    {
        public int SkolaID { get; set; }
        public List<SelectListItem> Skole { get; set; }
        public int? Razred { get; set; }
        public List<SelectListItem> Razredi { get; set; }
    }
}
