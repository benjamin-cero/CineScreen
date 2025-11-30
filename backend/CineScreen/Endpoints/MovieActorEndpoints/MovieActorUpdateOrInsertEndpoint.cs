using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieActorEndpoints.MovieActorUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MovieActorEndpoints;

[Route("movie-actors")]
public class MovieActorUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieActorUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MovieActorUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        MovieActor? movieActor;

        if (isInsert)
        {
            movieActor = new MovieActor();
            db.MovieActors.Add(movieActor);
        }
        else
        {
            movieActor = await db.MovieActors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (movieActor == null)
            {
                throw new KeyNotFoundException("Movie actor relationship not found");
            }
        }

        movieActor.MovieID = request.MovieID;
        movieActor.ActorID = request.ActorID;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MovieActorUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MovieID { get; set; }
        public int ActorID { get; set; }
    }
} 