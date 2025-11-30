using CineScreen.Data;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieEndpoints.MovieGetByIdEndpoint;

namespace CineScreen.Endpoints.MovieEndpoints;

[Route("movies")]
public class MovieGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieGetByIdRequest>
    .WithActionResult<MovieGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MovieGetByIdResponse>> HandleAsync([FromRoute] MovieGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var movie = await db.Movies
            .Where(m => m.ID == request.ID)
            .Select(m => new MovieGetByIdResponse
            {
                ID = m.ID,
                Title = m.Title,
                ReleaseDate = m.ReleaseDate,
                Description = m.Description,
                Duration = m.Duration,
                Trailer = m.Trailer,
                Poster = m.Poster,
                Status = m.Status
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (movie == null)
        {
            return NotFound("Movie not found");
        }

        return Ok(movie);
    }

    public class MovieGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MovieGetByIdResponse
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string? Trailer { get; set; }
        public byte[]? Poster { get; set; }
        public Status Status { get; set; }
    }
} 