using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuEndpoints.MenuUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.MenuEndpoints;

[Route("menus")]
public class MenuUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] MenuUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Menu? menu;

        if (isInsert)
        {
            menu = new Menu();
            db.Set<Menu>().Add(menu);
        }
        else
        {
            menu = await db.Menus.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (menu == null)
            {
                throw new KeyNotFoundException("Menu item not found");
            }
        }

        menu.Name = request.Name;
        menu.Price = request.Price;
        menu.Image = request.Image;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class MenuUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public byte[]? Image { get; set; }
    }
} 