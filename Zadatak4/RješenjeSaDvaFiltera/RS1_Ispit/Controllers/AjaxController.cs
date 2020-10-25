using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxController : Controller
    {

        private readonly MojContext db;

        public AjaxController(MojContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int id)
        {
            var Takmicenje = db.Takmicenja.Find(id);
            var model = new AjaxIndexVM
            {
                TakmicenjeID = Takmicenje.TakmicenjeID,
                Zakljucaj = Takmicenje.isZakljucano,
                Redovi = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == id).Select(x => new AjaxIndexVM.Red
                {
                    Bodovi = x.bodovi,
                    BrojUDnevniku = x.OdjeljenjeStavka.BrojUDnevniku,
                    Odjelenje = x.OdjeljenjeStavka.Odjeljenje.Oznaka,
                    Pristupio = x.isPristupio,
                    TakmicenjeUcesnikID = x.TakmicenjeUcesnikID
                }).ToList()
            };

            return View(model);
        }
        public IActionResult Dodaj(int id)
        {
            var model = new AjaxUrediDodajVM
            {
                TakmicenjeID = id,
                Ucesnici = db.Ucenik.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.ImePrezime
                }).ToList()
            };

            return PartialView(model);
        }
        public IActionResult Uredi(int id)
        {
            var Ucensik = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeUcesnikID == id).FirstOrDefault();
            var model = new AjaxUrediDodajVM
            {
                TakmicenjeID = Ucensik.TakmicenjeID,
                UcesnikID = id,
                Ucesnik = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeUcesnikID == id).Select(i => i.OdjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault(),
                Bodovi = Ucensik.bodovi
            };

            return PartialView(model);
        }
        public IActionResult Snimi(AjaxUrediDodajVM input)
        {
            var TakmicenjeUcesnik = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == input.TakmicenjeID && i.TakmicenjeUcesnikID == input.UcesnikID).FirstOrDefault();
            if (TakmicenjeUcesnik != null)
            {
                TakmicenjeUcesnik.bodovi = input.Bodovi < 0 ? 0 : input.Bodovi > 100 ? 100 : input.Bodovi;
                db.SaveChanges();
            }
            else
            {
                var noviUcesnik = new TakmicenjeUcesnik
                {
                    TakmicenjeID = input.TakmicenjeID,
                    bodovi = input.Bodovi < 0 ? 0 : input.Bodovi > 100 ? 100 : input.Bodovi,
                    isPristupio = true,
                    OdjeljenjeStavkaID = input.UcesnikID
                };
                db.Add(noviUcesnik);
                db.SaveChanges();
            }

            return Redirect("/Takmicenje/Rezultati/" + input.TakmicenjeID);
        }
        public IActionResult TogglePristupio(int id)
        {
            var ucesnika = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeUcesnikID == id).FirstOrDefault();
            ucesnika.isPristupio = !ucesnika.isPristupio;
            db.SaveChanges();

            return Redirect("/Takmicenje/Rezultati/" + ucesnika.TakmicenjeID);
        }

        public IActionResult UpdateBodovi(int id, int bodovi)
        {
            var TakmicenjeUcesnik = db.TakmicenjeUcesnici.Find(id);
            TakmicenjeUcesnik.bodovi = bodovi;
            db.SaveChanges();
            return Redirect("/Takmicenje/Rezultati/" + TakmicenjeUcesnik.TakmicenjeID);
        }
    }
}