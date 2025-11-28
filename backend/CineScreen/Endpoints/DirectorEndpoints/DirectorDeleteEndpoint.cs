using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.DirectorEndpoints.DirectorDeleteEndpoint;

namespace CineScreen.Endpoints.DirectorEndpoints;

[Route("directors")]
public class DirectorDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<DirectorDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] DirectorDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var director = await db.Directors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (director == null)
        {
            throw new KeyNotFoundException("Director not found");
        }

        db.Directors.Remove(director);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class DirectorDeleteRequest
    {
        public int ID { get; set; }
    }
} 