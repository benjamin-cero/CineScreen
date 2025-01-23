using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class ProductionHouse
    {
        [Key]
        public int ProductionHouseID { get; set; }
        public string Name { get; set; }
    }
}
