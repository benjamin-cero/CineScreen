using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityGetByIdEndpoint;

namespace CineScreen.Endpoints.CityEndpoints;

[Route("cities")]
public class CityGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<CityGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<CityGetByIdResponse>> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var city = await db.Cities
                            .Where(c => c.ID == id)
                            .Select(c => new CityGetByIdResponse
                            {
                                ID = c.ID,
                                Name = c.Name
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (city == null)
        {
            return NotFound("City not found");
        }


        return Ok(city);
    }

    public class CityGetByIdResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }

    }
}
