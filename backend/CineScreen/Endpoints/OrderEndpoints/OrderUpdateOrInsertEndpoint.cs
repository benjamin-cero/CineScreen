using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.OrderEndpoints.OrderUpdateOrInsertEndpoint;

namespace CineScreen.Endpoints.OrderEndpoints;

[Route("orders")]
public class OrderUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<OrderUpdateOrInsertRequest>
    .WithoutResult
{
    [HttpPost]
    public override async Task HandleAsync([FromBody] OrderUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = request.ID == null || request.ID == 0;
        Order? order;

        if (isInsert)
        {
            order = new Order();
            db.Set<Order>().Add(order);
        }
        else
        {
            order = await db.Orders.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }
        }

        order.MyAppUserID = request.MyAppUserID;
        order.MenuID = request.MenuID;
        order.Quantity = request.Quantity;
        order.OrderDate = DateTime.Now;
        order.Paid = false;

        await db.SaveChangesAsync(cancellationToken);
    }

    public class OrderUpdateOrInsertRequest
    {
        public int? ID { get; set; }
        public int MyAppUserID { get; set; }
        public int MenuID { get; set; }
        public int Quantity { get; set; }

    }
} 