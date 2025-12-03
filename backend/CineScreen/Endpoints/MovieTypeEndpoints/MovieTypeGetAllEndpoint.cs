using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieTypeEndpoints.MovieTypeGetAllEndpoint;

namespace CineScreen.Endpoints.MovieTypeEndpoints;

[Route("movie-types")]
public class MovieTypeGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieTypeGetAllRequest>
    .WithResult<MyPagedList<MovieTypeGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MovieTypeGetAllResponse>> HandleAsync([FromQuery] MovieTypeGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.MovieTypes
            .AsQueryable();

        // Filter by search query
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(mt => mt.Type.Contains(request.Q));
        }

        // Project to result type
        var projectedQuery = query.Select(mt => new MovieTypeGetAllResponse
        {
            ID = mt.ID,
            Type = mt.Type
        });

        // Create paginated response with filter
        var result = await MyPagedList<MovieTypeGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MovieTypeGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty;
    }

    public class MovieTypeGetAllResponse
    {
        public int ID { get; set; }
        public string Type { get; set; } = string.Empty;
    }
} 