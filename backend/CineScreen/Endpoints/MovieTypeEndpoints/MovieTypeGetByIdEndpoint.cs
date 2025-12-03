using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MovieTypeEndpoints.MovieTypeGetByIdEndpoint;

namespace CineScreen.Endpoints.MovieTypeEndpoints;

[Route("movie-types")]
public class MovieTypeGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MovieTypeGetByIdRequest>
    .WithActionResult<MovieTypeGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MovieTypeGetByIdResponse>> HandleAsync([FromRoute] MovieTypeGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var movieType = await db.MovieTypes
            .Where(mt => mt.ID == request.ID)
            .Select(mt => new MovieTypeGetByIdResponse
            {
                ID = mt.ID,
                Type = mt.Type
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (movieType == null)
        {
            return NotFound("Movie type not found");
        }

        return Ok(movieType);
    }

    public class MovieTypeGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MovieTypeGetByIdResponse
    {
        public int ID { get; set; }
        public string Type { get; set; } = string.Empty;
    }
} 