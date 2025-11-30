using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieDirectorEndpoints.MovieDirectorDeleteEndpoint;

namespace CineScreen.Endpoints.MovieDirectorEndpoints;

[Route("movie-directors")]
public class MovieDirectorDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieDirectorDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MovieDirectorDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var movieDirector = await db.MovieDirectors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (movieDirector == null)
        {
            throw new KeyNotFoundException("Movie director relationship not found");
        }

        db.MovieDirectors.Remove(movieDirector);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieDirectorDeleteRequest
    {
        public int ID { get; set; }
    }
} 