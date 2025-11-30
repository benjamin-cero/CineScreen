using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieDirectorEndpoints.MovieDirectorGetAllEndpoint;

namespace CineScreen.Endpoints.MovieDirectorEndpoints;

[Route("movie-directors")]
public class MovieDirectorGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieDirectorGetAllRequest>
    .WithResult<MyPagedList<MovieDirectorGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MovieDirectorGetAllResponse>> HandleAsync([FromQuery] MovieDirectorGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.MovieDirectors
            .Include(md => md.Movie)
            .Include(md => md.Director)
            .AsQueryable();

        // Filter by movie ID
        if (request.MovieID.HasValue)
        {
            query = query.Where(md => md.MovieID == request.MovieID.Value);
        }

        // Filter by director ID
        if (request.DirectorID.HasValue)
        {
            query = query.Where(md => md.DirectorID == request.DirectorID.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(md => new MovieDirectorGetAllResponse
        {
            ID = md.ID,
            MovieID = md.MovieID,
            MovieTitle = md.Movie.Title,
            DirectorID = md.DirectorID,
            DirectorName = $"{md.Director.FirstName} {md.Director.LastName}"
        });

        // Create paginated response with filter
        var result = await MyPagedList<MovieDirectorGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MovieDirectorGetAllRequest : MyPagedRequest
    {
        public int? MovieID { get; set; }
        public int? DirectorID { get; set; }
    }

    public class MovieDirectorGetAllResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int DirectorID { get; set; }
        public string DirectorName { get; set; } = string.Empty;
    }
} 