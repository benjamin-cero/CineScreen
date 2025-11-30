using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieActorEndpoints.MovieActorGetAllEndpoint;

namespace CineScreen.Endpoints.MovieActorEndpoints;

[Route("movie-actors")]
public class MovieActorGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieActorGetAllRequest>
    .WithResult<MyPagedList<MovieActorGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MovieActorGetAllResponse>> HandleAsync([FromQuery] MovieActorGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.MovieActors
            .Include(ma => ma.Movie)
            .Include(ma => ma.Actor)
            .AsQueryable();

        // Filter by movie ID
        if (request.MovieID.HasValue)
        {
            query = query.Where(ma => ma.MovieID == request.MovieID.Value);
        }

        // Filter by actor ID
        if (request.ActorID.HasValue)
        {
            query = query.Where(ma => ma.ActorID == request.ActorID.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(ma => new MovieActorGetAllResponse
        {
            ID = ma.ID,
            MovieID = ma.MovieID,
            MovieTitle = ma.Movie.Title,
            ActorID = ma.ActorID,
            ActorName = $"{ma.Actor.FirstName} {ma.Actor.LastName}"
        });

        // Create paginated response with filter
        var result = await MyPagedList<MovieActorGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MovieActorGetAllRequest : MyPagedRequest
    {
        public int? MovieID { get; set; }
        public int? ActorID { get; set; }
    }

    public class MovieActorGetAllResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int ActorID { get; set; }
        public string ActorName { get; set; } = string.Empty;
    }
} 