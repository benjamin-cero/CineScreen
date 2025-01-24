using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Order>> Get()
        {
            var order = _DbContext.Order.ToList();

            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet("OrderID")]

        public ActionResult<Order> GetById(int OrderId)
        {
            var order = _DbContext.Order.Find(OrderId);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpDelete("OrderID")]

        public ActionResult<Order> Delete(int OrderId)
        {
            var order = _DbContext.Order.Find(OrderId);
            if (order == null)
            {
                return NotFound();
            }
            _DbContext.Remove(order);
            _DbContext.SaveChanges();
            return order;
        }

        [HttpPost]

        public ActionResult<Order> Insert([FromBody] OrderInsertVM x)
        {
            var NewOrder = new Order()
            {
                UserID = x.UserID,
                MenuID = x.MenuID,
                Quantity = x.Quantity,
                OrderDate = DateTime.Now,
                Paid = false
            };
            _DbContext.Order.Add(NewOrder);
            _DbContext.SaveChanges();
            return NewOrder;
        }

        [HttpPut("OrderID")]

        public ActionResult<Order> Update(int OrderId, OrderUpdateVM x)
        {
            var UpdateOrder = _DbContext.Order.Find(OrderId);
            if (UpdateOrder == null)
            {
                return NotFound();
            }
            UpdateOrder.Paid = x.Paid;
            _DbContext.SaveChanges();
            return UpdateOrder;

        }
    }
}
