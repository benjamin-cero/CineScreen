using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.OrderEndpoints.OrderDeleteEndpoint;

namespace CineScreen.Endpoints.OrderEndpoints;

[Route("orders")]
public class OrderDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<OrderDeleteRequest>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync([FromRoute] OrderDeleteRequest request, CancellationToken cancellationToken = default)
    {
        var order = await db.Orders.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

        if (order == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        db.Set<Order>().Remove(order);
        await db.SaveChangesAsync(cancellationToken);
    }

    public class OrderDeleteRequest
    {
        public int ID { get; set; }
    }
} 