using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class User : Account
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Points { get; set; }
        public int CityID { get; set; }
        [ForeignKey(nameof(CityID))]
        public City City { get; set; }
        public int GenderID { get; set; }
        [ForeignKey(nameof(GenderID))]
        public Gender Gender { get; set; }


    }
}
