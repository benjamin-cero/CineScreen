using CineScreen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Helper.Api;
using static CineScreen.Endpoints.CityEndpoints.CityGetByIdEndpoint;

namespace CineScreen.Endpoints.CityEndpoints;

[Route("cities")]
public class CityGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<CityGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<CityGetByIdResponse> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var city = await db.City
                            .Where(c => c.CityID == id)
                            .Select(c => new CityGetByIdResponse
                            {
                                CityID = c.CityID,
                                Name = c.Name,
                            })
                            .FirstOrDefaultAsync(x => x.CityID == id, cancellationToken);

        if (city == null)
            throw new KeyNotFoundException("City not found");

        return city;
    }

    public class CityGetByIdResponse
    {
        public required int CityID { get; set; }
        public required string Name { get; set; }
    }
}
