using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using CineScreen.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ActorEndpoints.ActorUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.ActorEndpoints;

//[MyAuthorization(isAdmin: true, isUser: false)]
[Route("actors")]
public class ActorUpdateOrInsertEndpoint(ApplicationDbContext db, IMyAuthService myAuthService) : MyEndpointBaseAsync
    .WithRequest<ActorUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] ActorUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
   
        
        bool isInsert = request.ID == null || request.ID == 0;
        Actor? actor;

        if (isInsert)
        {
            
            actor = new Actor();
            db.Actors.Add(actor); 
        }
        else
        {
            
            actor = await db.Actors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (actor == null)
            {
                throw new KeyNotFoundException("Actor not found");
            }
        }

        
        actor.FirstName = request.FirstName;
        actor.LastName = request.LastName;

        
        await db.SaveChangesAsync(cancellationToken);

     
    }

    public class ActorUpdateOrInsertRequest
    {
        public int? ID { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
    }

}
