using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeatController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Seat>> Get()
        {
            var seat = _DbContext.Seat.ToList();

            if (seat == null)
            {
                return NotFound();
            }
            return seat;
        }

        [HttpGet("SeatID")]

        public ActionResult<Seat> GetById(int SeatId)
        {
            var seat = _DbContext.Seat.Find(SeatId);
            if (seat == null)
            {
                return NotFound();
            }
            return seat;
        }

        [HttpDelete("SeatID")]

        public ActionResult<Seat> Delete(int SeatId)
        {
            var seat = _DbContext.Seat.Find(SeatId);
            if (seat == null)
            {
                return NotFound();
            }
            _DbContext.Remove(seat);
            _DbContext.SaveChanges();
            return seat;
        }

        [HttpPost]

        public ActionResult<Seat> Insert([FromBody] SeatUpsertVM x)
        {
            var NewSeat = new Seat()
            {
                CinemaHallID = x.CinemaHallID,
                SeatNumber = x.SeatNumber,
                SeatTypeID = x.SeatTypeID,
            };
            _DbContext.Seat.Add(NewSeat);
            _DbContext.SaveChanges();
            return NewSeat;
        }

        [HttpPut("SeatID")]

        public ActionResult<Seat> Update(int SeatId, SeatUpsertVM x)
        {
            var UpdateSeat = _DbContext.Seat.Find(SeatId);
            if (UpdateSeat == null)
            {
                return NotFound();
            }
            UpdateSeat.CinemaHallID = x.CinemaHallID;
            UpdateSeat.SeatNumber = x.SeatNumber;
            UpdateSeat.SeatTypeID = x.SeatTypeID;
            _DbContext.SaveChanges();
            return UpdateSeat;

        }
    }
}
