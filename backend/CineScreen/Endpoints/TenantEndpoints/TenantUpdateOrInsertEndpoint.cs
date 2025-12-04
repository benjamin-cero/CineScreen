using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TenantEndpoints.TenantUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.TenantEndpoints;

[Route("tenants")]
public class TenantUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TenantUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] TenantUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Tenant? tenant;

        if (isInsert)
        {
            tenant = new Tenant();
            db.Tenants.Add(tenant);
        }
        else
        {
            tenant = await db.Tenants.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (tenant == null)
            {
                throw new KeyNotFoundException("Tenant not found");
            }
        }

        tenant.Name = request.Name;
        tenant.DatabaseConnection = request.DatabaseConnection;
        tenant.ServerAddress = request.ServerAddress;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class TenantUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DatabaseConnection { get; set; } = string.Empty;
        public string ServerAddress { get; set; } = string.Empty;
    }
} 