using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CinemaHallEndpoints.CinemaHallDeleteEndpoint;

namespace CineScreen.Endpoints.CinemaHallEndpoints;

[Route("cinema-halls")]
public class CinemaHallDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CinemaHallDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] CinemaHallDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var cinemaHall = await db.CinemaHalls.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (cinemaHall == null)
        {
            throw new KeyNotFoundException("Cinema hall not found");
        }

        db.Set<CinemaHall>().Remove(cinemaHall);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class CinemaHallDeleteRequest
    {
        public int ID { get; set; }
    }
} 