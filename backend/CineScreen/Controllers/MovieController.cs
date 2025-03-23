using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Movie>> Get()
        {
            var movie = _DbContext.Movie.ToList();

            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpGet("MovieID")]

        public ActionResult<Movie> GetById(int MovieId)
        {
            var movie = _DbContext.Movie.Find(MovieId);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpDelete("MovieID")]

        public ActionResult<Movie> Delete(int MovieId)
        {
            var movie = _DbContext.Movie.Find(MovieId);
            if (movie == null)
            {
                return NotFound();
            }
            _DbContext.Remove(movie);
            _DbContext.SaveChanges();
            return movie;
        }

        [HttpPost]

        public ActionResult<Movie> Insert([FromBody] MovieUpsertVM x)
        {
            var NewMovie = new Movie()
            {
                Description = x.Description,
                Duration = x.Duration,
                Poster = x.Poster,
                ReleaseDate = x.ReleaseDate,
                Status = x.Status,
                Title = x.Title,
                Trailer = x.Trailer
            };

            _DbContext.Movie.Add(NewMovie);
            _DbContext.SaveChanges();
            return NewMovie;
        }

        [HttpPut("MovieID")]

        public ActionResult<Movie> Update(int MovieId, MovieUpsertVM x)
        {
            var UpdateMovie = _DbContext.Movie.Find(MovieId);
            if (UpdateMovie == null)
            {
                return NotFound();
            }
            UpdateMovie.Description = x.Description;
            UpdateMovie.Duration = x.Duration;
            UpdateMovie.Poster = x.Poster;
            UpdateMovie.ReleaseDate = x.ReleaseDate;
            UpdateMovie.Status = x.Status;
            UpdateMovie.Title = x.Title;
            UpdateMovie.Trailer = x.Trailer;
            _DbContext.SaveChanges();
            return UpdateMovie;

        }

    }
}
