using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProductionHouseEndpoints.ProductionHouseGetAllEndpoint;

namespace CineScreen.Endpoints.ProductionHouseEndpoints;

[Route("production-houses")]
public class ProductionHouseGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProductionHouseGetAllRequest>
    .WithResult<MyPagedList<ProductionHouseGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<ProductionHouseGetAllResponse>> HandleAsync([FromQuery] ProductionHouseGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.ProductionHouses
            .AsQueryable();

        // Filter by search query
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(ph => ph.Name.Contains(request.Q));
        }

        // Project to result type
        var projectedQuery = query.Select(ph => new ProductionHouseGetAllResponse
        {
            ID = ph.ID,
            Name = ph.Name
        });

        // Create paginated response with filter
        var result = await MyPagedList<ProductionHouseGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class ProductionHouseGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty;
    }

    public class ProductionHouseGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 