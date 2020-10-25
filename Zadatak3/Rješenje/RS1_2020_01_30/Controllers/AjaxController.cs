using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.EntityModels;
using RS1_2020_01_30.ViewModels;

namespace RS1_2020_01_30.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MojContext db;
        public AjaxController(MojContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int Id)
        {
            var Takmicenje = db.Takmicenja.Find(Id);
            var model = new AjaxIndexVM
            {
                TakmicenjeId = Takmicenje.TakmicenjeID,
                Zakljucaj = Takmicenje.isZakljucano,
                Redovi = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == Id).Select(x => new AjaxIndexVM.Red
                {
                    Bodovi = x.BrojBodova,
                    BrojUDnevniku = x.odjeljenjeStavka.BrojUDnevniku,
                    Odjeljenje = x.odjeljenjeStavka.Odjeljenje.Oznaka,
                    Pristupio = x.isPristupio,
                    TakmicenjeUcesnikID = x.ID

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
            var Ucensik = db.TakmicenjeUcesnici.Where(i => i.ID == id).FirstOrDefault();
            var model = new AjaxUrediDodajVM
            {
                TakmicenjeID = Ucensik.TakmicenjeID,
                UcesnikID = id,
                Ucesnik = db.TakmicenjeUcesnici.Where(i => i.ID == id).Select(i => i.odjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault(),
                Bodovi = Ucensik.BrojBodova
            };

            return PartialView(model);
        }
        public IActionResult Snimi(AjaxUrediDodajVM input)
        {
            var TakmicenjeUcesnik = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == input.TakmicenjeID && i.ID == input.UcesnikID).FirstOrDefault();
            if (TakmicenjeUcesnik != null)
            {
                TakmicenjeUcesnik.BrojBodova = input.Bodovi < 0 ? 0 : input.Bodovi > 100 ? 100 : input.Bodovi;
                db.SaveChanges();
            }
            else if (input.UcesnikID != 0)
            {
                var noviUcesnik = new TakmicenjeUcesnik
                {
                    TakmicenjeID = input.TakmicenjeID,
                    BrojBodova = input.Bodovi < 0 ? 0 : input.Bodovi > 100 ? 100 : input.Bodovi,
                    isPristupio = true,
                    OdjeljenjeStavkaID = input.UcesnikID
                };
                db.Add(noviUcesnik);
                db.SaveChanges();
            }

            return Redirect("/Takmicenje/Rezultat/" + input.TakmicenjeID);
        }
        public IActionResult TogglePristupio(int id)
        {
            var ucesnika = db.TakmicenjeUcesnici.Where(i => i.ID == id).FirstOrDefault();
            ucesnika.isPristupio = !ucesnika.isPristupio;
            db.SaveChanges();

            return Redirect("/Takmicenje/Rezultat/" + ucesnika.TakmicenjeID);
        }
        public IActionResult UpdateBodovi(int id, int bodovi)
        {
            var TakmicenjeUcesnik = db.TakmicenjeUcesnici.Find(id);
            TakmicenjeUcesnik.BrojBodova = bodovi;
            db.SaveChanges();
            return Redirect("/Takmicenje/Rezultati/" + TakmicenjeUcesnik.TakmicenjeID);
        }
    }
}