using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.MenuEndpoints.MenuGetByIdEndpoint;

namespace CineScreen.Endpoints.MenuEndpoints;

[Route("menus")]
public class MenuGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MenuGetByIdRequest>
    .WithActionResult<MenuGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<MenuGetByIdResponse>> HandleAsync([FromRoute] MenuGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var menu = await db.Menus
            .Where(m => m.ID == request.ID)
            .Select(m => new MenuGetByIdResponse
            {
                ID = m.ID,
                Name = m.Name,
                Price = m.Price,
                Image = m.Image
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (menu == null)
        {
            return NotFound("Menu item not found");
        }

        return Ok(menu);
    }

    public class MenuGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class MenuGetByIdResponse
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public byte[]? Image { get; set; }
    }
} 