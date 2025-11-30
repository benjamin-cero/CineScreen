using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuManufacturerEndpoints.MenuManufacturerDeleteEndpoint;

namespace CineScreen.Endpoints.MenuManufacturerEndpoints;

[Route("menu-manufacturers")]
public class MenuManufacturerDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuManufacturerDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MenuManufacturerDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var menuManufacturer = await db.MenuManufacturers.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (menuManufacturer == null)
        {
            throw new KeyNotFoundException("Menu manufacturer not found");
        }

        db.Set<MenuManufacturer>().Remove(menuManufacturer);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MenuManufacturerDeleteRequest
    {
        public int ID { get; set; }
    }
} 