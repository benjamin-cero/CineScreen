using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.ProjectionEndpoints.ProjectionUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.ProjectionEndpoints;

[Route("projections")]
public class ProjectionUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<ProjectionUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] ProjectionUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Projection? projection;

        if (isInsert)
        {
            projection = new Projection();
            db.Set<Projection>().Add(projection);
        }
        else
        {
            projection = await db.Projections.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (projection == null)
            {
                throw new KeyNotFoundException("Projection not found");
            }
        }

        projection.StartTime = request.StartTime;
        projection.Price = request.Price;
        projection.MovieID = request.MovieID;
        projection.CinemaHallID = request.CinemaHallID;
        projection.MovieTypeID = request.MovieTypeID;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class ProjectionUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public DateTime StartTime { get; set; }
        public double Price { get; set; }
        public int MovieID { get; set; }
        public int CinemaHallID { get; set; }
        public int MovieTypeID { get; set; }
    }
} 