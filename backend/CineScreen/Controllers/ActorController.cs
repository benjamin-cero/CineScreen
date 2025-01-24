using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CineScreen.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ActorController(ApplicationDbContext _DbContext) : ControllerBase
    {


        [HttpGet]

        public ActionResult<List<Actor>> Get()
        {
            var actor = _DbContext.Actor.ToList();

            if (actor == null)
            {
                return NotFound();
            }
            return actor;
        }

        [HttpGet("ActorID")]

        public ActionResult<Actor> GetById(int ActorID)
        {
            var actor = _DbContext.Actor.Find(ActorID);
            if (actor == null)
            {
                return NotFound();
            }
            return actor;
        }

        [HttpDelete("ActorID")]

        public ActionResult<Actor> Delete(int ActorID)
        {
            var actor = _DbContext.Actor.Find(ActorID);
            if (actor == null)
            {
                return NotFound();
            }
            _DbContext.Remove(actor);
            _DbContext.SaveChanges();
            return actor;
        }

        [HttpPost]

        public ActionResult<Actor> Insert([FromBody] ActorUpsertVM x)
        {
            var NewActor = new Actor()
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            };
            _DbContext.Actor.Add(NewActor);
            _DbContext.SaveChanges();
            return NewActor;
        }

        [HttpPut("ActorID")]

        public ActionResult<Actor> Update(int ActorID, ActorUpsertVM x)
        {
            var UpdateActor = _DbContext.Actor.Find(ActorID);
            if (UpdateActor == null)
            {
                return NotFound();
            }
            UpdateActor.FirstName = x.FirstName;
            UpdateActor.LastName = x.LastName;
            _DbContext.SaveChanges();
            return UpdateActor;

        }

    }
}
