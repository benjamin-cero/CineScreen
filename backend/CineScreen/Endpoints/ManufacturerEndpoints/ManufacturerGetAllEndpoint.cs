using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ManufacturerEndpoints.ManufacturerGetAllEndpoint;

namespace CineScreen.Endpoints.ManufacturerEndpoints;

[Route("manufacturers")]
public class ManufacturerGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ManufacturerGetAllRequest>
    .WithResult<MyPagedList<ManufacturerGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<ManufacturerGetAllResponse>> HandleAsync([FromQuery] ManufacturerGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Manufacturers.AsQueryable();

        // Filter by name
        if (!string.IsNullOrEmpty(request.Q))
        {
            query = query.Where(m => m.Name.Contains(request.Q));
        }

        // Project to result type
        var projectedQuery = query.Select(m => new ManufacturerGetAllResponse
        {
            ID = m.ID,
            Name = m.Name
        });

        // Create paginated response with filter
        var result = await MyPagedList<ManufacturerGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class ManufacturerGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; }
    }

    public class ManufacturerGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 