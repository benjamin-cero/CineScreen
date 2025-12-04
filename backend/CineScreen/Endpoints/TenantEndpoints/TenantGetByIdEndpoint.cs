using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TenantEndpoints.TenantGetByIdEndpoint;

namespace CineScreen.Endpoints.TenantEndpoints;

[Route("tenants")]
public class TenantGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TenantGetByIdRequest>
    .WithActionResult<TenantGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<TenantGetByIdResponse>> HandleAsync([FromRoute] TenantGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var tenant = await db.Tenants
            .Where(t => t.ID == request.ID)
            .Select(t => new TenantGetByIdResponse
            {
                ID = t.ID,
                Name = t.Name,
                DatabaseConnection = t.DatabaseConnection,
                ServerAddress = t.ServerAddress
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (tenant == null)
        {
            return NotFound("Tenant not found");
        }

        return Ok(tenant);
    }

    public class TenantGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class TenantGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DatabaseConnection { get; set; } = string.Empty;
        public string ServerAddress { get; set; } = string.Empty;
    }
} 