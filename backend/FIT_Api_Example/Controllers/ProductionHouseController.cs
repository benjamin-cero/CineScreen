using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionHouseController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductionHouseController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]

        public ActionResult<List<ProductionHouse>> Get()
        {
            var ProductionHouse = _dbContext.ProductionHouse.ToList();

            if (ProductionHouse == null)
            {
                return NotFound();
            }
            return ProductionHouse;
        }

        [HttpGet("ProductionHouseID")]

        public ActionResult<ProductionHouse> GetById(int ProductionHouseId)
        {
            var ProductionHouse = _dbContext.ProductionHouse.Find(ProductionHouseId);

            if (ProductionHouse == null) {
                return NotFound();
            }
            return ProductionHouse;
        }

        [HttpDelete("ProductionHouseID")]

        public ActionResult<ProductionHouse> Delete(int ProductionHouseId)
        {
            var ProductionHouse = _dbContext.ProductionHouse.Find(ProductionHouseId);

            if (ProductionHouse == null)
            {
                return NotFound();
            }
            _dbContext.ProductionHouse.Remove(ProductionHouse);
            return ProductionHouse;
        }

        [HttpPost]
        public ActionResult<ProductionHouse> Insert([FromBody] ProductionHouseUpsertVM x)
        {
            var NewProductionHouse = new ProductionHouse() {
                Name = x.Name
            };
            _dbContext.ProductionHouse.Add(NewProductionHouse);
            _dbContext.SaveChanges();
            return NewProductionHouse;
        }
        [HttpPut("ProductionHouseID")]

        public ActionResult<ProductionHouse> Update(int ProductionHouseId, ProductionHouseUpsertVM x)
        {
            var ProductionHouseUpdate = _dbContext.ProductionHouse.Find(ProductionHouseId);
            if (ProductionHouseUpdate == null) {
                return NotFound();
            }
            ProductionHouseUpdate.Name = x.Name;
            _dbContext.SaveChanges();
            return ProductionHouseUpdate;

        }

    }
}
