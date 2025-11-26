using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.CityEndpoints;

[Route("cities")]
public class CityUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CityUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] CityUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        City? city;

        if (isInsert)
        {
            city = new City();
            db.Cities.Add(city);
        }
        else
        {
            city = await db.Cities.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (city == null)
            {
                throw new KeyNotFoundException("City not found");
            }
        }

        city.Name = request.Name;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class CityUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 