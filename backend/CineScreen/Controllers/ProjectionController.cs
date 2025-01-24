using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProjectionController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Projection>> Get()
        {
            var projection = _DbContext.Projection.ToList();

            if (projection == null)
            {
                return NotFound();
            }
            return projection;
        }

        [HttpGet("ProjectionID")]

        public ActionResult<Projection> GetById(int ProjectionId)
        {
            var projection = _DbContext.Projection.Find(ProjectionId);
            if (projection == null)
            {
                return NotFound();
            }
            return projection;
        }

        [HttpDelete("ProjectionID")]

        public ActionResult<Projection> Delete(int ProjectionId)
        {
            var projection = _DbContext.Projection.Find(ProjectionId);
            if (projection == null)
            {
                return NotFound();
            }
            _DbContext.Remove(projection);
            _DbContext.SaveChanges();
            return projection;
        }

        [HttpPost]

        public ActionResult<Projection> Insert([FromBody] ProjectionUpsertVM x)
        {
            var NewProjection = new Projection()
            {
                CinemaHallID = x.CinemaHallID,
                StartTime = x.StartTime,
                MovieID = x.MovieID,
                MovieTypeID = x.MovieTypeID,
                Price = x.Price,
            };
            _DbContext.Projection.Add(NewProjection);
            _DbContext.SaveChanges();
            return NewProjection;
        }

        [HttpPut("ProjectionID")]

        public ActionResult<Projection> Update(int ProjectionId, ProjectionUpsertVM x)
        {
            var UpdateProjection = _DbContext.Projection.Find(ProjectionId);
            if (UpdateProjection == null)
            {
                return NotFound();
            }
            UpdateProjection.CinemaHallID = x.CinemaHallID;
            UpdateProjection.StartTime = x.StartTime;
            UpdateProjection.MovieID = x.MovieID;
            UpdateProjection.MovieTypeID = x.MovieTypeID;
            UpdateProjection.Price = x.Price;
            _DbContext.SaveChanges();
            return UpdateProjection;

        }
    }
}
