using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public UserController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }

        [HttpGet]

        public ActionResult<List<User>> Get()
        {
            var user = _DbContext.User.ToList();

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("UserID")]

        public ActionResult<User> GetById(int UserId)
        {
            var user = _DbContext.User.Find(UserId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpDelete("UserID")]

        public ActionResult<User> Delete(int UserId)
        {
            var user = _DbContext.User.Find(UserId);
            if (user == null)
            {
                return NotFound();
            }
            _DbContext.Remove(user);
            _DbContext.SaveChanges();
            return user;
        }

        [HttpPost]

        public ActionResult<User> Insert([FromBody] UserUpsertVM x)
        {
            var NewUser = new User()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                CityID = x.CityID,
                GenderID = x.GenderID,
                Email = x.Email,
                Phone = x.Phone,
                Points = x.Points,
                Username = x.Username,
                Password = x.Password,
            };
            _DbContext.User.Add(NewUser);
            _DbContext.SaveChanges();
            return NewUser;
        }

        [HttpPut("UserID")]

        public ActionResult<User> Update(int UserId, UserUpsertVM x)
        {
            var UpdateUser = _DbContext.User.Find(UserId);
            if (UpdateUser == null)
            {
                return NotFound();
            }
            UpdateUser.FirstName = x.FirstName;
            UpdateUser.LastName = x.LastName;
            UpdateUser.CityID = x.CityID;
            UpdateUser.GenderID = x.GenderID;
            UpdateUser.Email = x.Email;
            UpdateUser.Phone = x.Phone;
            UpdateUser.Points = x.Points;
            UpdateUser.Username = x.Username;
            UpdateUser.Password = x.Password;
            _DbContext.SaveChanges();
            return UpdateUser;

        }
    }
}
