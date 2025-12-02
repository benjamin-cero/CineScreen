using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieProductionHouseEndpoints.MovieProductionHouseUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MovieProductionHouseEndpoints;

[Route("movie-production-houses")]
public class MovieProductionHouseUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieProductionHouseUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MovieProductionHouseUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        MovieProductionHouse? movieProductionHouse;

        if (isInsert)
        {
            movieProductionHouse = new MovieProductionHouse();
            db.MovieProductionHouses.Add(movieProductionHouse);
        }
        else
        {
            movieProductionHouse = await db.MovieProductionHouses.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (movieProductionHouse == null)
            {
                throw new KeyNotFoundException("Movie production house relationship not found");
            }
        }

        movieProductionHouse.MovieID = request.MovieID;
        movieProductionHouse.ProductionHouseID = request.ProductionHouseID;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieProductionHouseUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MovieID { get; set; }
        public int ProductionHouseID { get; set; }
    }
} 