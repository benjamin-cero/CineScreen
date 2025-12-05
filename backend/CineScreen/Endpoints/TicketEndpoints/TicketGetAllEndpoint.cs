using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.TicketEndpoints.TicketGetAllEndpoint;

namespace CineScreen.Endpoints.TicketEndpoints;

[Route("tickets")]
public class TicketGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<TicketGetAllRequest>
    .WithResult<MyPagedList<TicketGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<TicketGetAllResponse>> HandleAsync([FromQuery] TicketGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Tickets
            .Include(t => t.MyAppUser)
            .Include(t => t.Seat)
            .Include(t => t.Seat.CinemaHall)
            .Include(t => t.Projection)
            .Include(t => t.Projection.Movie)
            .AsQueryable();

        // Filter by user ID
        if (request.MyAppUserID.HasValue)
        {
            query = query.Where(t => t.MyAppUserID == request.MyAppUserID.Value);
        }

        // Filter by seat ID
        if (request.SeatID.HasValue)
        {
            query = query.Where(t => t.SeatID == request.SeatID.Value);
        }

        // Filter by projection ID
        if (request.ProjectionID.HasValue)
        {
            query = query.Where(t => t.ProjectionID == request.ProjectionID.Value);
        }

        // Filter by paid status
        if (request.Paid.HasValue)
        {
            query = query.Where(t => t.Paid == request.Paid.Value);
        }

        // Filter by date range
        if (request.FromDate.HasValue)
        {
            query = query.Where(t => t.OrderDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(t => t.OrderDate <= request.ToDate.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(t => new TicketGetAllResponse
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
        });

        // Create paginated response with filter
        var result = await MyPagedList<TicketGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class TicketGetAllRequest : MyPagedRequest
    {
        public int? MyAppUserID { get; set; }
        public int? SeatID { get; set; }
        public int? ProjectionID { get; set; }
        public bool? Paid { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class TicketGetAllResponse
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