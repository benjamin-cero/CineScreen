using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper.BaseClasses;

namespace FIT_Api_Example.Data.Models
{
    public class MenuManufacturer : TenantSpecificTable
    {
        public int MenuID { get; set; }
        [ForeignKey(nameof(MenuID))]
        public Menu Menu { get; set; }
        public int ManufacturerID { get; set; }
        [ForeignKey(nameof(ManufacturerID))]
        public Manufacturer Manufacturer { get; set; }
        
    }
}
