using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.GenreEndpoints.GenreUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.GenreEndpoints;

[Route("genres")]
public class GenreUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<GenreUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] GenreUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Genre? genre;

        if (isInsert)
        {
            genre = new Genre();
            db.Genres.Add(genre);
        }
        else
        {
            genre = await db.Genres.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (genre == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
        }

        genre.Name = request.Name;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class GenreUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 