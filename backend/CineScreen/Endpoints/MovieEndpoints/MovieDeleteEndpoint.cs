using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieEndpoints.MovieDeleteEndpoint;

namespace CineScreen.Endpoints.MovieEndpoints;

[Route("movies")]
public class MovieDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MovieDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var movie = await db.Movies.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (movie == null)
        {
            throw new KeyNotFoundException("Movie not found");
        }

        db.Movies.Remove(movie);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieDeleteRequest
    {
        public int ID { get; set; }
    }
} 