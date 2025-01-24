using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models
{
    public class SeatType
    {
        [Key]
        public int SeatTypeID { get; set; }
        public string Name { get; set; }
    }
}
