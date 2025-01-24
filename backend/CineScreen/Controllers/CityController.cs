
using CineScreen.Data;
using CineScreen.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CineScreen.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CityController(ApplicationDbContext dbContext) : ControllerBase
    {

        // POST      PATCH   GET   GET       DELETE 
        // Insert , Update , Get , GetById , Delete 


        [HttpGet]
        public ActionResult <List<City>> Get()
        {

            var cities = dbContext.City.ToList();

            if (cities == null)
            {
                return BadRequest();
            }

            return cities;
        }

        [HttpGet("{CityID}")]
        public ActionResult<City> GetById(int CityID)
        {

            var city = dbContext.City.Find(CityID);

            if (city == null)
            {
                return BadRequest();
            }

            return city;
        }

        [HttpDelete("{CityID}")]
        public ActionResult<City> Delete(int CityID)
        {

            var city = dbContext.City.Find(CityID);

            if (city == null)
            {
                return BadRequest();
            }

            dbContext.City.Remove(city);
            dbContext.SaveChanges();

            return city;

        }




        [HttpPost]

        public ActionResult<City> Insert([FromBody] CityUpsertVM x)
        {

            var newCity = new City()
            {
                Name = x.Name
            };

            dbContext.City.Add(newCity);
            dbContext.SaveChanges();

            return newCity;


        }

        [HttpPut("{CityID}")]

        public ActionResult<City> Update(int CityID, CityUpsertVM x)
        {

            var updatedCity = dbContext.City.Find(CityID);

            updatedCity.Name = x.Name;

            dbContext.SaveChanges();

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
