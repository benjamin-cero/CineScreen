using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CinemaHallEndpoints.CinemaHallUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.CinemaHallEndpoints;

[Route("cinema-halls")]
public class CinemaHallUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CinemaHallUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] CinemaHallUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        CinemaHall? cinemaHall;

        if (isInsert)
        {
            cinemaHall = new CinemaHall();
            db.Set<CinemaHall>().Add(cinemaHall);
        }
        else
        {
            cinemaHall = await db.CinemaHalls.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (cinemaHall == null)
            {
                throw new KeyNotFoundException("Cinema hall not found");
            }
        }

        cinemaHall.Name = request.Name;
        cinemaHall.Capacity = request.Capacity;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class CinemaHallUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
} 