using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeatTypeController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<SeatType>> Get()
        {
            var seatType = _DbContext.SeatType.ToList();

            if (seatType == null)
            {
                return NotFound();
            }
            return seatType;
        }

        [HttpGet("SeatTypeID")]

        public ActionResult<SeatType> GetById(int SeatTypeId)
        {
            var seatType = _DbContext.SeatType.Find(SeatTypeId);
            if (seatType == null)
            {
                return NotFound();
            }
            return seatType;
        }

        [HttpDelete("SeatTypeID")]

        public ActionResult<SeatType> Delete(int SeatTypeId)
        {
            var seatType = _DbContext.SeatType.Find(SeatTypeId);
            if (seatType == null)
            {
                return NotFound();
            }
            _DbContext.Remove(seatType);
            _DbContext.SaveChanges();
            return seatType;
        }

        [HttpPost]

        public ActionResult<SeatType> Insert([FromBody] SeatTypeUpsertVM x)
        {
            var NewSeatType = new SeatType()
            {
                Name = x.Name,
            };
            _DbContext.SeatType.Add(NewSeatType);
            _DbContext.SaveChanges();
            return NewSeatType;
        }

        [HttpPut("SeatTypeID")]

        public ActionResult<SeatType> Update(int SeatTypeId, SeatTypeUpsertVM x)
        {
            var UpdateSeatType = _DbContext.SeatType.Find(SeatTypeId);
            if (UpdateSeatType == null)
            {
                return NotFound();
            }
            UpdateSeatType.Name = x.Name;
            _DbContext.SaveChanges();
            return UpdateSeatType;

        }

    }
}
