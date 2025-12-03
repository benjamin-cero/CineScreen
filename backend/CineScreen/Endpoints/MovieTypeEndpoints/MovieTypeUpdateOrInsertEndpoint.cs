using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieTypeEndpoints.MovieTypeUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MovieTypeEndpoints;

[Route("movie-types")]
public class MovieTypeUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieTypeUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MovieTypeUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        MovieType? movieType;

        if (isInsert)
        {
            movieType = new MovieType();
            db.MovieTypes.Add(movieType);
        }
        else
        {
            movieType = await db.MovieTypes.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (movieType == null)
            {
                throw new KeyNotFoundException("Movie type not found");
            }
        }

        movieType.Type = request.Type;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieTypeUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Type { get; set; } = string.Empty;
    }
} 