using CineScreen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//sa paging i bez filtera
[Route("cities")]
public class CityGetAll2Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MyPagedRequest>
    .WithResult<MyPagedList<CityGetAll1Response>>
{
    [HttpGet("paged")]
    public override async Task<MyPagedList<CityGetAll1Response>> HandleAsync([FromQuery] MyPagedRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.City
                        .Select(c => new CityGetAll1Response
                        {
                            CityID = c.CityID,
                            Name = c.Name,
                        });

        var result = await MyPagedList<CityGetAll1Response>.CreateAsync(query, request, cancellationToken);

        return result;
    }

    public class CityGetAll2Response
    {
        public required int CityID { get; set; }
        public required string Name { get; set; }
        public required string CountryName { get; set; }
    }
}