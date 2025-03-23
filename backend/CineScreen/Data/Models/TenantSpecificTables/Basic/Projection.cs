using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Helper.BaseClasses;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class Projection : TenantSpecificTable
    {
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
