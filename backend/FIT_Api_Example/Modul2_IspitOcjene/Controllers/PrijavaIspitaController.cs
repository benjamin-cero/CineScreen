using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Modul2_IspitOcjene.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2_IspitOcjene.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrijavaIspitController : ControllerBase
    {
        //student - opcije
        private readonly ApplicationDbContext _applicationDbContext;

        public PrijavaIspitController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

       // [HttpGet]
       // public List<PrijavaIspitaGetResponse> GetPrijavljeni(int studentId)
       // {
       //     var rezultat = _applicationDbContext
       //         .PrijavaIspita
       //         .Where(x=>x.StudentID == studentId)
       //         .Select(x => new PrijavaIspitaGetResponse
       //         {
       //             PrijavaIspitId = x.ID,
       //             DatumVrijemeIspita = x.Ispit.DatumVrijemeIspita,
       //             Komentar = x.Ispit.Komentar,
       //             PredmetNaziv = x.Ispit.Predmet.Naziv,
       //             PredmetSifra = x.Ispit.Predmet.Sifra
       //         }).ToList();
       //
       //     return rezultat;
       // }
       //
       // [HttpGet]
       // public List<PrijavaIspitaGetNeprijavljeniResponse> GetNeprijavljeni(int studentId)
       // {
       //     List<PrijavaIspitaGetNeprijavljeniResponse> sviIspiti = _applicationDbContext
       //         .Ispit
       //         .Select(x => new PrijavaIspitaGetNeprijavljeniResponse()
       //         {
       //             IspitId = x.ID,
       //             DatumVrijemeIspita = x.DatumVrijemeIspita,
       //             Komentar = x.Komentar,
       //             PredmetNaziv = x.Predmet.Naziv,
       //             PredmetSifra = x.Predmet.Sifra,
       //             PredmetID = x.PredmetID,
       //         }).ToList();
       //
       //
       //     var predmetiStudenta = _applicationDbContext.StudentPredmet.Where(x=>x.StudentID == studentId).ToList();
       //
       //     var rezultat = new List<PrijavaIspitaGetNeprijavljeniResponse>();
       //
       //     sviIspiti.ForEach(x =>
       //     {
       //         if (predmetiStudenta.Any(p => p.PredmetID == x.PredmetID && p.OcjenaBrojcano == null))
       //         {
       //             rezultat.Add(x);
       //         }
       //     });
       //
       //     return rezultat;
       // }
       //
       // [HttpPost]
       // public PrijavaIspita Dodaj([FromBody] PrijavaIspitaDodajRequest podaci)
       // {
       //     var noviObj = new PrijavaIspita()
       //     {
       //         IspitID = podaci.IspitId,
       //         DatumPrijave = DateTime.Now,
       //         OdjavaIspit = null,
       //         StudentID = podaci.StudentId
       //     };
       //     _applicationDbContext.PrijavaIspita.Add(noviObj); //
       //
       //     _applicationDbContext.SaveChanges(); //izvrašva se "insert into Ispit value ...."
       //
       //     return noviObj;
       // }
       //
       //
       // [HttpDelete()]
       // public object Odjava(PrijavaIspitaObrisiRequest podaci)
       // {
       //     //1 get objekat
       //     var prijavaIspita = _applicationDbContext.PrijavaIspita.Where(x => x.ID == podaci.PrijavaIspitId).FirstOrDefault();
       //     if (prijavaIspita == null)
       //     {
       //         return new NotFoundResult();
       //     }
       //
       //     prijavaIspita.OdjavaIspit = DateTime.Now;
       //     _applicationDbContext.SaveChanges();
       //
       //     return "uspjesno odjavljen";
       // }
    }
}