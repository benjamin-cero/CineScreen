using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
