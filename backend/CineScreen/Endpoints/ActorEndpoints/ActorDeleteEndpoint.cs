namespace RS1_2024_25.API.Endpoints.ActorEndpoints;

using CineScreen.Data;
using CineScreen.Helper.Api;
using CineScreen.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

//[MyAuthorization(isAdmin: true, isUser: false)]
[Route("actors")]
public class ActorDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{

    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var actor = await db.Actors.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (actor == null)
            throw new KeyNotFoundException("Actor not found");


        db.Actors.Remove(actor);
        await db.SaveChangesAsync(cancellationToken);
    }
}

