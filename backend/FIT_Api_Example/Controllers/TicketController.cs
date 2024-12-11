using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class TicketController:ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public TicketController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<Ticket>> Get()
        {
            var ticket = _DbContext.Ticket.ToList();

            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        [HttpGet("TicketID")]

        public ActionResult<Ticket> GetById(int TicketId)
        {
            var ticket = _DbContext.Ticket.Find(TicketId);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        [HttpDelete("TicketID")]

        public ActionResult<Ticket> Delete(int TicketId)
        {
            var ticket = _DbContext.Ticket.Find(TicketId);
            if (ticket == null)
            {
                return NotFound();
            }
            _DbContext.Remove(ticket);
            _DbContext.SaveChanges();
            return ticket;
        }

        [HttpPost]

        public ActionResult<Ticket> Insert([FromBody] TicketInsertVM x)
        {
            var NewTicket = new Ticket()
            {
                UserID = x.UserID,
                SeatID = x.SeatID,
                ProjectionID = x.ProjectionID,
                OrderDate = DateTime.Now,
                Paid = false,
            };
            _DbContext.Ticket.Add(NewTicket);
            _DbContext.SaveChanges();
            return NewTicket;
        }

        [HttpPut("TicketID")]

        public ActionResult<Ticket> Update(int TicketId, TicketUpdateVM x)
        {
            var UpdateTicket = _DbContext.Ticket.Find(TicketId);
            if (UpdateTicket == null)
            {
                return NotFound();
            }
            UpdateTicket.Paid = x.Paid;
            _DbContext.SaveChanges();
            return UpdateTicket;

        }
    }
}
