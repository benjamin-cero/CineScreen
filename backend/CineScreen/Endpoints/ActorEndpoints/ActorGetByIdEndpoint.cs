using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ActorEndpoints.ActorGetByIdEndpoint;

namespace CineScreen.Endpoints.ActorEndpoints;

[Route("actors")]
public class ActorGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<ActorGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<ActorGetByIdResponse>> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var actor = await db.Actors
                            .Where(a => a.ID == id)
                            .Select(a => new ActorGetByIdResponse
                            {
                                ID = a.ID,
                                FirstName = a.FirstName,
                                LastName = a.LastName
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (actor == null)
        {
            return NotFound("Actor not found");
        }


        return Ok(actor);
    }

    public class ActorGetByIdResponse
    {
        public required int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;

    }
}
