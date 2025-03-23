using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ManufacturerController(ApplicationDbContext _DbContext) : ControllerBase
    {
        [HttpGet]

        public ActionResult<List<Manufacturer>> Get()
        {
            var manufacturer = _DbContext.Manufacturer.ToList();
            if (manufacturer == null)
            {
                return NotFound();


            }
            return manufacturer;

        }

        [HttpGet("ManufacturerID")]

        public ActionResult<Manufacturer> GetById(int ManufacturerId)
        {
            var manufacturer = _DbContext.Manufacturer.Find(ManufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return manufacturer;

        }

        [HttpDelete("ManufacturerID")]
        public ActionResult<Manufacturer> Delete(int ManufacturerId)
        {
            var manufacturerDelete = _DbContext.Manufacturer.Find(ManufacturerId);
            if (manufacturerDelete == null)
            {
                return NotFound();
            }
            _DbContext.Manufacturer.Remove(manufacturerDelete);
            _DbContext.SaveChanges();
            return manufacturerDelete;
        }

        [HttpPost]

        public ActionResult<Manufacturer> Insert([FromBody] ManufacturerUpsertVM x)
        {
            var NewManufacturer = new Manufacturer()
            {
               Name = x.Name
            };
            _DbContext.Manufacturer.Add(NewManufacturer);
            _DbContext.SaveChanges();
            return NewManufacturer;

        }
        [HttpPut("ManufacturerID")]

        public ActionResult<Manufacturer> Update(int ManufacturerId, ManufacturerUpsertVM x)
        {
            var manufacturer = _DbContext.Manufacturer.Find(ManufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }
            manufacturer.Name = x.Name;
            _DbContext.SaveChanges();
            return manufacturer;
        }

    }
}
