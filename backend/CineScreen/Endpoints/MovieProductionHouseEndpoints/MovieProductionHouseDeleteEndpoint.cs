using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieProductionHouseEndpoints.MovieProductionHouseDeleteEndpoint;

namespace CineScreen.Endpoints.MovieProductionHouseEndpoints;

[Route("movie-production-houses")]
public class MovieProductionHouseDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieProductionHouseDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MovieProductionHouseDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var movieProductionHouse = await db.MovieProductionHouses.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (movieProductionHouse == null)
        {
            throw new KeyNotFoundException("Movie production house relationship not found");
        }

        db.MovieProductionHouses.Remove(movieProductionHouse);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieProductionHouseDeleteRequest
    {
        public int ID { get; set; }
    }
} 