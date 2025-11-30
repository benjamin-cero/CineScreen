using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuManufacturerEndpoints.MenuManufacturerGetAllEndpoint;

namespace CineScreen.Endpoints.MenuManufacturerEndpoints;

[Route("menu-manufacturers")]
public class MenuManufacturerGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuManufacturerGetAllRequest>
    .WithResult<MyPagedList<MenuManufacturerGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MenuManufacturerGetAllResponse>> HandleAsync([FromQuery] MenuManufacturerGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.MenuManufacturers
            .Include(mm => mm.Menu)
            .Include(mm => mm.Manufacturer)
            .AsQueryable();

        // Filter by menu name
        if (!string.IsNullOrEmpty(request.MenuName))
        {
            query = query.Where(mm => mm.Menu.Name.Contains(request.MenuName));
        }

        // Filter by manufacturer name
        if (!string.IsNullOrEmpty(request.ManufacturerName))
        {
            query = query.Where(mm => mm.Manufacturer.Name.Contains(request.ManufacturerName));
        }

        // Project to result type
        var projectedQuery = query.Select(mm => new MenuManufacturerGetAllResponse
        {
            ID = mm.ID,
            MenuID = mm.MenuID,
            MenuName = mm.Menu.Name,
            ManufacturerID = mm.ManufacturerID,
            ManufacturerName = mm.Manufacturer.Name
        });

        // Create paginated response with filter
        var result = await MyPagedList<MenuManufacturerGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MenuManufacturerGetAllRequest : MyPagedRequest
    {
        public string? MenuName { get; set; }
        public string? ManufacturerName { get; set; }
    }

    public class MenuManufacturerGetAllResponse
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
    }
} 