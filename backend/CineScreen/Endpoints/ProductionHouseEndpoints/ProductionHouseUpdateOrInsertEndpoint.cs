using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProductionHouseEndpoints.ProductionHouseUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.ProductionHouseEndpoints;

[Route("production-houses")]
public class ProductionHouseUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProductionHouseUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] ProductionHouseUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        ProductionHouse? productionHouse;

        if (isInsert)
        {
            productionHouse = new ProductionHouse();
            db.ProductionHouses.Add(productionHouse);
        }
        else
        {
            productionHouse = await db.ProductionHouses.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (productionHouse == null)
            {
                throw new KeyNotFoundException("Production house not found");
            }
        }

        productionHouse.Name = request.Name;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class ProductionHouseUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 