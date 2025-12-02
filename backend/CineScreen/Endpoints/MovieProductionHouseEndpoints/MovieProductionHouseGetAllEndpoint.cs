using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieProductionHouseEndpoints.MovieProductionHouseGetAllEndpoint;

namespace CineScreen.Endpoints.MovieProductionHouseEndpoints;

[Route("movie-production-houses")]
public class MovieProductionHouseGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieProductionHouseGetAllRequest>
    .WithResult<MyPagedList<MovieProductionHouseGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MovieProductionHouseGetAllResponse>> HandleAsync([FromQuery] MovieProductionHouseGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.MovieProductionHouses
            .Include(mph => mph.Movie)
            .Include(mph => mph.ProductionHouse)
            .AsQueryable();

        // Filter by movie ID
        if (request.MovieID.HasValue)
        {
            query = query.Where(mph => mph.MovieID == request.MovieID.Value);
        }

        // Filter by production house ID
        if (request.ProductionHouseID.HasValue)
        {
            query = query.Where(mph => mph.ProductionHouseID == request.ProductionHouseID.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(mph => new MovieProductionHouseGetAllResponse
        {
            ID = mph.ID,
            MovieID = mph.MovieID,
            MovieTitle = mph.Movie.Title,
            ProductionHouseID = mph.ProductionHouseID,
            ProductionHouseName = mph.ProductionHouse.Name
        });

        // Create paginated response with filter
        var result = await MyPagedList<MovieProductionHouseGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MovieProductionHouseGetAllRequest : MyPagedRequest
    {
        public int? MovieID { get; set; }
        public int? ProductionHouseID { get; set; }
    }

    public class MovieProductionHouseGetAllResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int ProductionHouseID { get; set; }
        public string ProductionHouseName { get; set; } = string.Empty;
    }
} 