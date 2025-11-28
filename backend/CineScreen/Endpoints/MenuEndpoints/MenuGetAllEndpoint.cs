using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuEndpoints.MenuGetAllEndpoint;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Data.Models.SharedTables;

namespace CineScreen.Endpoints.MenuEndpoints;

[Route("menus")]
public class MenuGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuGetAllRequest>
    .WithResult<MyPagedList<MenuGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<MenuGetAllResponse>> HandleAsync([FromQuery] MenuGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Menus
            .Include(m => m.MenuManufacturers)
                .ThenInclude(mm => mm.Manufacturer)
            .AsQueryable();

        // Filter by name
        if (!string.IsNullOrEmpty(request.Q))
        {
            query = query.Where(m => m.Name.Contains(request.Q));
        }

        // Filter by price range
        if (request.MinPrice.HasValue)
        {
            query = query.Where(m => m.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(m => m.Price <= request.MaxPrice.Value);
        }

        // Project to result type with MenuManufacturers
        var projectedQuery = query.Select(m => new MenuGetAllResponse
        {
            ID = m.ID,
            Name = m.Name,
            Price = m.Price,
            Image = m.Image != null ? Convert.ToBase64String(m.Image) : null,
            MenuManufacturers = m.MenuManufacturers.Select(mm => new MenuManufacturerResponse
            {
                ID = mm.ID,
                TenantId = mm.TenantId,
                MenuID = mm.MenuID,
                ManufacturerID = mm.ManufacturerID,
                Manufacturer = new ManufacturerResponse
                {
                    ID = mm.Manufacturer.ID,
                    Name = mm.Manufacturer.Name
                }
            }).ToList()
        });

        // Create paginated response with filter
        var result = await MyPagedList<MenuGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class MenuGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }

    public class ManufacturerResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class MenuManufacturerResponse
    {
        public int ID { get; set; }
        public int TenantId { get; set; }
        public int MenuID { get; set; }
        public int ManufacturerID { get; set; }
        public ManufacturerResponse Manufacturer { get; set; } = new();
    }

    public class MenuGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? Image { get; set; }
        public List<MenuManufacturerResponse> MenuManufacturers { get; set; } = new();
    }
} 