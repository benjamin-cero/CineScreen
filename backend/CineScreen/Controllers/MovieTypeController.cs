using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public MovieTypeController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }

        [HttpGet]

        public ActionResult<List<MovieType>> Get()
        {
            var movietype = _DbContext.MovieType.ToList();

            if (movietype == null)
            {
                return NotFound();
            }
            return movietype;
        }

        [HttpGet("MovieTypeID")]

        public ActionResult<MovieType> GetById(int MovieTypeId)
        {
            var movietype = _DbContext.MovieType.Find(MovieTypeId);
            if (movietype == null)
            {
                return NotFound();
            }
            return movietype;
        }

        [HttpDelete("MovieTypeID")]

        public ActionResult<MovieType> Delete(int MovieTypeId)
        {
            var movietype = _DbContext.MovieType.Find(MovieTypeId);
            if (movietype == null)
            {
                return NotFound();
            }
            _DbContext.Remove(movietype);
            _DbContext.SaveChanges();
            return movietype;
        }

        [HttpPost]

        public ActionResult<MovieType> Insert([FromBody] MovieTypeUpsertVM x)
        {
            var NevMovieType = new MovieType()
            {
                Type = x.Type
            };
            _DbContext.MovieType.Add(NevMovieType);
            _DbContext.SaveChanges();
            return NevMovieType;
        }

        [HttpPut("MovieTypeID")]

        public ActionResult<MovieType> Update(int MovieTypeId, MovieTypeUpsertVM x)
        {
            var UpdateMovieType = _DbContext.MovieType.Find(MovieTypeId);
            if (UpdateMovieType == null)
            {
                return NotFound();
            }
            UpdateMovieType.Type = x.Type;
            _DbContext.SaveChanges();
            return UpdateMovieType;

        }
    }
}
