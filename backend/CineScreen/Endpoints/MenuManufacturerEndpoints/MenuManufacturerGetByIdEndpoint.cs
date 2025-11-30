using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuManufacturerEndpoints.MenuManufacturerGetByIdEndpoint;

namespace CineScreen.Endpoints.MenuManufacturerEndpoints;

[Route("menu-manufacturers")]
public class MenuManufacturerGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuManufacturerGetByIdRequest>
    .WithActionResult<MenuManufacturerGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MenuManufacturerGetByIdResponse>> HandleAsync([FromRoute] MenuManufacturerGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var menuManufacturer = await db.MenuManufacturers
            .Include(mm => mm.Menu)
            .Include(mm => mm.Manufacturer)
            .Where(mm => mm.ID == request.ID)
            .Select(mm => new MenuManufacturerGetByIdResponse
            {
                ID = mm.ID,
                MenuID = mm.MenuID,
                MenuName = mm.Menu.Name,
                ManufacturerID = mm.ManufacturerID,
                ManufacturerName = mm.Manufacturer.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (menuManufacturer == null)
        {
            return NotFound("Menu manufacturer not found");
        }

        return Ok(menuManufacturer);
    }

    public class MenuManufacturerGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MenuManufacturerGetByIdResponse
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
    }
} 