using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieGenreEndpoints.MovieGenreGetByIdEndpoint;

namespace CineScreen.Endpoints.MovieGenreEndpoints;

[Route("movie-genres")]
public class MovieGenreGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieGenreGetByIdRequest>
    .WithActionResult<MovieGenreGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MovieGenreGetByIdResponse>> HandleAsync([FromRoute] MovieGenreGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var movieGenre = await db.MovieGenres
            .Include(mg => mg.Movie)
            .Include(mg => mg.Genre)
            .Where(mg => mg.ID == request.ID)
            .Select(mg => new MovieGenreGetByIdResponse
            {
                ID = mg.ID,
                MovieID = mg.MovieID,
                MovieTitle = mg.Movie.Title,
                GenreID = mg.GenreID,
                GenreName = mg.Genre.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (movieGenre == null)
        {
            return NotFound("Movie genre relationship not found");
        }

        return Ok(movieGenre);
    }

    public class MovieGenreGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MovieGenreGetByIdResponse
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int GenreID { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
} 