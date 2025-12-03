using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProjectionEndpoints.ProjectionGetByIdEndpoint;

namespace CineScreen.Endpoints.ProjectionEndpoints;

[Route("projections")]
public class ProjectionGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProjectionGetByIdRequest>
    .WithActionResult<ProjectionGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<ProjectionGetByIdResponse>> HandleAsync([FromRoute] ProjectionGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var projection = await db.Projections
            .Include(p => p.Movie)
            .Include(p => p.CinemaHall)
            .Include(p => p.MovieType)
            .Where(p => p.ID == request.ID)
            .Select(p => new ProjectionGetByIdResponse
            {
                ID = p.ID,
                StartTime = p.StartTime,
                Price = p.Price,
                MovieID = p.MovieID,
                MovieTitle = p.Movie.Title,
                CinemaHallID = p.CinemaHallID,
                CinemaHallName = p.CinemaHall.Name,
                MovieTypeID = p.MovieTypeID,
                MovieTypeName = p.MovieType.Type
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (projection == null)
        {
            return NotFound("Projection not found");
        }

        return Ok(projection);
    }

    public class ProjectionGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class ProjectionGetByIdResponse
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public double Price { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int CinemaHallID { get; set; }
        public string CinemaHallName { get; set; } = string.Empty;
        public int MovieTypeID { get; set; }
        public string MovieTypeName { get; set; } = string.Empty;
    }
} 