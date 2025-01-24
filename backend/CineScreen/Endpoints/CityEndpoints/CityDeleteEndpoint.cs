namespace RS1_2024_25.API.Endpoints.CityEndpoints;

using CineScreen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;

[MyAuthorization(isAdmin: true, isUser : false)]
[Route("cities")]
public class CityDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{

    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var city = await db.City.SingleOrDefaultAsync(x => x.CityID == id, cancellationToken);

        if (city == null)
            throw new KeyNotFoundException("City not found");

        db.City.Remove(city);
        await db.SaveChangesAsync(cancellationToken);
    }
}

