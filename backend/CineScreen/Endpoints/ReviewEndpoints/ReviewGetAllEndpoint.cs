using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ReviewEndpoints.ReviewGetAllEndpoint;

namespace CineScreen.Endpoints.ReviewEndpoints;

[Route("reviews")]
public class ReviewGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ReviewGetAllRequest>
    .WithResult<MyPagedList<ReviewGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<ReviewGetAllResponse>> HandleAsync([FromQuery] ReviewGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Reviews
            .Include(r => r.MyAppUser)
            .Include(r => r.Movie)
            .AsQueryable();

        // Filter by user ID
        if (request.MyAppUserID.HasValue)
        {
            query = query.Where(r => r.MyAppUserID == request.MyAppUserID.Value);
        }

        // Filter by movie ID
        if (request.MovieID.HasValue)
        {
            query = query.Where(r => r.MovieID == request.MovieID.Value);
        }

        // Filter by score range
        if (request.MinScore.HasValue)
        {
            query = query.Where(r => r.Score >= request.MinScore.Value);
        }

        if (request.MaxScore.HasValue)
        {
            query = query.Where(r => r.Score <= request.MaxScore.Value);
        }

        // Filter by date range
        if (request.FromDate.HasValue)
        {
            query = query.Where(r => r.ReviewDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(r => r.ReviewDate <= request.ToDate.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(r => new ReviewGetAllResponse
        {
            ID = r.ID,
            MyAppUserID = r.MyAppUserID,
            UserName = $"{r.MyAppUser.FirstName} {r.MyAppUser.LastName}",
            MovieID = r.MovieID,
            MovieTitle = r.Movie.Title,
            Score = r.Score,
            Comment = r.Comment,
            ReviewDate = r.ReviewDate
        });

        // Create paginated response with filter
        var result = await MyPagedList<ReviewGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class ReviewGetAllRequest : MyPagedRequest
    {
        public int? MyAppUserID { get; set; }
        public int? MovieID { get; set; }
        public int? MinScore { get; set; }
        public int? MaxScore { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class ReviewGetAllResponse
    {
        public int ID { get; set; }
        public int MyAppUserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int Score { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
    }
} 