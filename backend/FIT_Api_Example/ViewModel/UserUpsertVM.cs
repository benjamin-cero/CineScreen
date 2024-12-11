using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.ViewModel
{
    public class UserUpsertVM
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Points { get; set; }
        public int CityID { get; set; }
        public int GenderID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
