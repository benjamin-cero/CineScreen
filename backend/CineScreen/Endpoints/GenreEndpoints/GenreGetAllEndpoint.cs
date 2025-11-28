using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.GenreEndpoints.GenreGetAllEndpoint;

namespace CineScreen.Endpoints.GenreEndpoints;

[Route("genres")]
public class GenreGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<GenreGetAllRequest>
    .WithResult<MyPagedList<GenreGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<GenreGetAllResponse>> HandleAsync([FromQuery] GenreGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Genres
            .AsQueryable();

        // Filter by search query
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(g => g.Name.Contains(request.Q));
        }

        // Project to result type
        var projectedQuery = query.Select(g => new GenreGetAllResponse
        {
            ID = g.ID,
            Name = g.Name
        });

        // Create paginated response with filter
        var result = await MyPagedList<GenreGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class GenreGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty;
    }

    public class GenreGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 