using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CineScreen.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MenuManufacturerController(ApplicationDbContext _DbContext) : ControllerBase
    {
        [HttpGet]

        public ActionResult<List<MenuManufacturer>> Get()
        {
            var menuManufacturer = _DbContext.MenuManufacturer.ToList();

            if (menuManufacturer == null)
            {
                return NotFound();
            }
            return menuManufacturer;
        }

        [HttpGet("MenuManufacturerID")]

        public ActionResult<MenuManufacturer> GetById(int MenuManufacturerId)
        {
            var menuManufacturer = _DbContext.MenuManufacturer.Find(MenuManufacturerId);
            if (menuManufacturer == null)
            {
                return NotFound();
            }
            return menuManufacturer;
        }

        [HttpDelete("MenuManufacturerID")]

        public ActionResult<MenuManufacturer> Delete(int MenuManufacturerId)
        {
            var menuManufacturer = _DbContext.MenuManufacturer.Find(MenuManufacturerId);
            if (menuManufacturer == null)
            {
                return NotFound();
            }
            _DbContext.Remove(menuManufacturer);
            _DbContext.SaveChanges();
            return menuManufacturer;
        }

        [HttpPost]

        public ActionResult<MenuManufacturer> Insert([FromBody] MenuManufacturerUpsertVM x)
        {
            var NewMenuManufacturer = new MenuManufacturer()
            {
                ManufacturerID = x.ManufacturerID,
                MenuID = x.MenuID
            };
            _DbContext.MenuManufacturer.Add(NewMenuManufacturer);
            _DbContext.SaveChanges();
            return NewMenuManufacturer;
        }

        [HttpPut("MenuManufacturerID")]

        public ActionResult<MenuManufacturer> Update(int MenuManufacturerId, MenuManufacturerUpsertVM x)
        {
            var UpdateMenuManufacturer = _DbContext.MenuManufacturer.Find(MenuManufacturerId);
            if (UpdateMenuManufacturer == null)
            {
                return NotFound();
            }
            UpdateMenuManufacturer.ManufacturerID = x.ManufacturerID;
            UpdateMenuManufacturer.MenuID = x.MenuID;

            _DbContext.SaveChanges();
            return UpdateMenuManufacturer;

        }
    }
}
