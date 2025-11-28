using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.DirectorEndpoints.DirectorGetByIdEndpoint;

namespace CineScreen.Endpoints.DirectorEndpoints;

[Route("directors")]
public class DirectorGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<DirectorGetByIdRequest>
    .WithActionResult<DirectorGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<DirectorGetByIdResponse>> HandleAsync([FromRoute] DirectorGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var director = await db.Directors
            .Where(d => d.ID == request.ID)
            .Select(d => new DirectorGetByIdResponse
            {
                ID = d.ID,
                FirstName = d.FirstName,
                LastName = d.LastName
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (director == null)
        {
            return NotFound("Director not found");
        }

        return Ok(director);
    }

    public class DirectorGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class DirectorGetByIdResponse
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
} 