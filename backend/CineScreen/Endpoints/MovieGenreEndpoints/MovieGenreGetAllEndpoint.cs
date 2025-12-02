using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieGenreEndpoints.MovieGenreGetAllEndpoint;

namespace CineScreen.Endpoints.MovieGenreEndpoints;

[Route("movie-genres")]
public class MovieGenreGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieGenreGetAllRequest>
    .WithResult<MyPagedList<MovieGenreGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MovieGenreGetAllResponse>> HandleAsync([FromQuery] MovieGenreGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.MovieGenres
            .Include(mg => mg.Movie)
            .Include(mg => mg.Genre)
            .AsQueryable();

        // Filter by movie ID
        if (request.MovieID.HasValue)
        {
            query = query.Where(mg => mg.MovieID == request.MovieID.Value);
        }

        // Filter by genre ID
        if (request.GenreID.HasValue)
        {
            query = query.Where(mg => mg.GenreID == request.GenreID.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(mg => new MovieGenreGetAllResponse
        {
            ID = mg.ID,
            MovieID = mg.MovieID,
            MovieTitle = mg.Movie.Title,
            GenreID = mg.GenreID,
            GenreName = mg.Genre.Name
        });

        // Create paginated response with filter
        var result = await MyPagedList<MovieGenreGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MovieGenreGetAllRequest : MyPagedRequest
    {
        public int? MovieID { get; set; }
        public int? GenreID { get; set; }
    }

    public class MovieGenreGetAllResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int GenreID { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
} 