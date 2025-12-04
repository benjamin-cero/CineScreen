using CineScreen.Data;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.SeatEndpoints.SeatUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.SeatEndpoints;

[Route("seats")]
public class SeatUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<SeatUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] SeatUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Seat? seat;

        if (isInsert)
        {
            seat = new Seat();
            db.Set<Seat>().Add(seat);
        }
        else
        {
            seat = await db.Seats.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (seat == null)
            {
                throw new KeyNotFoundException("Seat not found");
            }
        }

        seat.SeatNumber = request.SeatNumber;
        seat.CinemaHallID = request.CinemaHallID;
        seat.SeatType = request.SeatType;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class SeatUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public int CinemaHallID { get; set; }
        public SeatType SeatType { get; set; }
    }
} 