using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string Name { get; set; }

    }
}
