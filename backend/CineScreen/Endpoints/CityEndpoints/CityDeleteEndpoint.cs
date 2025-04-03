
using CineScreen.Data;
using CineScreen.Helper.Api;
using CineScreen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineScreen.Endpoints.CityEndpoints;

[MyAuthorization(isAdmin: true, isUser: false)]
[Route("cities")]
public class CityDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
   
    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var city = await db.Cities.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (city == null)
            throw new KeyNotFoundException("City not found");



        db.Cities.Remove(city);
        await db.SaveChangesAsync(cancellationToken);
    }
}

