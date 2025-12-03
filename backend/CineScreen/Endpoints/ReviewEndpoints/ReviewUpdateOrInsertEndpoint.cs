using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ReviewEndpoints.ReviewUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.ReviewEndpoints;

[Route("reviews")]
public class ReviewUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ReviewUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] ReviewUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Review? review;

        if (isInsert)
        {
            review = new Review();
            db.Set<Review>().Add(review);
        }
        else
        {
            review = await db.Reviews.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (review == null)
            {
                throw new KeyNotFoundException("Review not found");
            }
        }

        review.MyAppUserID = request.MyAppUserID;
        review.MovieID = request.MovieID;
        review.Score = request.Score;
        review.Comment = request.Comment;
        review.ReviewDate = request.ReviewDate;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class ReviewUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MyAppUserID { get; set; }
        public int MovieID { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
    }
} 