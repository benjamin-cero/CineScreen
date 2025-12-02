using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieGenreEndpoints.MovieGenreUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MovieGenreEndpoints;

[Route("movie-genres")]
public class MovieGenreUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieGenreUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MovieGenreUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        MovieGenre? movieGenre;

        if (isInsert)
        {
            movieGenre = new MovieGenre();
            db.MovieGenres.Add(movieGenre);
        }
        else
        {
            movieGenre = await db.MovieGenres.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (movieGenre == null)
            {
                throw new KeyNotFoundException("Movie genre relationship not found");
            }
        }

        movieGenre.MovieID = request.MovieID;
        movieGenre.GenreID = request.GenreID;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieGenreUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }
    }
} 