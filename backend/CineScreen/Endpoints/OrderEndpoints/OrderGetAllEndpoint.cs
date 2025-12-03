using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.OrderEndpoints.OrderGetAllEndpoint;

namespace CineScreen.Endpoints.OrderEndpoints;

[Route("orders")]
public class OrderGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<OrderGetAllRequest>
    .WithResult<MyPagedList<OrderGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<OrderGetAllResponse>> HandleAsync([FromQuery] OrderGetAllRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Orders
            .Include(o => o.MyAppUser)
            .Include(o => o.Menu)
            .AsQueryable();

        // Filter by user ID
        if (request.MyAppUserID.HasValue)
        {
            query = query.Where(o => o.MyAppUserID == request.MyAppUserID.Value);
        }

        // Filter by menu ID
        if (request.MenuID.HasValue)
        {
            query = query.Where(o => o.MenuID == request.MenuID.Value);
        }

        // Filter by paid status
        if (request.Paid.HasValue)
        {
            query = query.Where(o => o.Paid == request.Paid.Value);
        }

        // Filter by date range
        if (request.FromDate.HasValue)
        {
            query = query.Where(o => o.OrderDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(o => o.OrderDate <= request.ToDate.Value);
        }

        // Project to result type
        var projectedQuery = query.Select(o => new OrderGetAllResponse
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
        });

        // Create paginated response with filter
        var result = await MyPagedList<OrderGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    public class OrderGetAllRequest : MyPagedRequest
    {
        public int? MyAppUserID { get; set; }
        public int? MenuID { get; set; }
        public bool? Paid { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class OrderGetAllResponse
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