using CineScreen.Data;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieEndpoints.MovieGetAllEndpoint;

namespace CineScreen.Endpoints.MovieEndpoints;

[Route("movies")]
public class MovieGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieGetAllRequest>
    .WithResult<MyPagedList<MovieGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MovieGetAllResponse>> HandleAsync([FromQuery] MovieGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .AsQueryable();

        // Filter by search query
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(m => m.Title.Contains(request.Q) || 
                                   m.Description.Contains(request.Q));
        }

        // Filter by status
        if (request.Status.HasValue)
        {
            query = query.Where(m => m.Status == request.Status.Value);
        }

        // Filter by genre
        if (request.GenreId.HasValue)
        {
            query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreID == request.GenreId.Value));
        }

        // Project to result type
        var projectedQuery = query.Select(m => new MovieGetAllResponse
        {
            ID = m.ID,
            Title = m.Title,
            ReleaseDate = m.ReleaseDate,
            Description = m.Description,
            Duration = m.Duration,
            Trailer = m.Trailer,
            Poster = m.Poster,
            Status = m.Status
        });

        // Create paginated response with filter
        var result = await MyPagedList<MovieGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MovieGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty;
        public Status? Status { get; set; }
        public int? GenreId { get; set; }  // ← NEW
    }

    public class MovieGetAllResponse
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string? Trailer { get; set; }
        public byte[]? Poster { get; set; }
        public Status Status { get; set; }
    }
} 