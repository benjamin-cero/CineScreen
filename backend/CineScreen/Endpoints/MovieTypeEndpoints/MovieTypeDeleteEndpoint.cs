using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieTypeEndpoints.MovieTypeDeleteEndpoint;

namespace CineScreen.Endpoints.MovieTypeEndpoints;

[Route("movie-types")]
public class MovieTypeDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieTypeDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MovieTypeDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var movieType = await db.MovieTypes.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (movieType == null)
        {
            throw new KeyNotFoundException("Movie type not found");
        }

        db.MovieTypes.Remove(movieType);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieTypeDeleteRequest
    {
        public int ID { get; set; }
    }
} 