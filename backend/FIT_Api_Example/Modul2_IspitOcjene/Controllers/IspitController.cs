using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Modul2_IspitOcjene.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2_IspitOcjene.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IspitController : ControllerBase
    {
        //prodekan - opcije
      //  private readonly ApplicationDbContext _applicationDbContext;
      //
      //  public IspitController(ApplicationDbContext applicationDbContext)
      //  {
      //      _applicationDbContext = applicationDbContext;
      //  }
      //
      //  [HttpGet]
      //  public List<IspitGetResponse> Get(string? naziv)
      //  {
      //      var rezultat = _applicationDbContext
      //          .Ispit
      //          .Where(x=>naziv == null || x.Predmet.Naziv.ToLower().StartsWith(naziv.ToLower()))
      //          .Select(x => new IspitGetResponse
      //          {
      //              IdIspita = x.ID,
      //              Komnt = x.Komentar,
      //              Satnica = x.DatumVrijemeIspita,
      //              PredmetId = x.PredmetID,
      //              PuniNaziv = x.Predmet.Naziv,
      //              SifraPredmeta = x.Predmet.Sifra,
      //              Bodovi = x.Predmet.Ects
      //          }).ToList();
      //
      //      return rezultat;
      //  }
      //
      //
      //  [HttpPut()]
      //  public ActionResult UpdateIspita([FromBody] IspitUpdateRequest podaci)
      //  {
      //      var ispit = _applicationDbContext.Ispit.Where(x => x.ID == podaci.IspitId).FirstOrDefault();
      //      if (ispit == null)
      //      {
      //          return new NotFoundResult();
      //      }
      //
      //      ispit.DatumVrijemeIspita = podaci.Satnica;
      //      ispit.Komentar = podaci.Komentar;
      //      //ispit.PredmetID = podaci.PredmetId;//ipak zabraniti izmjenu predmeta
      //      _applicationDbContext.SaveChanges();//saveChanges izvršava insert, update, delete
      //
      //      return Ok(ispit);//vraca status 200 i json od "ispit"
      //  }
      //
      //  [HttpPost]
      //  public Ispit DodajIspitNeispravno(int predmetId, DateTime satnica, string komentar)
      //  {
      //      //neispravno jer ne treba slati nove podatke u query parametru... jer je to dio URL-a
      //      var noviObj = new Ispit
      //      {
      //          PredmetID = predmetId,
      //          DatumVrijemeIspita = satnica,
      //          Komentar = komentar
      //      };
      //      _applicationDbContext.Ispit.Add(noviObj);//
      //
      //      _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."
      //
      //      return noviObj;
      //  }
      //
      //  [HttpPost]
      //  public Ispit DodajIspit([FromBody] IspitInsertRequest podaci)
      //  {
      //      var noviObj = new Ispit
      //      {
      //          PredmetID = podaci.PredmetId,
      //          DatumVrijemeIspita = podaci.Satnica,
      //          Komentar = podaci.Komentar
      //      };
      //      _applicationDbContext.Ispit.Add(noviObj);//
      //
      //      _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."
      //
      //      return noviObj;
      //  }
      //
      //  [HttpDelete()]
      //  public object Obrisi(int ispitId)
      //  {
      //      //1 get objekat
      //      var ispit = _applicationDbContext.Ispit.Where(x => x.ID == ispitId).FirstOrDefault();
      //      if (ispit == null)
      //      {
      //          return new NotFoundResult();
      //      }
      //
      //      _applicationDbContext.Remove(ispit);
      //      _applicationDbContext.SaveChanges();
      //
      //      return "uspjesno obrisan";
      //  }
    }
}
