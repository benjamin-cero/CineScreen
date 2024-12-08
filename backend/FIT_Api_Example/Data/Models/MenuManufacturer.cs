using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace FIT_Api_Example.Data.Models
{
    public class MenuManufacturer
    {
        [Key]
        public int MenuManufacturerID { get; set; }
        public int MenuID { get; set; }
        [ForeignKey(nameof(MenuID))]
        public Menu Menu { get; set; }
        public int ManufacturerID { get; set; }
        [ForeignKey(nameof(ManufacturerID))]
        public Manufacturer Manufacturer { get; set; }
        
    }
}
