using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Metadata;
using RS1_Ispit_asp.net_core.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class TakmicenjeController : Controller
    {
        private readonly MojContext db;

        public TakmicenjeController(MojContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int SkolaID =0)
        {
            TakmicenjeIndexVM model;

            if (SkolaID != 0)
            {
                model = new TakmicenjeIndexVM
                {
                    SkolaID=SkolaID,
                    Skole = db.Skola.Select(i => new SelectListItem
                    {
                        Value = i.Id.ToString(),
                        Text = i.Naziv
                    }).ToList(),
                   
                
                    Redovi = db.Takmicenja.Where(x => x.SkolaID == SkolaID).Select(t => new TakmicenjeIndexVM.Red
                    {
                        
                        TakmicenjeID = t.TakmicenjeID,
                        Skola = t.Skola.Naziv,
                        Predmet=t.Predmet.Naziv,
                        Razred = t.Predmet.Razred.ToString(),
                        Datum = t.Datum.ToString("dd/MM/yyyy"),
                        NajboljiUcenik = db.TakmicenjeUcesnici.Where(x => x.TakmicenjeID == t.TakmicenjeID).OrderByDescending(i => i.bodovi)
                              .Select(i => i.Takmicenje.Skola.Naziv + " | " + i.OdjeljenjeStavka.Odjeljenje.Oznaka + " | " + i.OdjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()
                    }).ToList()


                };
            }


            else
            {
                model = new TakmicenjeIndexVM
                {

                    Skole = db.Skola.Select(i => new SelectListItem
                    {
                        Value = i.Id.ToString(),
                        Text = i.Naziv
                    }).ToList(),

                    Redovi = db.Takmicenja.Select(t => new TakmicenjeIndexVM.Red
                    {
                        TakmicenjeID = t.TakmicenjeID,
                        Skola = t.Skola.Naziv,
                        Predmet = t.Predmet.Naziv,
                        Razred = t.Predmet.Razred.ToString(),
                        Datum = t.Datum.ToString("dd/MM/yyyy"),
                        NajboljiUcenik = db.TakmicenjeUcesnici.Where(x => x.TakmicenjeID == t.TakmicenjeID).OrderByDescending(i => i.bodovi)
                              .Select(i => i.Takmicenje.Skola.Naziv + " | " + i.OdjeljenjeStavka.Odjeljenje.Oznaka + " | " + i.OdjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()
                    }).ToList()

                };
            }


                return View(model);
        }

        public IActionResult Dodaj(int id)
        {
            
            var model = new TakmicenjeDodajVM
            {
              
                SkolaID=id,
                Skola = db.Skola.Where(x => x.Id == id).Select(x => x.Naziv).FirstOrDefault(),
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
                isZakljucano = false
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
                        bodovi = 0,
                        isPristupio = false,
                        Takmicenje = takmicenje,
                        OdjeljenjeStavkaID = takmicar.OdjeljenjeStavkaId
                    };
                    db.TakmicenjeUcesnici.Add(noviTakmicar);
                }

            }
            db.SaveChanges();

            return Redirect("Index");
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
                SkolaDomacin=takmicenje.Skola.Naziv,
                Predmet=takmicenje.Predmet.Naziv

            };

            return View(model);
        }

        public IActionResult Zakljucaj (int id)
        {
            var tak = db.Takmicenja.Where(i => i.TakmicenjeID == id).FirstOrDefault();

            if (tak.isZakljucano == false)
            {
                tak.isZakljucano = !tak.isZakljucano;
                db.SaveChanges();
            }
            return Redirect("/Takmicenje/Rezultati/" + id);
        }


    }
}