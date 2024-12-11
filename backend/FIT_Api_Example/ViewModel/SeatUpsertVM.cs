using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class SeatUpsertVM
    {
        public string SeatNumber { get; set; }
        public int CinemaHallID { get; set; }
        public int SeatTypeID { get; set; }
        
    }
}
