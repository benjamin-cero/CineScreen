using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProductionHouseEndpoints.ProductionHouseDeleteEndpoint;

namespace CineScreen.Endpoints.ProductionHouseEndpoints;

[Route("production-houses")]
public class ProductionHouseDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProductionHouseDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] ProductionHouseDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var productionHouse = await db.ProductionHouses.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (productionHouse == null)
        {
            throw new KeyNotFoundException("Production house not found");
        }

        db.ProductionHouses.Remove(productionHouse);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class ProductionHouseDeleteRequest
    {
        public int ID { get; set; }
    }
} 