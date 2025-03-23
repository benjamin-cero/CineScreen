using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class CinemaHallController(ApplicationDbContext _DbContext) : ControllerBase
    {
        [HttpGet]

        public ActionResult<List<CinemaHall>> Get()
        {
            var cinemahall = _DbContext.CinemaHall.ToList();
            if(cinemahall == null)
            {
                return NotFound();
            }
            return cinemahall;
        }

        [HttpGet("CinemaHallID")]

        public ActionResult<CinemaHall> Get(int CinemaHallId) {
            var cinemahall = _DbContext.CinemaHall.Find(CinemaHallId);

            if (cinemahall == null) { 
                return NotFound();
            }
            return cinemahall;

        }

        [HttpDelete("CinemaHallID")]

        public ActionResult<CinemaHall> Delete(int CinemaHallId) {

            var cinemaHalldelete = _DbContext.CinemaHall.Find(CinemaHallId);

            if (cinemaHalldelete == null) {
                return NotFound();
            }
            _DbContext.CinemaHall.Remove(cinemaHalldelete);
            return cinemaHalldelete;
        }


        [HttpPost]

        public ActionResult<CinemaHall> Insert([FromBody] CinemaHallUpsertVM x)
        {
            var cinemaHall = new CinemaHall() { 
                Name = x.Name,
                Capacity = x.Capacity
            };
            _DbContext.CinemaHall.Add(cinemaHall);
            _DbContext.SaveChanges();
            return cinemaHall;
        }

        [HttpPut("CinemaHallID")]

        public ActionResult<CinemaHall> Update(int CinemaHallId, CinemaHallUpsertVM x)
        {
            var cinemaHall = _DbContext.CinemaHall.Find(CinemaHallId);
            if(cinemaHall== null)
            {
                return NotFound();
            }
            cinemaHall.Name = x.Name;
            cinemaHall.Capacity = x.Capacity;
            _DbContext.SaveChanges();
            return cinemaHall;
        }

    }
}
