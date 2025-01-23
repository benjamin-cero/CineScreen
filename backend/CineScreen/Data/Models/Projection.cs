using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Projection
    {
        [Key]
        public int ProjectionID { get; set; }
        public DateTime StartTime { get; set; }

        public double Price { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int CinemaHallID { get; set; }

        [ForeignKey(nameof(CinemaHallID))]
        public CinemaHall CinemaHall { get; set; }
        public int MovieTypeID { get; set; }
        [ForeignKey(nameof(MovieTypeID))]
        public MovieType MovieType { get; set; }

    }
}
