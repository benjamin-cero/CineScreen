using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProjectionEndpoints.ProjectionDeleteEndpoint;

namespace CineScreen.Endpoints.ProjectionEndpoints;

[Route("projections")]
public class ProjectionDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProjectionDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] ProjectionDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var projection = await db.Projections.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (projection == null)
        {
            throw new KeyNotFoundException("Projection not found");
        }

        db.Set<Projection>().Remove(projection);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class ProjectionDeleteRequest
    {
        public int ID { get; set; }
    }
} 