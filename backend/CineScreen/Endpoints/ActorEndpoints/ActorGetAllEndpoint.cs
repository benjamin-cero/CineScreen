using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ActorEndpoints.ActorGetAllEndpoint;

namespace CineScreen.Endpoints.ActorEndpoints;

//sa paging i sa filterom
[Route("actors")]
public class ActorGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ActorGetAllRequest>
    .WithResult<MyPagedList<ActorGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<ActorGetAllResponse>> HandleAsync([FromQuery] ActorGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Actors
            .AsQueryable();

        // Filter by search query
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(a => a.FirstName.Contains(request.Q) || 
                                   (a.LastName != null && a.LastName.Contains(request.Q)));
        }

        // Project to result type
        var projectedQuery = query.Select(a => new ActorGetAllResponse
        {
            ID = a.ID,
            FirstName = a.FirstName,
            LastName = a.LastName
        });

        // Create paginated response with filter
        var result = await MyPagedList<ActorGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class ActorGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty;
    }

    public class ActorGetAllResponse
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
    }
}