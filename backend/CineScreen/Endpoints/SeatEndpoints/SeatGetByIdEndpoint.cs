using CineScreen.Data;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.SeatEndpoints.SeatGetByIdEndpoint;

namespace CineScreen.Endpoints.SeatEndpoints;

[Route("seats")]
public class SeatGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<SeatGetByIdRequest>
    .WithActionResult<SeatGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<SeatGetByIdResponse>> HandleAsync([FromRoute] SeatGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var seat = await db.Seats
            .Include(s => s.CinemaHall)
            .Where(s => s.ID == request.ID)
            .Select(s => new SeatGetByIdResponse
            {
                ID = s.ID,
                SeatNumber = s.SeatNumber,
                CinemaHallID = s.CinemaHallID,
                CinemaHallName = s.CinemaHall.Name,
                SeatType = s.SeatType
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (seat == null)
        {
            return NotFound("Seat not found");
        }

        return Ok(seat);
    }

    public class SeatGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class SeatGetByIdResponse
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public int CinemaHallID { get; set; }
        public string CinemaHallName { get; set; } = string.Empty;
        public SeatType SeatType { get; set; }
    }
} 