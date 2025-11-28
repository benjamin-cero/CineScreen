using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.GenreEndpoints.GenreGetByIdEndpoint;

namespace CineScreen.Endpoints.GenreEndpoints;

[Route("genres")]
public class GenreGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<GenreGetByIdRequest>
    .WithActionResult<GenreGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<GenreGetByIdResponse>> HandleAsync([FromRoute] GenreGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var genre = await db.Genres
            .Where(g => g.ID == request.ID)
            .Select(g => new GenreGetByIdResponse
            {
                ID = g.ID,
                Name = g.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (genre == null)
        {
            return NotFound("Genre not found");
        }

        return Ok(genre);
    }

    public class GenreGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class GenreGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 