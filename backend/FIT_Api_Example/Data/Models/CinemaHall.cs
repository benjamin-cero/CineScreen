using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class CinemaHall
    {
        [Key]
        public int CinemaHallID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
