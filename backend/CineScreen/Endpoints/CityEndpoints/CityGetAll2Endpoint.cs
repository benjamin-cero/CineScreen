using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace CineScreen.Endpoints.CityEndpoints;

//sa paging i bez filtera
[Route("cities")]
public class CityGetAll2Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MyPagedRequest>
    .WithResult<MyPagedList<CityGetAll1Response>>
{
    [HttpGet("paged")]
    public override async Task<MyPagedList<CityGetAll1Response>> HandleAsync([FromQuery] MyPagedRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Cities
                        .Select(c => new CityGetAll1Response
                        {
                            ID = c.ID,
                            Name = c.Name,

                        });

        var result = await MyPagedList<CityGetAll1Response>.CreateAsync(query, request, cancellationToken);

        return result;
    }

    public class CityGetAll2Response
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}