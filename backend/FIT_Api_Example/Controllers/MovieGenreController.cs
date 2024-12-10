using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieGenreController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;
        

        public MovieGenreController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public ActionResult<List<MovieGenre>> Get()
        {
            var MovieGenre = _DbContext.MovieGenre.ToList();

            if(MovieGenre == null)
            {
                return NotFound();
            }
            return MovieGenre;
        }

        [HttpGet("MovieGenreID")]

        public ActionResult<MovieGenre> GetById(int MovieGenreId)
        {
            var movieGenre = _DbContext.MovieGenre.Find(MovieGenreId);
            if (movieGenre == null)
            {
                return NotFound();
            }
            return movieGenre;
        }

        [HttpDelete("MovieGenreID")]

        public ActionResult<MovieGenre> Delete(int MovieGenreId) {
            var movieGenre = _DbContext.MovieGenre.Find(MovieGenreId);
            if (movieGenre == null)
            {
                return NotFound();
            }
            _DbContext.MovieGenre.Remove(movieGenre);
            _DbContext.SaveChanges();
            return movieGenre;
        }

        [HttpPost]
        public ActionResult<MovieGenre> Insert([FromBody]MovieGenreUpsertVM x)
        {
            var NewMovieGenre = new MovieGenre()
            {
                GenreID = x.GenreID,
                MovieID = x.MovieID
            };
            _DbContext.MovieGenre.Add(NewMovieGenre);
            _DbContext.SaveChanges();
            return NewMovieGenre;
        }
        [HttpPut("MovieGenreID")]
        public ActionResult<MovieGenre> Update(int MovieGenreId, MovieGenreUpsertVM x)
        {
            var movieGenre = _DbContext.MovieGenre.Find(MovieGenreId);
            if (movieGenre == null)
            {
                return NotFound();
            }
            movieGenre.MovieID = x.MovieID;
            movieGenre.GenreID = x.GenreID;
            _DbContext.SaveChanges();
            return movieGenre;
        }
    }
}
