using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
