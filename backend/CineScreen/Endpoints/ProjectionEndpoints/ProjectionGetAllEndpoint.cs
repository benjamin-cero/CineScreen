using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProjectionEndpoints.ProjectionGetAllEndpoint;

namespace CineScreen.Endpoints.ProjectionEndpoints;

[Route("projections")]
public class ProjectionGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProjectionGetAllRequest>
    .WithResult<MyPagedList<ProjectionGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<ProjectionGetAllResponse>> HandleAsync([FromQuery] ProjectionGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Projections
            .Include(p => p.Movie)
            .Include(p => p.CinemaHall)
            .Include(p => p.MovieType)
            .AsQueryable();

        // Filter by movie ID
        if (request.MovieID.HasValue)
        {
            query = query.Where(p => p.MovieID == request.MovieID.Value);
        }

        // Filter by cinema hall ID
        if (request.CinemaHallID.HasValue)
        {
            query = query.Where(p => p.CinemaHallID == request.CinemaHallID.Value);
        }

        // Filter by movie type ID
        if (request.MovieTypeID.HasValue)
        {
            query = query.Where(p => p.MovieTypeID == request.MovieTypeID.Value);
        }

        // Filter by price range
        if (request.MinPrice.HasValue)
        {
            query = query.Where(p => p.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= request.MaxPrice.Value);
        }

        // Filter by date range
        if (request.FromDate.HasValue)
        {
            query = query.Where(p => p.StartTime >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(p => p.StartTime <= request.ToDate.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(p => new ProjectionGetAllResponse
        {
            ID = p.ID,
            StartTime = p.StartTime,
            Price = p.Price,
            MovieID = p.MovieID,
            MovieTitle = p.Movie.Title,
            CinemaHallID = p.CinemaHallID,
            CinemaHallName = p.CinemaHall.Name,
            MovieTypeID = p.MovieTypeID,
            MovieTypeName = p.MovieType.Type
        });

        // Create paginated response with filter
        var result = await MyPagedList<ProjectionGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class ProjectionGetAllRequest : MyPagedRequest
    {
        public int? MovieID { get; set; }
        public int? CinemaHallID { get; set; }
        public int? MovieTypeID { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class ProjectionGetAllResponse
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public double Price { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int CinemaHallID { get; set; }
        public string CinemaHallName { get; set; } = string.Empty;
        public int MovieTypeID { get; set; }
        public string MovieTypeName { get; set; } = string.Empty;
    }
} 