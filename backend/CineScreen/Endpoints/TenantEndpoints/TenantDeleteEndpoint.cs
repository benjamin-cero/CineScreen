using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TenantEndpoints.TenantDeleteEndpoint;

namespace CineScreen.Endpoints.TenantEndpoints;

[Route("tenants")]
public class TenantDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TenantDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] TenantDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var tenant = await db.Tenants.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (tenant == null)
        {
            throw new KeyNotFoundException("Tenant not found");
        }

        db.Tenants.Remove(tenant);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class TenantDeleteRequest
    {
        public int ID { get; set; }
    }
} 