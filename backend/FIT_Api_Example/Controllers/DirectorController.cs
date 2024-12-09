using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class DirectorController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public DirectorController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }


        [HttpGet]

        public ActionResult<List<Director>> Get()
        {
            var director = _DbContext.Director.ToList();
            if (director == null)
            {
                return NotFound();


            }
            return director;

        }

        [HttpGet("DirectorID")]

        public ActionResult<Director> GetById(int DirectorId) {
            var director = _DbContext.Director.Find(DirectorId);
            if (director == null) {
                return NotFound();
            }
            return director;

        }

        [HttpDelete("DirectorID")]
        public ActionResult<Director> Delete(int DirectorId) {
            var directorDelete = _DbContext.Director.Find(DirectorId);
            if (directorDelete == null) {
                return NotFound();
            }
            _DbContext.Director.Remove(directorDelete);
            _DbContext.SaveChanges();
            return directorDelete;
        }

        [HttpPost]

        public ActionResult<Director> Insert([FromBody] DirectorUpsertVM x)
        {
            var NewDirector = new Director()
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            };
            _DbContext.Director.Add(NewDirector);
            _DbContext.SaveChanges();
            return NewDirector;

        }
        [HttpPut("DirectorID")]

        public ActionResult<Director> Update(int DirectorID, DirectorUpsertVM x)
        {
            var Director = _DbContext.Director.Find(DirectorID);
            if (Director == null)
            {
                return NotFound();
            }
            Director.FirstName = x.FirstName;
            Director.LastName = x.LastName;
            _DbContext.SaveChanges();
            return Director;
        }

    }
}

