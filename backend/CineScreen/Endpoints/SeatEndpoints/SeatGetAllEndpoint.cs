using CineScreen.Data;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.SeatEndpoints.SeatGetAllEndpoint;

namespace CineScreen.Endpoints.SeatEndpoints;

[Route("seats")]
public class SeatGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<SeatGetAllRequest>
    .WithResult<MyPagedList<SeatGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<SeatGetAllResponse>> HandleAsync([FromQuery] SeatGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Seats
            .Include(s => s.CinemaHall)
            .AsQueryable();

        // Filter by cinema hall ID
        if (request.CinemaHallID.HasValue)
        {
            query = query.Where(s => s.CinemaHallID == request.CinemaHallID.Value);
        }

        // Filter by seat type
        if (request.SeatType.HasValue)
        {
            query = query.Where(s => s.SeatType == request.SeatType.Value);
        }

        // Filter by seat number
        if (!string.IsNullOrEmpty(request.SeatNumber))
        {
            query = query.Where(s => s.SeatNumber.Contains(request.SeatNumber));
        }

        // Project to result type
        var projectedQuery = query.Select(s => new SeatGetAllResponse
        {
            ID = s.ID,
            SeatNumber = s.SeatNumber,
            CinemaHallID = s.CinemaHallID,
            CinemaHallName = s.CinemaHall.Name,
            SeatType = s.SeatType
        });

        // Create paginated response with filter
        var result = await MyPagedList<SeatGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class SeatGetAllRequest : MyPagedRequest
    {
        public int? CinemaHallID { get; set; }
        public SeatType? SeatType { get; set; }
        public string? SeatNumber { get; set; }
    }

    public class SeatGetAllResponse
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public int CinemaHallID { get; set; }
        public string CinemaHallName { get; set; } = string.Empty;
        public SeatType SeatType { get; set; }
    }
} 