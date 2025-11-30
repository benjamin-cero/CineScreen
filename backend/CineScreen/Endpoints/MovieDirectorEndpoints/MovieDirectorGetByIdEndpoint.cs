using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieDirectorEndpoints.MovieDirectorGetByIdEndpoint;

namespace CineScreen.Endpoints.MovieDirectorEndpoints;

[Route("movie-directors")]
public class MovieDirectorGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieDirectorGetByIdRequest>
    .WithActionResult<MovieDirectorGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MovieDirectorGetByIdResponse>> HandleAsync([FromRoute] MovieDirectorGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var movieDirector = await db.MovieDirectors
            .Include(md => md.Movie)
            .Include(md => md.Director)
            .Where(md => md.ID == request.ID)
            .Select(md => new MovieDirectorGetByIdResponse
            {
                ID = md.ID,
                MovieID = md.MovieID,
                MovieTitle = md.Movie.Title,
                DirectorID = md.DirectorID,
                DirectorName = $"{md.Director.FirstName} {md.Director.LastName}"
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (movieDirector == null)
        {
            return NotFound("Movie director relationship not found");
        }

        return Ok(movieDirector);
    }

    public class MovieDirectorGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MovieDirectorGetByIdResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int DirectorID { get; set; }
        public string DirectorName { get; set; } = string.Empty;
    }
} 