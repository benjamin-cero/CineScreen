using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieDirectorEndpoints.MovieDirectorUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MovieDirectorEndpoints;

[Route("movie-directors")]
public class MovieDirectorUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieDirectorUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MovieDirectorUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        MovieDirector? movieDirector;

        if (isInsert)
        {
            movieDirector = new MovieDirector();
            db.MovieDirectors.Add(movieDirector);
        }
        else
        {
            movieDirector = await db.MovieDirectors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (movieDirector == null)
            {
                throw new KeyNotFoundException("Movie director relationship not found");
            }
        }

        movieDirector.MovieID = request.MovieID;
        movieDirector.DirectorID = request.DirectorID;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieDirectorUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MovieID { get; set; }
        public int DirectorID { get; set; }
    }
} 