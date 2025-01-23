using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieProductionHouseController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public MovieProductionHouseController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<MovieProductionHouse>> Get()
        {
            var movieProductionHouse = _DbContext.MovieProductionHouse.Include(x=> x.Movie).Include(x=> x.ProductionHouse).ToList();

            if (movieProductionHouse == null)
            {
                return NotFound();
            }
            return movieProductionHouse;
        }

        [HttpGet("MovieProductionHouseID")]

        public ActionResult<MovieProductionHouse> GetById(int MovieProductionHouseId)
        {
            var movieProductionHouse = _DbContext.MovieProductionHouse
                .Include(x => x.Movie) // Include the related Movie entity
                .Include(x => x.ProductionHouse) // Include the related ProductionHouse entity
                .FirstOrDefault(x => x.MovieProductionHouseID == MovieProductionHouseId);
            if (movieProductionHouse == null)
            {
                return NotFound();
            }
            return movieProductionHouse;
        }

        [HttpDelete("MovieProductionHouseID")]

        public ActionResult<MovieProductionHouse> Delete(int MovieProductionHouseId)
        {
            var movieProductionHouse = _DbContext.MovieProductionHouse.Find(MovieProductionHouseId);
            if (movieProductionHouse == null)
            {
                return NotFound();
            }
            _DbContext.Remove(movieProductionHouse);
            _DbContext.SaveChanges();
            return movieProductionHouse;
        }

        [HttpPost]

        public ActionResult<MovieProductionHouse> Insert([FromBody] MovieProductionHouseUpsertVM x)
        {
            var NewMovieProductionHouse = new MovieProductionHouse()
            {
                MovieID = x.MovieID,
                ProductionHouseID = x.ProductionHouseID
            };
            _DbContext.MovieProductionHouse.Add(NewMovieProductionHouse);
            _DbContext.SaveChanges();
            return NewMovieProductionHouse;
        }

        [HttpPut("MovieProductionHouseID")]

        public ActionResult<MovieProductionHouse> Update(int MovieProductionHouseId, MovieProductionHouseUpsertVM x)
        {
            var UpdateMovieProductionHouse = _DbContext.MovieProductionHouse.Find(MovieProductionHouseId);
            if (UpdateMovieProductionHouse == null)
            {
                return NotFound();
            }
            UpdateMovieProductionHouse.MovieID = x.MovieID;
            UpdateMovieProductionHouse.ProductionHouseID = x.ProductionHouseID;
            _DbContext.SaveChanges();
            return UpdateMovieProductionHouse;

        }

    }
}
