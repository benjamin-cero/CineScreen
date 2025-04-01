using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityGetAll3Endpoint;

namespace CineScreen.Endpoints.CityEndpoints;

//sa paging i sa filterom
[Route("cities")]
public class CityGetAll3Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CityGetAll3Request>
    .WithResult<MyPagedList<CityGetAll3Response>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<CityGetAll3Response>> HandleAsync([FromQuery] CityGetAll3Request request, CancellationToken cancellationToken = default)
    {
        // Kreiranje osnovnog query-a
        var query = db.Cities
            .AsQueryable();

        // Primjena filtera na osnovu naziva grada
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(c => c.Name.Contains(request.Q)
            );
        }

        // Projektovanje u rezultatni tip
        var projectedQuery = query.Select(c => new CityGetAll3Response
        {
            ID = c.ID,
            Name = c.Name
        });

        // Kreiranje paginiranog odgovora sa filterom
        var result = await MyPagedList<CityGetAll3Response>.CreateAsync(projectedQuery, request, cancellationToken);


        return result;
    }
    public class CityGetAll3Request : MyPagedRequest //naslijeđujemo
    {
        public string? Q { get; set; } = string.Empty;
    }

    public class CityGetAll3Response
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}