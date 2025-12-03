using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProductionHouseEndpoints.ProductionHouseGetByIdEndpoint;

namespace CineScreen.Endpoints.ProductionHouseEndpoints;

[Route("production-houses")]
public class ProductionHouseGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProductionHouseGetByIdRequest>
    .WithActionResult<ProductionHouseGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<ProductionHouseGetByIdResponse>> HandleAsync([FromRoute] ProductionHouseGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var productionHouse = await db.ProductionHouses
            .Where(ph => ph.ID == request.ID)
            .Select(ph => new ProductionHouseGetByIdResponse
            {
                ID = ph.ID,
                Name = ph.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (productionHouse == null)
        {
            return NotFound("Production house not found");
        }

        return Ok(productionHouse);
    }

    public class ProductionHouseGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class ProductionHouseGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 