using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public MenuController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }


        [HttpGet]

        public ActionResult<List<Menu>> Get()
        {
            var menu = _DbContext.Menu.ToList();
            if (menu == null)
            {
                return NotFound();


            }
            return menu;

        }

        [HttpGet("MenuID")]

        public ActionResult<Menu> GetById(int MenuId)
        {
            var menu = _DbContext.Menu.Find(MenuId);
            if (menu == null)
            {
                return NotFound();
            }
            return menu;

        }

        [HttpDelete("MenuID")]
        public ActionResult<Menu> Delete(int MenuId)
        {
            var menuDelete = _DbContext.Menu.Find(MenuId);
            if (menuDelete == null)
            {
                return NotFound();
            }
            _DbContext.Menu.Remove(menuDelete);
            _DbContext.SaveChanges();
            return menuDelete;
        }

        [HttpPost]

        public ActionResult<Menu> Insert([FromBody] MenuUpsertVM x)
        {
            var newMenu = new Menu()
            {
                Name = x.Name,
                Price = x.Price,
                Image = x.Image
            };
            _DbContext.Menu.Add(newMenu);
            _DbContext.SaveChanges();
            return newMenu;

        }
        [HttpPut("MenuID")]

        public ActionResult<Menu> Update(int MenuId, MenuUpsertVM x)
        {
            var MenuUpdate = _DbContext.Menu.Find(MenuId);
            if (MenuUpdate == null)
            {
                return NotFound();
            }
            MenuUpdate.Name = x.Name;
            MenuUpdate.Price = x.Price;
            MenuUpdate.Image = x.Image;
            _DbContext.SaveChanges();
            return MenuUpdate;
        }
    }
}
