using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieActorEndpoints.MovieActorDeleteEndpoint;

namespace CineScreen.Endpoints.MovieActorEndpoints;

[Route("movie-actors")]
public class MovieActorDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieActorDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MovieActorDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var movieActor = await db.MovieActors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (movieActor == null)
        {
            throw new KeyNotFoundException("Movie actor relationship not found");
        }

        db.MovieActors.Remove(movieActor);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieActorDeleteRequest
    {
        public int ID { get; set; }
    }
} 