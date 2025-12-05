using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TicketEndpoints.TicketUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.TicketEndpoints;

[Route("tickets")]
public class TicketUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TicketUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] TicketUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Ticket? ticket;

        if (isInsert)
        {
            ticket = new Ticket();
            db.Set<Ticket>().Add(ticket);
        }
        else
        {
            ticket = await db.Tickets.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (ticket == null)
            {
                throw new KeyNotFoundException("Ticket not found");
            }
        }

        ticket.MyAppUserID = request.MyAppUserID;
        ticket.SeatID = request.SeatID;
        ticket.ProjectionID = request.ProjectionID;
        ticket.OrderDate = request.OrderDate;
        ticket.Paid = request.Paid;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class TicketUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MyAppUserID { get; set; }
        public int SeatID { get; set; }
        public int ProjectionID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
    }
} 