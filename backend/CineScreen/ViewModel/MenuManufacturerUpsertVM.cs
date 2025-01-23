using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class MenuManufacturerUpsertVM
    {
        public int MenuID { get; set; }
        public int ManufacturerID { get; set; }
        
    }
}
