using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ManufacturerEndpoints.ManufacturerGetByIdEndpoint;

namespace CineScreen.Endpoints.ManufacturerEndpoints;

[Route("manufacturers")]
public class ManufacturerGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ManufacturerGetByIdRequest>
    .WithActionResult<ManufacturerGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<ManufacturerGetByIdResponse>> HandleAsync([FromRoute] ManufacturerGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var manufacturer = await db.Manufacturers
            .Where(m => m.ID == request.ID)
            .Select(m => new ManufacturerGetByIdResponse
            {
                ID = m.ID,
                Name = m.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (manufacturer == null)
        {
            return NotFound("Manufacturer not found");
        }

        return Ok(manufacturer);
    }

    public class ManufacturerGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class ManufacturerGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 