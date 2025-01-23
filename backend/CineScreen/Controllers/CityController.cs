
using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CineScreen.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CityController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // POST      PATCH   GET   GET       DELETE 
        // Insert , Update , Get , GetById , Delete 


        [HttpGet]
        public ActionResult <List<City>> Get()
        {

            var cities = _dbContext.City.ToList();

            if (cities == null)
            {
                return BadRequest();
            }

            return cities;
        }

        [HttpGet("{CityID}")]
        public ActionResult<City> GetById(int CityID)
        {

            var city = _dbContext.City.Find(CityID);

            if (city == null)
            {
                return BadRequest();
            }

            return city;
        }

        [HttpDelete("{CityID}")]
        public ActionResult<City> Delete(int CityID)
        {

            var city = _dbContext.City.Find(CityID);

            if (city == null)
            {
                return BadRequest();
            }

            _dbContext.City.Remove(city);
            _dbContext.SaveChanges();

            return city;

        }




        [HttpPost]

        public ActionResult<City> Insert([FromBody] CityUpsertVM x)
        {

            var newCity = new City()
            {
                Name = x.Name
            };

            _dbContext.City.Add(newCity);
            _dbContext.SaveChanges();

            return newCity;


        }

        [HttpPut("{CityID}")]

        public ActionResult<City> Update(int CityID, CityUpsertVM x)
        {

            var updatedCity = _dbContext.City.Find(CityID);

            updatedCity.Name = x.Name;

            _dbContext.SaveChanges();

            return updatedCity;
        }

        //
        //
        // [HttpPost]
        // public Drzava Snimi([FromBody] DrzavaSnimiVM x)
        // {
        //     Drzava? objekat;
        //
        //     if (x.id == 0)
        //     {
        //         objekat = new Drzava();
        //         _dbContext.Add(objekat);//priprema sql
        //     }
        //     else
        //     {
        //         objekat = _dbContext.Drzava.Find(x.id);
        //     }
        //
        //     objekat.Naziv = x.naziv;
        //     objekat.Skracenica = x.skracenica;
        //
        //     _dbContext.SaveChanges();
        //     return objekat;
        // }
        //
        // [HttpGet]
        // public ActionResult GetAll()
        // {
        //     var data = _dbContext.Drzava
        //         .OrderBy(s => s.Naziv)
        //         .Select(s => new DrzavaGetAllVM()
        //         {
        //             id = s.ID,
        //             skracenica = s.Skracenica,
        //             naziv = s.Naziv,
        //         })
        //         .Take(100);
        //     return Ok(data.ToList());
        // }
    }

   
}
