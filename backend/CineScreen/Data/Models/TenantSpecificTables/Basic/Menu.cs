using CineScreen.Helper.BaseClasses;
using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class Menu : TenantSpecificTable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[]? Image { get; set; }
        
        // Navigation properties
        public virtual ICollection<MenuManufacturer> MenuManufacturers { get; set; } = new List<MenuManufacturer>();
    }
}
