using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieEndpoints.MovieUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MovieEndpoints;

[Route("movies")]
public class MovieUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MovieUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Movie? movie;

        if (isInsert)
        {
            movie = new Movie();
            db.Movies.Add(movie);
        }
        else
        {
            movie = await db.Movies.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (movie == null)
            {
                throw new KeyNotFoundException("Movie not found");
            }
        }

        movie.Title = request.Title;
        movie.ReleaseDate = request.ReleaseDate;
        movie.Description = request.Description;
        movie.Duration = request.Duration;
        movie.Trailer = request.Trailer;
        movie.Poster = request.Poster;
        movie.Status = request.Status;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string? Trailer { get; set; }
        public byte[]? Poster { get; set; }
        public Status Status { get; set; }
    }
} 