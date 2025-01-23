using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
