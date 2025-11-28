using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.DirectorEndpoints.DirectorUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.DirectorEndpoints;

[Route("directors")]
public class DirectorUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<DirectorUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] DirectorUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Director? director;

        if (isInsert)
        {
            director = new Director();
            db.Directors.Add(director);
        }
        else
        {
            director = await db.Directors.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (director == null)
            {
                throw new KeyNotFoundException("Director not found");
            }
        }

        director.FirstName = request.FirstName;
        director.LastName = request.LastName;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class DirectorUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
} 