using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Data.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public User? User => this as User;

        [JsonIgnore]
        public Administrator? Administrator => this as Administrator;

        public bool isAdministrator => Administrator != null;
        public bool isUser => User != null;

    }
}
