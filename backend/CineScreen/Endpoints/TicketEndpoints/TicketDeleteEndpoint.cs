using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TicketEndpoints.TicketDeleteEndpoint;

namespace CineScreen.Endpoints.TicketEndpoints;

[Route("tickets")]
public class TicketDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TicketDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] TicketDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var ticket = await db.Tickets.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (ticket == null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }

        db.Set<Ticket>().Remove(ticket);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class TicketDeleteRequest
    {
        public int ID { get; set; }
    }
} 