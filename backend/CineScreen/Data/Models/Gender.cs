using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }
        public string Name { get; set; }
    }
}
