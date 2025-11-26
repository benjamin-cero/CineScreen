using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CinemaHallEndpoints.CinemaHallGetByIdEndpoint;

namespace CineScreen.Endpoints.CinemaHallEndpoints;

[Route("cinema-halls")]
public class CinemaHallGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<CinemaHallGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<CinemaHallGetByIdResponse>> HandleAsync([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var cinemaHall = await db.CinemaHalls
            .Where(ch => ch.ID == id)
            .Select(ch => new CinemaHallGetByIdResponse
            {
                ID = ch.ID,
                Name = ch.Name,
                Capacity = ch.Capacity
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (cinemaHall == null)
        {
            return NotFound("Cinema hall not found");
        }

        return Ok(cinemaHall);
    }


    public class CinemaHallGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
} 