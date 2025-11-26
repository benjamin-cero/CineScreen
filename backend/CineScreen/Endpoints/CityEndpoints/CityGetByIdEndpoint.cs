using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityGetByIdEndpoint;

namespace CineScreen.Endpoints.CityEndpoints;

[Route("cities")]
public class CityGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CityGetByIdRequest>
    .WithActionResult<CityGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<CityGetByIdResponse>> HandleAsync([FromRoute] CityGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var city = await db.Cities
            .Where(c => c.ID == request.ID)
            .Select(c => new CityGetByIdResponse
            {
                ID = c.ID,
                Name = c.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (city == null)
        {
            return NotFound("City not found");
        }

        return Ok(city);
    }

    public class CityGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class CityGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 