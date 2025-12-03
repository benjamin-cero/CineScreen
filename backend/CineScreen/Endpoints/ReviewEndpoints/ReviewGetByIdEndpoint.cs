using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ReviewEndpoints.ReviewGetByIdEndpoint;

namespace CineScreen.Endpoints.ReviewEndpoints;

[Route("reviews")]
public class ReviewGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ReviewGetByIdRequest>
    .WithActionResult<ReviewGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<ReviewGetByIdResponse>> HandleAsync([FromRoute] ReviewGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var review = await db.Reviews
            .Include(r => r.MyAppUser)
            .Include(r => r.Movie)
            .Where(r => r.ID == request.ID)
            .Select(r => new ReviewGetByIdResponse
            {
                ID = r.ID,
                MyAppUserID = r.MyAppUserID,
                UserName = $"{r.MyAppUser.FirstName} {r.MyAppUser.LastName}",
                MovieID = r.MovieID,
                MovieTitle = r.Movie.Title,
                Score = r.Score,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (review == null)
        {
            return NotFound("Review not found");
        }

        return Ok(review);
    }

    public class ReviewGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class ReviewGetByIdResponse
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