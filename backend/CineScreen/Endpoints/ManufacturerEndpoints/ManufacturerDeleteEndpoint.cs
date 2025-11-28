using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ManufacturerEndpoints.ManufacturerDeleteEndpoint;

namespace CineScreen.Endpoints.ManufacturerEndpoints;

[Route("manufacturers")]
public class ManufacturerDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ManufacturerDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] ManufacturerDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var manufacturer = await db.Manufacturers.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (manufacturer == null)
        {
            throw new KeyNotFoundException("Manufacturer not found");
        }

        db.Set<Manufacturer>().Remove(manufacturer);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class ManufacturerDeleteRequest
    {
        public int ID { get; set; }
    }
} 