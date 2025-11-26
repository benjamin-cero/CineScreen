using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityDeleteEndpoint;

namespace CineScreen.Endpoints.CityEndpoints;

[Route("cities")]
public class CityDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CityDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] CityDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var city = await db.Cities.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (city == null)
        {
            throw new KeyNotFoundException("City not found");
        }

        db.Cities.Remove(city);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class CityDeleteRequest
    {
        public int ID { get; set; }
    }
} 