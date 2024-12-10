using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class StatusController:ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public StatusController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<Status>> Get()
        {
            var status = _DbContext.Status.ToList();

            if (status == null)
            {
                return NotFound();
            }
            return status;
        }

        [HttpGet("StatusID")]

        public ActionResult<Status> GetById(int StatusId)
        {
            var status = _DbContext.Status.Find(StatusId);
            if (status == null)
            {
                return NotFound();
            }
            return status;
        }

        [HttpDelete("StatusID")]

        public ActionResult<Status> Delete(int StatusId)
        {
            var status = _DbContext.Status.Find(StatusId);
            if (status == null)
            {
                return NotFound();
            }
            _DbContext.Remove(status);
            _DbContext.SaveChanges();
            return status;
        }

        [HttpPost]

        public ActionResult<Status> Insert([FromBody] StatusUpsertVM x)
        {
            var NewStatus = new Status()
            {
                Name = x.Name
            };
            _DbContext.Status.Add(NewStatus);
            _DbContext.SaveChanges();
            return NewStatus;
        }

        [HttpPut("StatusID")]

        public ActionResult<Status> Update(int StatusId, StatusUpsertVM x)
        {
            var UpdateStatus = _DbContext.Status.Find(StatusId);
            if (UpdateStatus == null)
            {
                return NotFound();
            }
            UpdateStatus.Name = x.Name;
            _DbContext.SaveChanges();
            return UpdateStatus;

        }
    }
}
