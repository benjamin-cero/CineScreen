using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class MovieType
    {
        [Key]
        public int MovieTypeID { get; set; }
        public string Type { get; set; }
    }
}
