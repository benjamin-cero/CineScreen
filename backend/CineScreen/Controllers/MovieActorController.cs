using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieActorController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<MovieActor>> Get()
        {
            var movieActor = _DbContext.MovieActor.ToList();

            if (movieActor == null)
            {
                return NotFound();
            }
            return movieActor;
        }

        [HttpGet("MovieActorID")]

        public ActionResult<MovieActor> GetById(int MovieActorId)
        {
            var movieActor = _DbContext.MovieActor.Find(MovieActorId);
            if (movieActor == null)
            {
                return NotFound();
            }
            return movieActor;
        }

        [HttpDelete("MovieActorID")]

        public ActionResult<MovieActor> Delete(int MovieActorId)
        {
            var movieActor = _DbContext.MovieActor.Find(MovieActorId);
            if (movieActor == null)
            {
                return NotFound();
            }
            _DbContext.Remove(movieActor);
            _DbContext.SaveChanges();
            return movieActor;
        }

        [HttpPost]

        public ActionResult<MovieActor> Insert([FromBody] MovieActorUpsertVM x)
        {
            var NewmovieActor = new MovieActor()
            {
                ActorID = x.ActorID,
                MovieID = x.MovieID,
            };
            _DbContext.MovieActor.Add(NewmovieActor);
            _DbContext.SaveChanges();
            return NewmovieActor;
        }

        [HttpPut("MovieActorID")]

        public ActionResult<MovieActor> Update(int MovieActorId, MovieActorUpsertVM x)
        {
            var UpdateMovieActor = _DbContext.MovieActor.Find(MovieActorId);
            if (UpdateMovieActor == null)
            {
                return NotFound();
            }
            UpdateMovieActor.ActorID = x.ActorID;
            UpdateMovieActor.MovieID = x.MovieID;
            _DbContext.SaveChanges();
            return UpdateMovieActor;

        }
    }
}
