using CineScreen.Data;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.OrderEndpoints.OrderGetByIdEndpoint;

namespace CineScreen.Endpoints.OrderEndpoints;

[Route("orders")]
public class OrderGetByIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<OrderGetByIdRequest>
    .WithActionResult<OrderGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<OrderGetByIdResponse>> HandleAsync([FromRoute] OrderGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var order = await db.Orders
            .Include(o => o.MyAppUser)
            .Include(o => o.Menu)
            .Where(o => o.ID == request.ID)
            .Select(o => new OrderGetByIdResponse
            {
                ID = o.ID,
                MyAppUserID = o.MyAppUserID,
                UserName = $"{o.MyAppUser.FirstName} {o.MyAppUser.LastName}",
                MenuID = o.MenuID,
                MenuName = o.Menu.Name,
                Quantity = o.Quantity,
                OrderDate = o.OrderDate,
                Paid = o.Paid,
                TotalPrice = o.Quantity * o.Menu.Price
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (order == null)
        {
            return NotFound("Order not found");
        }

        return Ok(order);
    }

    public class OrderGetByIdRequest
    {
        public int ID { get; set; }
    }

    public class OrderGetByIdResponse
    {
        public int ID { get; set; }
        public int MyAppUserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int MenuID { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
    }
} 