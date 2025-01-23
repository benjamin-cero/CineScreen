using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string Name { get; set; }

    }
}
