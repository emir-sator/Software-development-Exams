using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_2020_01_30.ViewModels;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.EntityModels;

namespace RS1_2020_01_30.Controllers
{
    public class TakmicenjeController : Controller
    {
        private readonly MojContext db;

        public TakmicenjeController(MojContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {

            var Razredi = new List<string> { "", "1", "2", "3", "4" };
            var model = new TakmicenjeIndexVM
            {
                Skole = db.Skola.Select(i => new SelectListItem
                {
                    Text = i.Naziv,
                    Value = i.Id.ToString()
                })
                .OrderBy(i => i.Text)
                .ToList(),


                Razredi = Razredi.Select(i =>
                {
                    return new SelectListItem
                    {
                        Text = i,
                        Value = i,
                        Selected = false
                    };
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Odaberi(TakmicenjeIndexVM VM)
        {
            var Skola = db.Skola.Find(VM.SkolaID);
            TakmicenjeOdaberiVM model;
            if (VM.Razred == null)
            {
                model = new TakmicenjeOdaberiVM
                {
                    SkolaID = Skola.Id,
                    Skola = Skola.Naziv,
                    Razred = "Razred nije odabran",
                    redovi = db.Takmicenja.Where(i => i.SkolaID == VM.SkolaID).Select(t => new TakmicenjeOdaberiVM.Red
                    {
                        TakmicenjeID = t.TakmicenjeID,
                        Predmet = t.Predmet.Naziv,
                        Razred = t.Razred,
                        Datum = t.Datum.ToString("dd/MM/yyyy"),
                        BrojUcenikaKojiNisuPristupili = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == t.TakmicenjeID && i.isPristupio == false).Count(),
                        Najbolji = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == t.TakmicenjeID).OrderByDescending(i => i.BrojBodova)
                              .Select(i => i.Takmicenje.Skola.Naziv + " | " + i.odjeljenjeStavka.Odjeljenje.Oznaka + " | " + i.odjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()


                    }).ToList()
                };
            }
            else
            {
                model = new TakmicenjeOdaberiVM
                {
                    SkolaID = Skola.Id,
                    Skola = Skola.Naziv,
                    Razred = VM.Razred.ToString(),
                    redovi = db.Takmicenja.Where(i => i.SkolaID == VM.SkolaID && i.Razred == VM.Razred).Select(t => new TakmicenjeOdaberiVM.Red
                    {
                        TakmicenjeID = t.TakmicenjeID,
                        Predmet = t.Predmet.Naziv,
                        Razred = t.Razred,
                        Datum = t.Datum.ToString("dd/MM/yyyy"),
                        BrojUcenikaKojiNisuPristupili = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == t.TakmicenjeID && i.isPristupio == false).Count(),
                        Najbolji = db.TakmicenjeUcesnici.Where(i => i.TakmicenjeID == t.TakmicenjeID).OrderByDescending(i => i.BrojBodova)
                                  .Select(i => i.Takmicenje.Skola.Naziv + " | " + i.odjeljenjeStavka.Odjeljenje.Oznaka + " | " + i.odjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()


                    }).ToList()
                };
            }

            return View(model);
        }

        public IActionResult Dodaj(int Id)
        {
            var skola = db.Skola.Find(Id);
            var razredi = new List<int> { 1, 2, 3, 4, };
            var model = new TakmicenjeDodajVM
            {
                SkolaID = Id,
                Skola = skola.Naziv,
                Predmeti = db.Predmet.GroupBy(i=>i.Naziv).Select(i=>i.FirstOrDefault()).Select(i => new SelectListItem
                {
                    Text = i.Naziv,
                    Value = i.Id.ToString()
                }).ToList(),
                Razredi = razredi.Select(i =>
                {
                    return new SelectListItem
                    {
                        Text = i.ToString(),
                        Value = i.ToString()
                    };
                }).ToList()


             };

            return View(model);
        }

        public IActionResult Snimi(TakmicenjeDodajVM VM)
        {
            var tak = new Takmicenje
            {
                SkolaID = VM.SkolaID,
                PredmetID = VM.PredmetID,
                Razred = VM.Razred,
                Datum = VM.Datum,
                isZakljucano = false
            };
            db.Takmicenja.Add(tak);
            db.SaveChanges();

            var takmicari = db.DodjeljenPredmet.Where(i => i.PredmetId == VM.PredmetID && i.ZakljucnoKrajGodine == 5).ToList();

            foreach(var takmicar in takmicari)
            {
                if (db.DodjeljenPredmet.Where(i => i.Id == takmicar.Id).Average(i => i.ZakljucnoKrajGodine) > 4)
                {
                    var noviTakmicar = new TakmicenjeUcesnik
                    {
                        TakmicenjeID = tak.TakmicenjeID,
                        isPristupio = false,
                        OdjeljenjeStavkaID = takmicar.OdjeljenjeStavkaId,
                        BrojBodova = 0,
                    };
                    db.TakmicenjeUcesnici.Add(noviTakmicar);
                }
            }
            db.SaveChanges();


            return Redirect("Index");
        }
        public IActionResult Rezultat(int Id)
        {
            var Takmicenje = db.Takmicenja.Find(Id);
            TakmicenjeRezultatiVM model = new TakmicenjeRezultatiVM
            {
                TakmicenjeID = Id,
                SkolaID = Takmicenje.SkolaID,
                Datum = Takmicenje.Datum,
                Predmet = db.Predmet.Find(Takmicenje.PredmetID).Naziv,
                Razred = Takmicenje.Razred,
                SkolaDomacin = db.Skola.Find(Takmicenje.SkolaID).Naziv
            };
            return View(model);
        }
        public IActionResult Zakljucaj(int id)
        {
            var tak = db.Takmicenja.Where(i => i.TakmicenjeID == id).FirstOrDefault();
            if (tak.isZakljucano == false)
            {
                tak.isZakljucano = !tak.isZakljucano;
                db.SaveChanges();
            }
            return Redirect("/Takmicenje/Rezultat/" + id);
        }
    } 
}