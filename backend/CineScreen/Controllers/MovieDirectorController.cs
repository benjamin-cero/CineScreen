using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieDirectorController(ApplicationDbContext _DbContext) : ControllerBase 
    {

        [HttpGet]

        public ActionResult<List<MovieDirector>> Get()
        {
            var movieDirector = _DbContext.MovieDirector.ToList();

            if (movieDirector == null)
            {
                return NotFound();
            }
            return movieDirector;
        }

        [HttpGet("MovieDirectorID")]

        public ActionResult<MovieDirector> GetById(int MovieDirectorId)
        {
            var movieDirector = _DbContext.MovieDirector.Find(MovieDirectorId);
            if (movieDirector == null)
            {
                return NotFound();
            }
            return movieDirector;
        }

        [HttpDelete("MovieDirectorID")]

        public ActionResult<MovieDirector> Delete(int MovieDirectorId)
        {
            var movieDirector = _DbContext.MovieDirector.Find(MovieDirectorId);
            if (movieDirector == null)
            {
                return NotFound();
            }
            _DbContext.Remove(movieDirector);
            _DbContext.SaveChanges();
            return movieDirector;
        }

        [HttpPost]

        public ActionResult<MovieDirector> Insert([FromBody] MovieDirectorUpsertVM x)
        {
            var newMovieDirector = new MovieDirector()
            {
                DirectorID = x.DirectorID,
                MovieID = x.MovieID
            };
            _DbContext.MovieDirector.Add(newMovieDirector);
            _DbContext.SaveChanges();
            return newMovieDirector;
        }

        [HttpPut("MovieDirectorID")]

        public ActionResult<MovieDirector> Update(int MovieDirectorId, MovieDirectorUpsertVM x)
        {
            var UpdateMovieDirector = _DbContext.MovieDirector.Find(MovieDirectorId);
            if (UpdateMovieDirector == null)
            {
                return NotFound();
            }
            UpdateMovieDirector.DirectorID = x.DirectorID;
            UpdateMovieDirector.MovieID = x.MovieID;
            _DbContext.SaveChanges();
            return UpdateMovieDirector;

        }

    }
}
