using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
    }
}
