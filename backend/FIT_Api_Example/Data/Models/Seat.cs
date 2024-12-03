using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; }
        public int SeatNumber { get; set; }
        public int CinemaHallID { get; set; }

        [ForeignKey(nameof(CinemaHallID))]
        public CinemaHall CinemaHall { get; set; }

    }
}
