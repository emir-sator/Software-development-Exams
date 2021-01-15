using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class TakmicenjeController : Controller
    {
        private readonly MojContext db;

        public TakmicenjeController(MojContext _db)
        {
            db = _db;
        }

        public IActionResult Index(TakmicenjeIndexVM vm=null)
        {
            var razredi = new List<string> { "1", "2", "3", "4" };
            var model = new TakmicenjeIndexVM
            {
                SkolaID=vm.SkolaID,
                Skole = db.Skola.Select(i => new SelectListItem
                {
                    Text=i.Naziv,
                    Value=i.Id.ToString()
                }).ToList(),
                Razred=vm.Razred,
                Razredi=razredi.Select(i=>
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
        public IActionResult Prikazi(TakmicenjeIndexVM vm)
        {

            //var skola = db.Takmicenja
            //    .Where(i => i.SkolaID == vm.SkolaID)
            //    .SingleOrDefault();


            TakmicenjePrikaziVM model;
            if (vm.Razred == 0)
            {
                    model = new TakmicenjePrikaziVM
                    {
                        SkolaID = vm.SkolaID,
                       Razred=vm.Razred,
                        Redovi = db.Takmicenja.Where(s => s.SkolaID == vm.SkolaID).Select(s => new TakmicenjePrikaziVM.Red
                        {
                            TakmicenjeID = s.TakmicenjeID,
                            Skola = s.Skola.Naziv,
                            Datum = s.Datum.ToString("dd/MM/yyyy"),
                            Predmet = s.Predmet.Naziv,
                            Razred = s.Predmet.Razred.ToString(),
                            NajboljiUcenik = db.TakmicenjeUcesnici.Include(x => x.OdjeljenjeStavka).ThenInclude(x => x.Odjeljenje).ThenInclude(x => x.Skola).Include(x => x.OdjeljenjeStavka).ThenInclude(x => x.Ucenik)
                        .Where(x => x.TakmicenjeID == s.TakmicenjeID).OrderByDescending(i => i.BrojBodova)
                        .Select(i => i.Takmicenje.Skola.Naziv + " | " + i.OdjeljenjeStavka.Odjeljenje.Oznaka + " | " + i.OdjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()
                        }).ToList()


                    };
            }
            else

            {
                model = new TakmicenjePrikaziVM
                {
                    SkolaID = vm.SkolaID,
                    Razred=vm.Razred,
                    Redovi = db.Takmicenja.Where(s => s.SkolaID == vm.SkolaID && s.Predmet.Razred == vm.Razred).Select(s => new TakmicenjePrikaziVM.Red
                    {
                        TakmicenjeID = s.TakmicenjeID,
                        Skola = s.Skola.Naziv,
                        Datum = s.Datum.ToString("dd/MM/yyyy"),
                        Predmet = s.Predmet.Naziv,
                        Razred = s.Predmet.Razred.ToString(),
                        NajboljiUcenik = db.TakmicenjeUcesnici.Include(x => x.OdjeljenjeStavka).ThenInclude(x => x.Odjeljenje).ThenInclude(x => x.Skola).Include(x => x.OdjeljenjeStavka).ThenInclude(x => x.Ucenik)
                        .Where(x => x.TakmicenjeID == s.TakmicenjeID).OrderByDescending(i => i.BrojBodova)
                        .Select(i => i.Takmicenje.Skola.Naziv + " | " + i.OdjeljenjeStavka.Odjeljenje.Oznaka + " | " + i.OdjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()
                    }).ToList()


                };
            }
        

            return PartialView(model);
        }
        public IActionResult Dodaj(int id)
        {
            var skola = db.Skola.Find(id);
            var model = new TakmicenjeDodajVM
            {
                
                SkolaID=skola.Id,
                Skola=skola.Naziv,
                
                Predmeti = db.Predmet.GroupBy(i => i.Naziv).Select(i => i.FirstOrDefault()).Select(i => new SelectListItem
                {
                    Text = i.Naziv,
                    Value = i.Id.ToString()
                }).ToList(),
                Datum = DateTime.Now
            };
            return View(model);
        }
        public IActionResult Snimi(TakmicenjeDodajVM VM)
        {
            
            var takmicenje = new Takmicenje
            {
                
                SkolaID = VM.SkolaID,
                PredmetID = VM.PredmetID,
                Datum = VM.Datum,
                
                IsZakljucano = false
            };
            db.Takmicenja.Add(takmicenje);
            db.SaveChanges();

            var takmicari = db.DodjeljenPredmet.Where(i => i.PredmetId == VM.PredmetID && i.ZakljucnoKrajGodine == 5).ToList();

            foreach (var takmicar in takmicari)
            {
                if (db.DodjeljenPredmet.Where(i => i.Id == takmicar.Id).Average(i => i.ZakljucnoKrajGodine) > 4)
                {
                    var noviTakmicar = new TakmicenjeUcesnik
                    {
                        BrojBodova = 0,
                        isPristupio = false,
                        Takmicenje = takmicenje,
                        OdjeljenjeStavkaID = takmicar.OdjeljenjeStavkaId
                    };
                    db.TakmicenjeUcesnici.Add(noviTakmicar);
                }

            }
            db.SaveChanges();

            return RedirectToAction("Index", new TakmicenjeIndexVM() { SkolaID=VM.SkolaID, Razred=VM.Razred});
        }
        public IActionResult Rezultati(int id)
        {

            var takmicenje = db.Takmicenja.Include(i => i.Predmet).Include(i => i.Skola).Where(i => i.TakmicenjeID == id).FirstOrDefault();
            TakmicenjeRezultatVM model = new TakmicenjeRezultatVM
            {
                TakmicenjeID = id,
                SkolaID = takmicenje.SkolaID,
                Datum = takmicenje.Datum,
                Razred = takmicenje.Predmet.Razred,
                SkolaDomacin = takmicenje.Skola.Naziv,
                Predmet = takmicenje.Predmet.Naziv

            };

            return View(model);
        }

        public IActionResult Zakljucaj(int id)
        {
            var tak = db.Takmicenja.Where(i => i.TakmicenjeID == id).FirstOrDefault();

            if (tak.IsZakljucano == false)
            {
                tak.IsZakljucano = !tak.IsZakljucano;
                db.SaveChanges();
            }
            return Redirect("/Takmicenje/Rezultati/" + id);
        }
    }
}