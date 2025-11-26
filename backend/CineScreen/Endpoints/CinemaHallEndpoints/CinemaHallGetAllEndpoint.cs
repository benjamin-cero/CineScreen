using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CinemaHallEndpoints.CinemaHallGetAllEndpoint;

namespace CineScreen.Endpoints.CinemaHallEndpoints;

[Route("cinema-halls")]
public class CinemaHallGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CinemaHallGetAllRequest>
    .WithResult<MyPagedList<CinemaHallGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<CinemaHallGetAllResponse>> HandleAsync([FromQuery] CinemaHallGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.CinemaHalls
            .AsQueryable();

        // Filter by search query
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(ch => ch.Name.Contains(request.Q));
        }

        // Filter by minimum capacity
        if (request.MinCapacity.HasValue)
        {
            query = query.Where(ch => ch.Capacity >= request.MinCapacity.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(ch => new CinemaHallGetAllResponse
        {
            ID = ch.ID,
            Name = ch.Name,
            Capacity = ch.Capacity
        });

        // Create paginated response with filter
        var result = await MyPagedList<CinemaHallGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class CinemaHallGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty;
        public int? MinCapacity { get; set; }
    }

    public class CinemaHallGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
} 