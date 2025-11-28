using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuEndpoints.MenuDeleteEndpoint;

namespace CineScreen.Endpoints.MenuEndpoints;

[Route("menus")]
public class MenuDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] MenuDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var menu = await db.Menus.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (menu == null)
        {
            throw new KeyNotFoundException("Menu item not found");
        }

        db.Set<Menu>().Remove(menu);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class MenuDeleteRequest
    {
        public int ID { get; set; }
    }
} 