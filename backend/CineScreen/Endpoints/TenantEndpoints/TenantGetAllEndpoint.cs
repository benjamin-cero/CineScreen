using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TenantEndpoints.TenantGetAllEndpoint;

namespace CineScreen.Endpoints.TenantEndpoints;

[Route("tenants")]
public class TenantGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TenantGetAllRequest>
    .WithResult<MyPagedList<TenantGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<TenantGetAllResponse>> HandleAsync([FromQuery] TenantGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Tenants.AsQueryable();

        // Filter by name
        if (!string.IsNullOrEmpty(request.Q))
        {
            query = query.Where(t => t.Name.Contains(request.Q));
        }

        // Project to result type
        var projectedQuery = query.Select(t => new TenantGetAllResponse
        {
            ID = t.ID,
            Name = t.Name,
            DatabaseConnection = t.DatabaseConnection,
            ServerAddress = t.ServerAddress
        });

        // Create paginated response with filter
        var result = await MyPagedList<TenantGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class TenantGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; }
    }

    public class TenantGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DatabaseConnection { get; set; } = string.Empty;
        public string ServerAddress { get; set; } = string.Empty;
    }
} 