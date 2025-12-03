using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ReviewEndpoints.ReviewDeleteEndpoint;

namespace CineScreen.Endpoints.ReviewEndpoints;

[Route("reviews")]
public class ReviewDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ReviewDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] ReviewDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var review = await db.Reviews.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (review == null)
        {
            throw new KeyNotFoundException("Review not found");
        }

        db.Set<Review>().Remove(review);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class ReviewDeleteRequest
    {
        public int ID { get; set; }
    }
} 