using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ManufacturerEndpoints.ManufacturerUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.ManufacturerEndpoints;

[Route("manufacturers")]
public class ManufacturerUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ManufacturerUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] ManufacturerUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Manufacturer? manufacturer;

        if (isInsert)
        {
            manufacturer = new Manufacturer();
            db.Manufacturers.Add(manufacturer);
        }
        else
        {
            manufacturer = await db.Manufacturers.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (manufacturer == null)
            {
                throw new KeyNotFoundException("Manufacturer not found");
            }
        }

        manufacturer.Name = request.Name;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class ManufacturerUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 