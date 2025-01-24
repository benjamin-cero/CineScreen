using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string Name { get; set; }
    }
}
