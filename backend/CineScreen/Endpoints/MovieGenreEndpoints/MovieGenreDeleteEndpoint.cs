using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieGenreEndpoints.MovieGenreDeleteEndpoint;

namespace CineScreen.Endpoints.MovieGenreEndpoints;

[Route("movie-genres")]
public class MovieGenreDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieGenreDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MovieGenreDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var movieGenre = await db.MovieGenres.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (movieGenre == null)
        {
            throw new KeyNotFoundException("Movie genre relationship not found");
        }

        db.MovieGenres.Remove(movieGenre);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieGenreDeleteRequest
    {
        public int ID { get; set; }
    }
} 