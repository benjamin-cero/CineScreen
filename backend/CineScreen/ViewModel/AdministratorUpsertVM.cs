using FIT_Api_Example.Data.Models;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.ViewModel
{
    public class AdministratorUpsertVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
