using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class ProjectionUpsertVM
    {
        public DateTime StartTime { get; set; }

        public double Price { get; set; }
        public int MovieID { get; set; }
       
        public int CinemaHallID { get; set; }

        public int MovieTypeID { get; set; }

    }
}
