using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuManufacturerEndpoints.MenuManufacturerUpdateOrInsertEndpoint;
using CineScreen.Data.Models.TenantSpecificTables.Basic;

namespace CineScreen.Endpoints.MenuManufacturerEndpoints;

[Route("menu-manufacturers")]
public class MenuManufacturerUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuManufacturerUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MenuManufacturerUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        MenuManufacturer? menuManufacturer;

        if (isInsert)
        {
            menuManufacturer = new MenuManufacturer();
            db.Set<MenuManufacturer>().Add(menuManufacturer);
        }
        else
        {
            menuManufacturer = await db.MenuManufacturers.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (menuManufacturer == null)
            {
                throw new KeyNotFoundException("Menu manufacturer not found");
            }
        }

        menuManufacturer.MenuID = request.MenuID;
        menuManufacturer.ManufacturerID = request.ManufacturerID;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MenuManufacturerUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MenuID { get; set; }
        public int ManufacturerID { get; set; }
    }
} 