using CineScreen.Data;
using CineScreen.Data.Models;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints
{
    [Route("cities")]
    public class CityUpdateOrInsertEndpoint(ApplicationDbContext db, MyAuthService myAuthService) : MyEndpointBaseAsync
        .WithRequest<CityUpdateOrInsertRequest>
        .WithActionResult<CityUpdateOrInsertResponse>
    {
        [HttpPost]  // Using POST to support both create and update
        public override async Task<ActionResult<CityUpdateOrInsertResponse>> HandleAsync([FromBody] CityUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
        {

            MyAuthInfo myAuthInfo = myAuthService.GetAuthInfo();
            if (!myAuthInfo.IsLoggedIn)
            {
                return Unauthorized();
            }
            // Check if we're performing an insert or update based on the ID value
            bool isInsert = (request.CityID == null || request.CityID == 0);
            City? city;

            if (isInsert)
            {
                // Insert operation: create a new city entity
                city = new City();
                db.City.Add(city); // Add the new city to the context
            }
            else
            {
                // Update operation: retrieve the existing city
                city = await db.City.FindAsync(new object[] { request.CityID }, cancellationToken);

                if (city == null)
                {
                    throw new KeyNotFoundException("City not found");
                }
            }

            // Set common properties for both insert and update operations
            city.Name = request.Name;

            // Save changes to the database
            await db.SaveChangesAsync(cancellationToken);

            return new CityUpdateOrInsertResponse
            {
                CityID = city.CityID,
                Name = city.Name,
            };
        }

        public class CityUpdateOrInsertRequest
        {
            public int? CityID { get; set; } // Nullable to allow null for insert operations
            public required string Name { get; set; }
        }

        public class CityUpdateOrInsertResponse
        {
            public required int CityID { get; set; }
            public required string Name { get; set; }
        }
    }
}
