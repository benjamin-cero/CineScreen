using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieActorEndpoints.MovieActorGetByIdEndpoint;

namespace CineScreen.Endpoints.MovieActorEndpoints;

[Route("movie-actors")]
public class MovieActorGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieActorGetByIdRequest>
    .WithActionResult<MovieActorGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MovieActorGetByIdResponse>> HandleAsync([FromRoute] MovieActorGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var movieActor = await db.MovieActors
            .Include(ma => ma.Movie)
            .Include(ma => ma.Actor)
            .Where(ma => ma.ID == request.ID)
            .Select(ma => new MovieActorGetByIdResponse
            {
                ID = ma.ID,
                MovieID = ma.MovieID,
                MovieTitle = ma.Movie.Title,
                ActorID = ma.ActorID,
                ActorName = $"{ma.Actor.FirstName} {ma.Actor.LastName}"
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (movieActor == null)
        {
            return NotFound("Movie actor relationship not found");
        }

        return Ok(movieActor);
    }

    public class MovieActorGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MovieActorGetByIdResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int ActorID { get; set; }
        public string ActorName { get; set; } = string.Empty;
    }
} 