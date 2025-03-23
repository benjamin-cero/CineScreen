using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper.BaseClasses;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class Seat : TenantSpecificTable
    {
        public string SeatNumber { get; set; }
        public int CinemaHallID { get; set; }

        [ForeignKey(nameof(CinemaHallID))]
        public CinemaHall CinemaHall { get; set; }
        public SeatType SeatType { get; set; }

    }
}
