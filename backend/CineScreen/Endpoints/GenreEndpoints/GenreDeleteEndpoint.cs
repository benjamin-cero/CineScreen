using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.GenreEndpoints.GenreDeleteEndpoint;

namespace CineScreen.Endpoints.GenreEndpoints;

[Route("genres")]
public class GenreDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<GenreDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] GenreDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var genre = await db.Genres.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (genre == null)
        {
            throw new KeyNotFoundException("Genre not found");
        }

        db.Genres.Remove(genre);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class GenreDeleteRequest
    {
        public int ID { get; set; }
    }
} 