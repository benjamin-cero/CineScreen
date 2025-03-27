using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace CineScreen.Endpoints.CityEndpoints;

//bez paging i bez filtera
[Route("cities")]
public class CityGetAll1Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<CityGetAll1Response[]>
{
    [HttpGet("all")]
    public override async Task<CityGetAll1Response[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.Cities
                        .Select(c => new CityGetAll1Response
                        {
                            ID = c.ID,
                            Name = c.Name,
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class CityGetAll1Response
    {
        public required int ID { get; set; }
        public required string Name { get; set; }

    }
}