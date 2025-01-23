using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenderController: ControllerBase
    {

        private readonly ApplicationDbContext _DbContext;

        public GenderController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }


        [HttpGet]

        public ActionResult<List<Gender>> Get()
        {
            var gender = _DbContext.Gender.ToList();
            if (gender == null)
            {
                return NotFound();


            }
            return gender;

        }

        [HttpGet("GenderID")]

        public ActionResult<Gender> GetById(int GenderId)
        {
            var gender = _DbContext.Gender.Find(GenderId);
            if (gender == null)
            {
                return NotFound();
            }
            return gender;

        }

        [HttpDelete("GenderID")]
        public ActionResult<Gender> Delete(int GenderId)
        {
            var GenderDelete = _DbContext.Gender.Find(GenderId);
            if (GenderDelete == null)
            {
                return NotFound();
            }
            _DbContext.Gender.Remove(GenderDelete);
            _DbContext.SaveChanges();
            return GenderDelete;
        }

        [HttpPost]

        public ActionResult<Gender> Insert([FromBody] GenderUpsertVM x)
        {
            var NewGender = new Gender()
            {
                Name = x.Name
            };
            _DbContext.Gender.Add(NewGender);
            _DbContext.SaveChanges();
            return NewGender;

        }
        [HttpPut("GenderID")]

        public ActionResult<Gender> Update(int GenderId, GenderUpsertVM x)
        {
            var genderUpdate = _DbContext.Gender.Find(GenderId);
            if (genderUpdate == null)
            {
                return NotFound();
            }
            genderUpdate.Name = x.Name;
            _DbContext.SaveChanges();
            return genderUpdate;
        }
    }
}
