using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CineScreen.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdministratorController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Administrator>> Get()
        {
            var administrator = _DbContext.Administrator.ToList();

            if (administrator == null)
            {
                return NotFound();
            }
            return administrator;
        }

        [HttpGet("AdministratorID")]

        public ActionResult<Administrator> GetById(int AdministratorId)
        {
            var administrator = _DbContext.Administrator.Find(AdministratorId);
            if (administrator == null)
            {
                return NotFound();
            }
            return administrator;
        }

        [HttpDelete("AdministratorID")]

        public ActionResult<Administrator> Delete(int AdministratorId)
        {
            var administrator = _DbContext.Administrator.Find(AdministratorId);
            if (administrator == null)
            {
                return NotFound();
            }
            _DbContext.Remove(administrator);
            _DbContext.SaveChanges();
            return administrator;
        }

        [HttpPost]

        public ActionResult<Administrator> Insert([FromBody] AdministratorUpsertVM x)
        {
            var NewAdministrator = new Administrator()
            {
                Username = x.Username,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName
            };
            _DbContext.Administrator.Add(NewAdministrator);
            _DbContext.SaveChanges();
            return NewAdministrator;
        }

        [HttpPut("AdministratorID")]

        public ActionResult<Administrator> Update(int AdministratorId, AdministratorUpsertVM x)
        {
            var UpdateAdministrator = _DbContext.Administrator.Find(AdministratorId);
            if (UpdateAdministrator == null)
            {
                return NotFound();
            }
            UpdateAdministrator.Username = x.Username;
            UpdateAdministrator.Password = x.Password;
            UpdateAdministrator.FirstName = x.FirstName;
            UpdateAdministrator.LastName = x.LastName;
            _DbContext.SaveChanges();
            return UpdateAdministrator;

        }

    }
}
