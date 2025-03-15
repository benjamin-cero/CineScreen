using CineScreen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//bez paging i bez filtera
[MyAuthorization(isAdmin: true, isUser: false)]
[Route("cities")]
public class CityGetAll1Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<CityGetAll1Response[]>
{
    [HttpGet("all")]
    public override async Task<CityGetAll1Response[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.City
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