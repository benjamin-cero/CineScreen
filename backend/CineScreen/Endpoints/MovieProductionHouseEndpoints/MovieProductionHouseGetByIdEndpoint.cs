using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieProductionHouseEndpoints.MovieProductionHouseGetByIdEndpoint;

namespace CineScreen.Endpoints.MovieProductionHouseEndpoints;

[Route("movie-production-houses")]
public class MovieProductionHouseGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieProductionHouseGetByIdRequest>
    .WithActionResult<MovieProductionHouseGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MovieProductionHouseGetByIdResponse>> HandleAsync([FromRoute] MovieProductionHouseGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var movieProductionHouse = await db.MovieProductionHouses
            .Include(mph => mph.Movie)
            .Include(mph => mph.ProductionHouse)
            .Where(mph => mph.ID == request.ID)
            .Select(mph => new MovieProductionHouseGetByIdResponse
            {
                ID = mph.ID,
                MovieID = mph.MovieID,
                MovieTitle = mph.Movie.Title,
                ProductionHouseID = mph.ProductionHouseID,
                ProductionHouseName = mph.ProductionHouse.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (movieProductionHouse == null)
        {
            return NotFound("Movie production house relationship not found");
        }

        return Ok(movieProductionHouse);
    }

    public class MovieProductionHouseGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MovieProductionHouseGetByIdResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int ProductionHouseID { get; set; }
        public string ProductionHouseName { get; set; } = string.Empty;
    }
} 