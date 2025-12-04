using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.SeatEndpoints.SeatDeleteEndpoint;

namespace CineScreen.Endpoints.SeatEndpoints;

[Route("seats")]
public class SeatDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<SeatDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] SeatDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var seat = await db.Seats.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (seat == null)
        {
            throw new KeyNotFoundException("Seat not found");
        }

        db.Set<Seat>().Remove(seat);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class SeatDeleteRequest
    {
        public int ID { get; set; }
    }
} 