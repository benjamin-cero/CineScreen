using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ManufacturerID { get; set; }
        [ForeignKey(nameof(ManufacturerID))]
        public Manufacturer Manufacturer { get; set; }
    }
}
