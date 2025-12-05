using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TicketEndpoints.TicketGetByIdEndpoint;

namespace CineScreen.Endpoints.TicketEndpoints;

[Route("tickets")]
public class TicketGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TicketGetByIdRequest>
    .WithActionResult<TicketGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<TicketGetByIdResponse>> HandleAsync([FromRoute] TicketGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var ticket = await db.Tickets
            .Include(t => t.MyAppUser)
            .Include(t => t.Seat)
            .Include(t => t.Seat.CinemaHall)
            .Include(t => t.Projection)
            .Include(t => t.Projection.Movie)
            .Where(t => t.ID == request.ID)
            .Select(t => new TicketGetByIdResponse
            {
                ID = t.ID,
                MyAppUserID = t.MyAppUserID,
                UserName = $"{t.MyAppUser.FirstName} {t.MyAppUser.LastName}",
                SeatID = t.SeatID,
                SeatNumber = t.Seat.SeatNumber,
                CinemaHallName = t.Seat.CinemaHall.Name,
                ProjectionID = t.ProjectionID,
                MovieTitle = t.Projection.Movie.Title,
                ProjectionStartTime = t.Projection.StartTime,
                OrderDate = t.OrderDate,
                Paid = t.Paid,
                TicketPrice = t.Projection.Price
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (ticket == null)
        {
            return NotFound("Ticket not found");
        }

        return Ok(ticket);
    }

    public class TicketGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class TicketGetByIdResponse
    {
        public int ID { get; set; }
        public int MyAppUserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int SeatID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public string CinemaHallName { get; set; } = string.Empty;
        public int ProjectionID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public DateTime ProjectionStartTime { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        public double TicketPrice { get; set; }
    }
} 